using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using XtrmAddons.Net.HttpWebServer.Events;
using XtrmAddons.Net.HttpWebServer.Interfaces;
using XtrmAddons.Net.HttpWebServer.Session;
using XtrmAddons.Net.Common.Extensions;
using XtrmAddons.Net.HttpWebServer.Responses;

namespace XtrmAddons.Net.HttpWebServer
{
    /// <summary>
    /// Class XtrmAddons Net Http Web Server.
    /// </summary>
    public abstract class WebServer : IHttpServer
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion



        #region Events

        /// <summary>
        /// Variable envent handler on server start.
        /// </summary>
        public event EventHandler<WebServerStartEventArgs> WebServerStartEventHandler;
        
        #endregion



        #region Properties

        /// <summary>
        /// Property web server prefix.
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// Variable is server started.
        /// </summary>
        public bool IsStarted { get; private set; }

        /// <summary>
        /// Property web server session.
        /// </summary>
        public WebServerSession Session { get; } = new WebServerSession();

        /// <summary>
        /// Property web server Http listener.
        /// </summary>
        public HttpListener Listener { get; } = new HttpListener();

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Constructor.
        /// </summary>
        /// <param name="prefix">The prefix of the server.</param>
        public WebServer(string prefix = null)
        {
            Prefix = prefix ?? "127.0.0.1";
            Start(prefix);
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to start and initialize a simple http web server.
        /// </summary>
        /// <param name="prefix">The prefix of the server.</param>
        public void Start(string prefix)
        {
            // Check if Http listener is supported.
            if (!HttpListener.IsSupported)
            {
                log.Fatal("Needs Windows XP SP2, Server 2003 or later.");
                throw new NotSupportedException("Needs Windows XP SP2, Server 2003 or later.");
            }

            // URI prefixes are required, for example 
            // "http://localhost:8080/".
            if (prefix == null || prefix.Length == 0)
            {
                log.Fatal("URI prefixes are required !");
                throw new ArgumentException("URI prefix is required !");
            }

            // Start server.
            Listener.Prefixes.Add(prefix);
            Listener.Start();

            OnStart();

            log.Info("Http Web server start with URI prefix : " + prefix);
        }

        /// <summary>
        /// Method called on server start.
        /// </summary>
        protected void OnStart()
        {
            IsStarted = true;

            WebServerStartEventArgs args = new WebServerStartEventArgs();
            OnServerStart(args);
        }

        /// <summary>
        /// Method called on server start event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnServerStart(WebServerStartEventArgs e)
        {
            WebServerStartEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Method to run the web server.
        /// </summary>
        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                log.Info("Web server is running...");
                try
                {
                    while (Listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            HttpListenerContext ctx = c as HttpListenerContext;

                            try
                            {
                                WebServerResponseData response = GetResponse(ctx);
                                byte[] buffer;

                                if(response == null)
                                {
                                    throw new FileNotFoundException("Null response.");
                                }

                                // Add content type to response.
                                ctx.Response.Headers[HttpResponseHeader.ContentType] = response.ContentType;

                                // Set content to byte buffer.
                                if(response.ContentType.Contains("text") || response.ContentType.Contains("html"))
                                {
                                    //buffer = Encoding.Unicode.GetBytes(WPFString.ConvertByteToString(response.Content));
                                    buffer = Encoding.UTF8.GetBytes(response.Content.ConvertByteToString(Encoding.Unicode));
                                    //buffer = Encoding.Convert(Encoding.Unicode, Encoding.Default, buffer);
                                }
                                else
                                {
                                    buffer = response.Content;
                                }

                                // Add content length to response.
                                ctx.Response.ContentLength64 = buffer.Length;

                                // Add status code.
                                ctx.Response.StatusCode = response.StatusCode;

                                ctx.Response.Cookies = response.Cookies;

                                // Write output to buffer.
                                ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            }

                            catch (FileNotFoundException e)
                            {
                                log.Error("Server response error :", e);

                                Output(ctx, string.Format(
                                    "<html><head>"
                                    + "<meta http-equiv=\"Content - Type\" content=\"text/html; charset=UTF-8\">"
                                    + "<charset=\"utf-8\">"
                                    + "</head><body><center>"
                                    + "404 Error : Page not found !<br>{0}<br>{1}<br>{2}</center></body></html>"

                                    , DateTime.Now
                                    , e.GetType() + " : " + e.Message
                                    , e.StackTrace)
                                );
                            }

                            catch (Exception e)
                            {
                                log.Error("Server response error :", e);

                                Output(ctx, string.Format(
                                    "<html><head>"
                                    + "<meta http-equiv=\"Content - Type\" content=\"text/html; charset=UTF-8\">"
                                    + "<charset=\"utf-8\">"
                                    + "</head><body><center>"
                                    + "500 Error : Bad server request !<br>{0}<br>{1}<br>{2}</center></body></html>"

                                    , DateTime.Now
                                    , e.GetType() + " : " + e.Message
                                    , e.StackTrace)
                                );
                            }

                            // always close the stream
                            finally
                            {
                                ctx.Response.OutputStream.Close();
                            }
                        }, Listener.GetContext());
                    }
                }
                catch { } // suppress any exceptions
            });
        }

        /// <summary>
        /// Method to stop the Http web server.
        /// </summary>
        public void Stop()
        {
            if(IsStarted)
            {
                Listener.Stop();
                Listener.Close();
                IsStarted = false;
                log.Info("Web server stopped.");
            }
            else
            {
                log.Info("Web server stopped but not started.");
            }
        }

        /// <summary>
        /// Method to output response of the server.
        /// </summary>
        /// <param name="ctx">The Http listener context</param>
        /// <param name="s">A response string to output.</param>
        public void Output(HttpListenerContext ctx, string s)
        {
            byte[] buf = Encoding.UTF8.GetBytes(s);
            ctx.Response.ContentLength64 = buf.Length;
            ctx.Response.OutputStream.Write(buf, 0, buf.Length);
        }

        /// <summary>
        /// Method to get a response of the server.
        /// </summary>
        /// <param name="ctx">The Http listener where get request.</param>
        /// <returns>The response data.</returns>
        public abstract WebServerResponseData GetResponse(HttpListenerContext ctx);

        #endregion



        #region IDisposable Support

        /// <summary>
        /// Variable to detect redondent call.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Method to dispose the web server object.
        /// </summary>
        /// <param name="disposing">Check if object can be dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Listener.Close();
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~WPFSQLiteData() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        /// <summary>
        /// <para>Method to dispose object and its managed dependencies.</para>
        /// <para>Ce code est ajouté pour implémenter correctement le modèle supprimable.</para>
        /// </summary>
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
