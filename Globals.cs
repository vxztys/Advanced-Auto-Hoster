

namespace Apollo_Hoster
{
    public class Globals
    {
        public static string Address = "127.0.0.1";
        public static string Port = "3551";
        public static string Domain = $"http://{Globals.Address}:{Globals.Port}/"; //do NOT mess with this

        public static bool bAreRequestsEnabled = true;

        public class Gameserver
        {
            public static bool bIsMCPEnabled = true;
            public static bool disableRestarting_enableMoreServers = false; //this stops the autohoster from restarting the current games and continues starting new matches
            public static string howLongBetween = "5m"; //if you have disableRestarting_enableMoreServers = true, it will start a game every x amount of minutes, seconds, hours, etc. 
        }


        public class Launch
        {
            public static string defaultPath = Properties.Settings.Default.DefaultPath;
            public static string premiumPath = Properties.Settings.Default.PremiumPath;

            public static string solosServer = "SOLO"; //the ending part of fortniteclient-win64-shipping{ENDINGPART}.exe --> fortniteclient-win64-shippingSOLO.exe
            public static string solosEmail = "";
            public static string solosPassword = "";

            public static string duosServer = "DUO"; //the ending part of fortniteclient-win64-shipping{ENDINGPART}.exe --> fortniteclient-win64-shippingDUO.exe
            public static string duosEmail = "";
            public static string duosPassword = "";

            public static string squadsServer = "SQUAD"; //the ending part of fortniteclient-win64-shipping{ENDINGPART}.exe --> fortniteclient-win64-shippingSQUAD.exe
            public static string squadsEmail = "";
            public static string squadsPassword = "";

            public static string premLtgServer = "PREMIUM";
            public static string premLtgEmail = "";
            public static string premLtgPassword = "";
        }
    }
}
