using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Apollo_Hoster.Class
{
    public class Backend
    {
        private readonly HttpListener listener;
        private readonly Thread listenerThread;

        public Backend(string[] prefixes)
        {
            listener = new HttpListener();

            foreach (var prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }

            listenerThread = new Thread(HandleRequests);
        }

        public void Start()
        {
            string word = "[BACKEND] Started listening on " + Globals.Port;
            Fortnite.Logger(word);
            listenerThread.Start();
        }

        public void Stop()
        {
            listenerThread.Abort();
            listener.Stop();
        }

        private void HandleRequests()
        {
            try
            {
                listener.Start();
                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(HandleRequest, context);
                }
            }
            catch (Exception ex)
            {
                string word = $"[ERROR] An error occurred: {ex.Message}";
                Fortnite.Logger(word);
            }
        }

        private void HandleRequest(object state)
        {
            HttpListenerContext context = (HttpListenerContext)state;
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            if (request.Url.LocalPath.ToLower() == "/favicon.ico")
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Close();
                return;
            }
            if (request.Url.LocalPath.ToLower() == "/startall")
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    Fortnite.Logger("[BACKEND] Received a request for /STARTALL.");
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
                });
            }
            if (request.Url.LocalPath.ToLower() == "/naesolo")
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    Fortnite.Logger("[BACKEND] Received a request for /NAESOLO.");
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        Fortnite.Launch(Globals.Launch.solosServer, Globals.Launch.solosEmail, Globals.Launch.solosPassword, Globals.Launch.defaultPath);
                    });
                });
            }
            if (request.Url.LocalPath.ToLower() == "/naeduo")
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    Fortnite.Logger("[BACKEND] Received a request for /NAEDUO.");
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        Fortnite.Launch(Globals.Launch.duosServer, Globals.Launch.duosEmail, Globals.Launch.duosPassword, Globals.Launch.defaultPath);
                    });
                });
            }
            if (request.Url.LocalPath.ToLower() == "/naesquad")
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    Fortnite.Logger("[BACKEND] Received a request for /NAESQUAD.");
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        Fortnite.Launch(Globals.Launch.squadsServer, Globals.Launch.squadsEmail, Globals.Launch.squadsPassword, Globals.Launch.defaultPath);
                    });
                });
            }
            if (request.Url.LocalPath.ToLower() == "/naepremium")
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    Fortnite.Logger("[BACKEND] Received a request for /NAEPREMIUM.");
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        Fortnite.Launch(Globals.Launch.premLtgServer, Globals.Launch.premLtgEmail, Globals.Launch.premLtgPassword, Globals.Launch.premiumPath);
                    });
                });
            }
            else if (request.Url.LocalPath.ToLower() == "/eusolo")
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    Fortnite.Logger("[BACKEND] Received a request for /EUSOLO.");
                    System.Windows.MessageBox.Show("eu solo gaz");

                    // ADD THE FUCKING THING TO START THE EU SOLO HERE
                });
            }

            byte[] responseBytes = Encoding.UTF8.GetBytes("Starting new match");
            response.ContentLength64 = responseBytes.Length;
            response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
            response.Close();
        }
    }
}