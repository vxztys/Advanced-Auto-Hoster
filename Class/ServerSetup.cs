using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Apollo_Hoster.Class
{
    public class ServerSetup
    {
        internal static void DownloadFile(string URL, string path)
        {
            new WebClient().DownloadFile(URL, path);
        }

        public static void Details()
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                if (Properties.Settings.Default.DefaultPath == "")
                {
                    mainWindow.Logger.Text += "  [SETUP] Please enter your game path" + Environment.NewLine;
                }
                else
                {
                    mainWindow.Logger.Text += "  [SETUP] Gamepath set as " + Properties.Settings.Default.DefaultPath + Environment.NewLine;
                }
            }
        }

        public static async void Download()
        {
            await Task.Delay(2000);

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\FortniteClient-Win64-Shipping_BE.exe"))
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.Logger.Text += "   [SETUP] Downloaded \"FortniteClient-Win64-Shipping_BE.exe\"" + Environment.NewLine;
                }
                DownloadFile("https://cdn.discordapp.com/attachments/958139296936783892/1000707724507623424/FortniteClient-Win64-Shipping_BE.exe", Directory.GetCurrentDirectory() + "\\FortniteClient-Win64-Shipping_BE.exe");
            }
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\FortniteLauncher.exe"))
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.Logger.Text += "   [SETUP] Downloaded \"FortniteLauncher.exe\"" + Environment.NewLine;
                }
                DownloadFile("https://cdn.discordapp.com/attachments/958139296936783892/1000707724818006046/FortniteLauncher.exe", Directory.GetCurrentDirectory() + "\\FortniteLauncher.exe");
            }
            if (!File.Exists("C:\\Windows\\System32\\D3DCompiler_43.dll"))
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.Logger.Text += "[SERVER SETUP] Downloading \"D3DCompiler_43.dll\"" + Environment.NewLine;
                }
                DownloadFile("https://cdn.discordapp.com/attachments/1097279364145614859/1129091037680369716/D3DCompiler_43.dll", "C:\\Windows\\System32\\D3DCompiler_43.dll");
            }
        }
    }
}
