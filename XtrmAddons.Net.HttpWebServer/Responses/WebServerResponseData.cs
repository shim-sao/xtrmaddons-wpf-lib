using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace XtrmAddons.Net.HttpWebServer.Responses
{
    /// <summary>
    /// <para>Class XtrmAddons Net Http Web Server Response Data.</para>
    /// <para>Create formated response for a Web Server.</para>
    /// </summary>
    public class WebServerResponseData
    {
        #region Properties

        /// <summary>
        /// Property Raw URL from the request object.
        /// </summary>
        public string RawUrl { get; set; }

        /// <summary>
        /// Property Content Type of the file
        /// </summary>
        public string ContentType { get; set; } = "text/html";

        /// <summary>
        /// Property byte array containing the content you need to serve
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Property status code of the response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Property cookie collection.
        /// </summary>
        public CookieCollection Cookies { get; set; } = new CookieCollection();

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Response Data Constructor.
        /// </summary>
        /// <param name="rawUrl">The Uri of the document.</param>
        public WebServerResponseData(string rawUrl)
        {
            RawUrl = rawUrl;
            SetContentType(rawUrl);
            StatusCode = (int)HttpStatusCode.OK;
        }

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Response Data Constructor.
        /// </summary>
        /// <param name="data">The content of the document.</param>
        /// <param name="contentType">The MimeType.</param>
        /// <param name="rawUrl">The Uri of the document.</param>
        public WebServerResponseData(string data, string contentType, string rawUrl)
        {
            RawUrl = rawUrl;
            ContentType = contentType;
            StatusCode = (int)HttpStatusCode.OK;

            byte[] bytes = new byte[data.Length * sizeof(char)];
            Buffer.BlockCopy(data.ToCharArray(), 0, bytes, 0, bytes.Length);
            Content = bytes;
        }

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Response Data Constructor.
        /// </summary>
        /// <param name="data">The content of the document.</param>
        /// <param name="contentType">The MimeType.</param>
        /// <param name="rawUrl">The Uri of the document.</param>
        public WebServerResponseData(byte[] data, string contentType, string rawUrl)
        {
            ContentType = contentType;
            RawUrl = rawUrl;
            Content = data;
            StatusCode = (int)HttpStatusCode.OK;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to add content.
        /// </summary>
        /// <param name="s"></param>
        public void ContentAppend(string s)
        {
            byte[] bytes = new byte[s.Length * sizeof(char)];
            Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0, bytes.Length);

            if (Content == null)
                Content = bytes;
            else
                Content.Concat(bytes);
        }

        /// <summary>
        /// Method to add content.
        /// </summary>
        /// <param name="bytes"></param>
        public void ContentAppend(byte[] bytes)
        {
            if (Content == null)
                Content = bytes;
            else
                Content.Concat(bytes);
        }

        /// <summary>
        /// Method to stop the web server.
        /// </summary>
        public void SetContentType(string rawUrl)
        {
            // Check for file extension.
            if (Path.GetExtension(rawUrl) != "")
            {
                ContentType = MimeMapping.GetMimeMapping(rawUrl);
            }
        }

        /// <summary>
        /// Method to serve direct file.
        /// </summary>
        /// <param name="rawUrl">The rawUrl of the file.</param>
        /// <param name="root">The root directory of the file.</param>
        /// <exception cref="FileNotFoundException"></exception>
        public void ServeFile(string rawUrl = "", string root = "")
        {
            if(rawUrl == "")
            {
                rawUrl = RawUrl;
            }

            try
            {
                rawUrl = root + rawUrl;
                using (FileStream fileStream = new FileStream(Path.Combine(Environment.CurrentDirectory, rawUrl), FileMode.Open, FileAccess.Read))
                {
                    Content = ReadFully(fileStream);
                }
                SetContentType(rawUrl);
            }
            catch(Exception e)
            {
                throw new FileNotFoundException("File not found on public access directory.", e);
            }
        }

        /// <summary>
        /// Method to serve direct file.
        /// </summary>
        /// <param name="rawUrl">The rawUrl of the file.</param>
        /// <param name="root">The root directory of the file.</param>
        /// <exception cref="FileNotFoundException"></exception>
        public void ServeFileUnSafe(string rawUrl = "")
        {
            if (rawUrl == "")
            {
                rawUrl = RawUrl;
            }

            try
            {
                using (FileStream fileStream = new FileStream(rawUrl, FileMode.Open, FileAccess.Read))
                {
                    Content = ReadFully(fileStream);
                }
                SetContentType(rawUrl);
            }
            catch(Exception e)
            {
                throw new FileNotFoundException("File not found on public access directory.", e);
            }
        }

        /// <summary>
        /// Method to read stream and convert it to byte array.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A byte array.</returns>
        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="path"></param>
        /// <param name="domain"></param>
        public void AddCookie(string name, string value, string path, string domain)
        {
            Cookies.Add(new Cookie(name, value, path, domain));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="path"></param>
        public void AddCookie(string name, string value, string path)
        {
            Cookies.Add(new Cookie(name, value, path));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddCookie(string name, string value)
        {
            Cookies.Add(new Cookie(name, value));
        }

        #endregion Methods
    }
}
