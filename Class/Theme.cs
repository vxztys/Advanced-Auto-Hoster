using Apollo_Hoster.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Apollo_Hoster.Class
{
    internal class Theme
    {
        public static void Red()
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainGrid.Background = new BrushConverter().ConvertFrom("#FF370707") as SolidColorBrush;
                mainWindow.windowmain.Background = new BrushConverter().ConvertFrom("#FF370707") as SolidColorBrush;

                mainWindow.settings.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Solos.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Duos.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Squads.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                mainWindow.Logger.Opacity = .5;
                mainWindow.Logger.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                if (mainWindow.main.Content is Settings settings)
                {
                    settings.background.Background = new BrushConverter().ConvertFrom("#FF370707") as SolidColorBrush;
                }
            }
        }
        public static void Blue()
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainGrid.Background = new BrushConverter().ConvertFrom("#FF111317") as SolidColorBrush;
                mainWindow.windowmain.Background = new BrushConverter().ConvertFrom("#FF111317") as SolidColorBrush;

                mainWindow.settings.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Solos.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Duos.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Squads.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                mainWindow.Logger.Opacity = .5;
                mainWindow.Logger.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                if (mainWindow.main.Content is Settings settings)
                {
                    settings.background.Background = new BrushConverter().ConvertFrom("#FF111317") as SolidColorBrush;
                }


            }

        }
        public static void Purple()
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainGrid.Background = new BrushConverter().ConvertFrom("#FF21101E") as SolidColorBrush;
                mainWindow.windowmain.Background = new BrushConverter().ConvertFrom("#FF21101E") as SolidColorBrush;

                mainWindow.settings.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Solos.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Duos.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Squads.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                mainWindow.Logger.Opacity = .5;
                mainWindow.Logger.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                if (mainWindow.main.Content is Settings settings)
                {
                    settings.background.Background = new BrushConverter().ConvertFrom("#FF21101E") as SolidColorBrush;
                }
            }
        }

        
        public static void Neon() //#FF00121B
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainGrid.Background = new BrushConverter().ConvertFrom("#FF001017") as SolidColorBrush;
                mainWindow.windowmain.Background = new BrushConverter().ConvertFrom("#FF001017") as SolidColorBrush;//change bg color

                //change all foregrounds

                mainWindow.settings.Foreground = new BrushConverter().ConvertFrom("#FFB9FF68") as SolidColorBrush;
                mainWindow.Solos.Foreground = new BrushConverter().ConvertFrom("#FFB9FF68") as SolidColorBrush;
                mainWindow.Duos.Foreground = new BrushConverter().ConvertFrom("#FFB9FF68") as SolidColorBrush;
                mainWindow.Squads.Foreground = new BrushConverter().ConvertFrom("#FFB9FF68") as SolidColorBrush;

                mainWindow.Logger.Opacity = .5;
                mainWindow.Logger.Foreground = new BrushConverter().ConvertFrom("#FFFF5FA8") as SolidColorBrush;
                mainWindow.Input.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                if (mainWindow.main.Content is Settings settings)
                {
                    settings.background.Background = new BrushConverter().ConvertFrom("#FF001017") as SolidColorBrush;
                }
            }
        }
        
        public static void ForestGreen() //#FF00170F
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainGrid.Background = new BrushConverter().ConvertFrom("#FF02120C") as SolidColorBrush;
                mainWindow.windowmain.Background = new BrushConverter().ConvertFrom("#FF02120C") as SolidColorBrush;

                mainWindow.settings.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Solos.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Duos.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
                mainWindow.Squads.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                mainWindow.Logger.Opacity = .5;
                mainWindow.Logger.Foreground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;

                if (mainWindow.main.Content is Settings settings)
                {
                    settings.background.Background = new BrushConverter().ConvertFrom("#FF02120C") as SolidColorBrush;
                }
            }
        }
        public static void Pumpkin() //#FF121212
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainGrid.Background = new BrushConverter().ConvertFrom("#FF121212") as SolidColorBrush;
                mainWindow.windowmain.Background = new BrushConverter().ConvertFrom("#FF121212") as SolidColorBrush;

                mainWindow.settings.Foreground = new BrushConverter().ConvertFrom("#FFFF803F") as SolidColorBrush;
                mainWindow.Solos.Foreground = new BrushConverter().ConvertFrom("#FFFF803F") as SolidColorBrush;
                mainWindow.Duos.Foreground = new BrushConverter().ConvertFrom("#FFFF803F") as SolidColorBrush;
                mainWindow.Squads.Foreground = new BrushConverter().ConvertFrom("#FFFF803F") as SolidColorBrush;

                mainWindow.Logger.Opacity = .5;
                mainWindow.Logger.Foreground = new BrushConverter().ConvertFrom("#FFFF803F") as SolidColorBrush;

                if (mainWindow.main.Content is Settings settings)
                {
                    settings.background.Background = new BrushConverter().ConvertFrom("#FF121212") as SolidColorBrush;
                }
            }
        }
    }
}
