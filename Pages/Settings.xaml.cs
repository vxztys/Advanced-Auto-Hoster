using System.Windows;
using System.Windows.Controls;

namespace Apollo_Hoster.Pages
{
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            Globals.bAreRequestsEnabled = false;
        }

        private void RadioButton_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void rbOption1_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Theme = "Red";
            Properties.Settings.Default.Save();
            Class.Theme.Red();
        }

        private void rbOption2_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Theme = "Blue";
            Properties.Settings.Default.Save();
            Class.Theme.Blue();
        }

        private void rbOption3_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Theme = "Purple";
            Properties.Settings.Default.Save();
            Class.Theme.Purple();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.main.Content = null;
                mainWindow.main.IsHitTestVisible = false;
            }
        }

        private void rbOption4_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Theme = "Neon";
            Properties.Settings.Default.Save();
            Class.Theme.Neon();
        }

        private void rbOption5_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Theme = "ForestGreen";
            Properties.Settings.Default.Save();
            Class.Theme.ForestGreen();
        }


        private void rbOption6_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Theme = "Pumpkin";
            Properties.Settings.Default.Save();
            Class.Theme.Pumpkin();
        }
    }
}
