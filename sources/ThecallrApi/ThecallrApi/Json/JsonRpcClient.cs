using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using CallrApi.Exception;

namespace CallrApi.Json
{
    /// <summary>
    /// This class allows you to execute API requests.
    /// </summary>
    public class JsonRpcClient
    {
        /// <summary>
        /// API url.
        /// </summary>
        public static readonly string URL_API = "https://api.thecallr.com";

        #region Member variables
        /// <summary>
        /// API url.
        /// </summary>
        public string url { get; private set; }

        /// <summary>
        /// Login.
        /// </summary>
        public string login { get; private set; }

        /// <summary>
        ///Password.
        /// </summary>
        public string password { get; private set; }

        /// <summary>
        /// Base 64 encoded "login:password" string.
        /// </summary>
        private string base64_authorization { get; set; }

        /// <summary>
        /// Current request ID.
        /// </summary>
        private int request_id { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public JsonRpcClient(string url, string login, string password)
        {
            Random random = new Random();
            this.request_id = random.Next(0, 10000);
            this.url = string.IsNullOrEmpty(url) ? JsonRpcClient.URL_API : url;
            this.login = login;
            this.password = password;
            this.base64_authorization = "Basic " +
                Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(string.Format("{0}:{1}", this.login, this.password)));
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public JsonRpcClient(string login, string password)
            : this(null, login, password)
        {
        }
        #endregion

        #region Public methods
		/// <summary>
        /// This metho requests the specified API method with its parameter.
        /// </summary>
        /// <param name="method">API method to execute.</param>
        /// <param name="parameter">Method parameter.</param>
        /// <returns><see cref="CallrApi.Json.JsonResponse"/> object containing error or result.</returns>
        /// <seealso cref="CallrApi.Json.JsonResponse"/>
        /// <seealso cref="CallrApi.Json.JsonRequest"/>
        /// <seealso cref="System.Net.HttpWebRequest"/>
        /// <seealso cref="System.Web.Script.Serialization.JavaScriptSerializer"/>
        public JsonResponse MakeRequest(string method, object parameter)
        {
            JsonResponse response = null;
            try
            {
                // Make HTTP POST request to send to the API
                HttpWebRequest web_request = (HttpWebRequest)WebRequest.Create(this.url);
                web_request.Method = "POST";
                web_request.ContentType = "application/json-rpc; charset=utf-8";
                web_request.ServicePoint.Expect100Continue = false; // Hack for lighttpd bug
                web_request.Headers["Authorization"] = this.base64_authorization;

                // POST content initialization
                JsonRequest json_request = new JsonRequest(++this.request_id, method, parameter);
                using (TextWriter writer = new StreamWriter(web_request.GetRequestStream()))
                {
                    string json = json_request.GetJson();
                    writer.Write(json);
                }

                // Request execution
                using (WebResponse web_response = web_request.GetResponse())
                {
                    // Response parsing
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    using (StreamReader response_stream = new StreamReader(web_response.GetResponseStream()))
                    {
                        response = js.Deserialize<JsonResponse>(response_stream.ReadToEnd());
                    }
                }

                // Response analysis
                if (response.error != null)
                    throw new RemoteApiException(response.error);
            }
            catch (RemoteApiException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw new LocalApiException("An error occured during API request process.", ex);
            }
            return response;
        }
    	#endregion
    }
}
