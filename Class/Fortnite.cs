using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;

namespace Apollo_Hoster.Class
{
    public static class Fortnite
    {
        public static void SafeKillProcess(string processName)
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName(processName);
                for (int i = 0; i < processesByName.Length; i++)
                {
                    processesByName[i].Kill();
                }
            }
            catch { }
        }

        internal static void DownloadFile(string URL, string path)
        {
            new WebClient().DownloadFile(URL, path);
        }

        public static void Logger(string word)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.Logger.Text += "  " + word + Environment.NewLine;
                }
            });
        }

        public static void Inject(int pid, string path)
        {
            IntPtr hProcess = Win32.OpenProcess(1082, false, pid);
            IntPtr procAdress = Win32.GetProcAddress(Win32.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            uint num = checked((uint)((path.Length + 1) * Marshal.SizeOf(typeof(char))));
            IntPtr intPtr = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, num, 12288U, 4U);
            UIntPtr uintPtr;
            Win32.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(path), num, out uintPtr);
            Win32.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAdress, intPtr, 0U, IntPtr.Zero);
        }

        public static async void Launch(string server, string email, string password, string path)
        {
            try
            {
                if (!File.Exists("C:\\Windows\\System32\\D3DCompiler_43.dll"))
                {
                    // most vps dont have this, it removes the error that you get when fortnite crashes
                    DownloadFile("https://cdn.discordapp.com/attachments/1097279364145614859/1129091037680369716/D3DCompiler_43.dll", "C:\\Windows\\System32\\D3DCompiler_43.dll");
                }

            start:

                SafeKillProcess($"FortniteClient-Win64-Shipping_BE{server}");
                SafeKillProcess($"FortniteLauncher{server}");
                SafeKillProcess($"FortniteClient-Win64-Shipping{server}");
                SafeKillProcess($"CrashReportClient");

                Process proc = new Process();
                proc.StartInfo.FileName = path + $"\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping{server}.exe";
                proc.StartInfo.Arguments = $"-epicapp=Fortnite -epicenv=Prod -epicportal -AUTH_TYPE=epic -AUTH_LOGIN={email} -AUTH_PASSWORD={password} -epiclocale=en-us -fltoken=7a848a93a74ba68876c36C1c -fromfl=none -noeac -nobe -skippatchcheck -nullrhi -nosound ";
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                Thread.Sleep(5000);

                if (server == "PREMIUM")
                {
                    Inject(proc.Id, Directory.GetCurrentDirectory() + "\\PREMIUMREDIRECT.dll");
                    Logger($"[{server}] Injected redirected successfully.");
                }
                else
                {
                    Inject(proc.Id, Directory.GetCurrentDirectory() + "\\REDIRECT.dll");
                    Logger($"[{server}] Injected redirected successfully.");
                }
                try
                {
                    while (true)
                    {
                        string output = proc.StandardOutput.ReadLine();
                        if (output != null)
                        {
                            if (output.Contains("Game Engine Initialized"))
                            {
                                Inject(proc.Id, Directory.GetCurrentDirectory() + $"\\{server}.dll");
                                Logger($"[{server}] Injected gameserver dll successfully.");
                            }
                        }
                        else
                        {
                            var fortnite = Process.GetProcessesByName($"FortniteClient-Win64-Shipping{server}.exe");

                            if (fortnite.Length == 0)
                            {
                                Logger($"[{server}] Restarting");
                                goto start;
                            }
                        }
                    }
                }
                catch (Exception ex)
                { Logger("[ERROR] An exception occurred: " + ex.Message); }
                finally
                { }
            }
            catch (Exception ex) { }
        }
    }
}









