using System.Collections.Generic;
using CallrApi.Json;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class gets system informations.
    /// </summary>
    public class SystemService : ClientBaseService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public SystemService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public SystemService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method returns the UNIX time from our servers.
        /// </summary>
        /// <returns>Int object representing the UNIX time (number of seconds that have elapsed since midnight UTC 1 January 1970).</returns>
        public int GetTimestamp()
        {
            List<object> parameters = new List<object>() { };
            JsonResponse response = this.client.MakeRequest("system.get_timestamp", parameters);
            return Helper.Converter<int>.ToObject(response.result, "return");
        }
        #endregion
    }
}
