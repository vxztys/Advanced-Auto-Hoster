using Apollo_Hoster.Class;
using Apollo_Hoster.Pages;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Apollo_Hoster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isExpectingPremiumLogin = false;
        private bool isExpectingLogin = false;
        private string email = string.Empty;
        private string password = string.Empty;
        private Backend backend;

        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            Class.ServerSetup.Details();
            Class.ServerSetup.Download();
            

            backend = new Backend(new string[] { Globals.Domain });
            backend.Start();

            if (Properties.Settings.Default.Theme == "Red")
            {
                Class.Theme.Red();
            }
            if (Properties.Settings.Default.Theme == "Blue")
            {
                Class.Theme.Blue();
            }
            if (Properties.Settings.Default.Theme == "Purple")
            {
                Class.Theme.Purple();
            }
            if (Properties.Settings.Default.Theme == "Neon")
            {
                Class.Theme.Neon();
            }
            if (Properties.Settings.Default.Theme == "ForestGreen")
            {
                Class.Theme.ForestGreen();
            }
            if (Properties.Settings.Default.Theme == "Pumpkin")
            {
                Class.Theme.Pumpkin();
            }
        }

        private async void Solos_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Fortnite.Launch(Globals.Launch.solosServer, Globals.Launch.solosEmail, Globals.Launch.solosPassword, Globals.Launch.defaultPath);
            });
        }

        private void AppendTextToLogger(string text)
        {
            Logger.Text += Environment.NewLine + text;
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string input = Input.Text.Trim();
                if (isExpectingLogin)
                {
                    string[] parts = input.Split(':');
                    if (parts.Length == 2)
                    {
                        email = parts[0];
                        password = parts[1];

                        Properties.Settings.Default.Email = email;
                        Properties.Settings.Default.Password = password;
                        Properties.Settings.Default.Save();

                        AppendTextToLogger($"  [SETUP] Logged in with email: {email} and password: [hidden]");
                        isExpectingLogin = false;
                    }
                    else
                    {
                        AppendTextToLogger("  [SETUP] Invalid login format. Please use email:password.");
                    }
                    Input.Clear();
                }
                if (isExpectingPremiumLogin)
                {
                    string[] parts = input.Split(':');
                    if (parts.Length == 2)
                    {
                        email = parts[0];
                        password = parts[1];

                        Properties.Settings.Default.Email = email;
                        Properties.Settings.Default.Password = password;
                        Properties.Settings.Default.Save();

                        AppendTextToLogger($"  [SETUP] Logged in with email: {email} and password: [hidden]");
                        isExpectingPremiumLogin = false;
                    }
                    else
                    {
                        AppendTextToLogger("  [SETUP] Invalid login format. Please use email:password.");
                    }
                    Input.Clear();
                }
                else if (input.Equals("/premiumgamepath", StringComparison.OrdinalIgnoreCase))
                {
                    using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
                    {
                        dialog.Multiselect = false;
                        dialog.Title = "Select your Fortnite Folder!";
                        dialog.IsFolderPicker = true;
                        dialog.EnsurePathExists = true;
                        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            Properties.Settings.Default.PremiumPath = dialog.FileName;
                            Properties.Settings.Default.Save();
                            AppendTextToLogger("  [SETUP] Fortnite game folder path updated.");
                        }
                        else
                        {
                            AppendTextToLogger("  [SETUP] No folder selected.");
                        }
                    }

                    Input.Clear();
                }
                else if (input.Equals("/startpremium", StringComparison.OrdinalIgnoreCase))
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        Fortnite.Launch(Globals.Launch.premLtgServer, Globals.Launch.premLtgEmail, Globals.Launch.premLtgPassword, Globals.Launch.premiumPath);
                    });

                    Input.Clear();
                }
                else if (input.Equals("/startsquad", StringComparison.OrdinalIgnoreCase))
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        Fortnite.Launch(Globals.Launch.squadsServer, Globals.Launch.squadsEmail, Globals.Launch.squadsPassword, Globals.Launch.defaultPath);
                    });

                    Input.Clear();
                }

                else if (input.Equals("/startduo", StringComparison.OrdinalIgnoreCase))
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        Fortnite.Launch(Globals.Launch.duosServer, Globals.Launch.duosEmail, Globals.Launch.duosPassword, Globals.Launch.defaultPath);
                    });

                    Input.Clear();
                }
                else if (input.Equals("/startsolo", StringComparison.OrdinalIgnoreCase))
                {
      

                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        Fortnite.Launch(Globals.Launch.solosServer, Globals.Launch.solosEmail, Globals.Launch.solosPassword, Globals.Launch.defaultPath);
                    });

                    Input.Clear();
                }
                else if (input.Equals("/startall", StringComparison.OrdinalIgnoreCase))
                {
    

                    ThreadPool.QueueUserWorkItem(async _ =>
                    {
                        Fortnite.Launch(Globals.Launch.solosServer, Globals.Launch.solosEmail, Globals.Launch.solosPassword, Globals.Launch.defaultPath);
                        await Task.Delay(12000); //Fortnite.Logger("attemping to start duos from start all");
                        Fortnite.Launch(Globals.Launch.duosServer, Globals.Launch.duosEmail, Globals.Launch.duosPassword, Globals.Launch.defaultPath);
                        await Task.Delay(14000); //Fortnite.Logger("attemping to start squads from start all");
                        Fortnite.Launch(Globals.Launch.squadsServer, Globals.Launch.squadsEmail, Globals.Launch.squadsPassword, Globals.Launch.defaultPath);
                        await Task.Delay(16000); //Fortnite.Logger("attemping to start premium from start all");
                        Fortnite.Launch(Globals.Launch.premLtgServer, Globals.Launch.premLtgEmail, Globals.Launch.premLtgPassword, Globals.Launch.premiumPath);
                    });

                    Input.Clear();
                }
                else if (input.Equals("/gamepath", StringComparison.OrdinalIgnoreCase))
                {
                    using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
                    {
                        dialog.Multiselect = false;
                        dialog.Title = "Select your Fortnite Folder!";
                        dialog.IsFolderPicker = true;
                        dialog.EnsurePathExists = true;
                        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            // GamePath.Text = dialog.FileName;
                            Properties.Settings.Default.DefaultPath = dialog.FileName;
                            Properties.Settings.Default.Save();
                            AppendTextToLogger("  [SETUP] Fortnite game folder path updated.");
                        }
                        else
                        {
                            AppendTextToLogger("  [SETUP] No folder selected.");
                        }
                    }

                    Input.Clear();
                }
                else if (input.Equals("/help", StringComparison.OrdinalIgnoreCase))
                {
                    AppendTextToLogger("  [HELP] Here's a list of valid commands");
                    AppendTextToLogger("  /login (Allows you to type in your login information)");
                    AppendTextToLogger("  /premiumlogin (Allows you to type in your premium login information)");
                    AppendTextToLogger("  /gamepath (Allows you to select your gamepath that you launch with.)");
                    AppendTextToLogger("  /premiumgamepath (Allows you to select your premium gamepath that you launch with.)");
                    AppendTextToLogger("  /startsolo (Starts a solos match)");
                    AppendTextToLogger("  /startduo (Starts a duos match)");
                    AppendTextToLogger("  /startsquad (Starts a squads match)");
                    AppendTextToLogger("  /startpremium (Starts a premium lategame match)");
                    AppendTextToLogger("  /startall (Starts all matches)");
                    Input.Clear();
                }
                else if (input.Equals("/premiumlogin", StringComparison.OrdinalIgnoreCase))
                {
                    AppendTextToLogger("  [SETUP] Please type your login information like this email:password");
                    isExpectingPremiumLogin = true;
                    Input.Clear();
                }
                else if (input.Equals("/defaultlogin", StringComparison.OrdinalIgnoreCase))
                {
                    AppendTextToLogger("  [SETUP] Please type your login information like this email:password");
                    isExpectingLogin = true;
                    Input.Clear();
                }
                else
                {
                    AppendTextToLogger("  [INPUT] " + input);
                    Input.Clear();
                }
            }
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new Settings();
            main.IsHitTestVisible = true;
        }

        private void windowmain_Closed(object sender, EventArgs e)
        {
            backend = new Backend(new string[] { Globals.Domain });
            backend.Stop();
        }

        private void Duos_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Fortnite.Launch(Globals.Launch.duosServer, Globals.Launch.duosEmail, Globals.Launch.duosPassword, Globals.Launch.defaultPath);
            });
        }

        private void Squads_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Fortnite.Launch(Globals.Launch.squadsServer, Globals.Launch.squadsEmail, Globals.Launch.squadsPassword, Globals.Launch.defaultPath);
            });
        }

        private void Check_Checked(object sender, RoutedEventArgs e)
        {
            //thy skunith monkith
        }
    }
}
