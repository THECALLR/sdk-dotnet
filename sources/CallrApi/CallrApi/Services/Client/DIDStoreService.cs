using System.Collections.Generic;

namespace CallrApi.Services.Client
{
    class DIDStoreService : AppsBaseService
    {

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public DIDStoreService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public DIDStoreService(string login, string password)
            : this(null, login, password)
        {
        }
        #endregion

        #region Public methods
        /// <summary>
        ///  This method reserve DID
        /// </summary>
        /// <param name="prefixToOrder"></param>
        /// <returns></returns>
        public string ReserveDid(int prefixToOrder)
        {
            List<object> parameters = new List<object>() { prefixToOrder, "CLASSIC", 1, "RANDOM" };
            dynamic response = this.client.MakeRequest("did/store.reserve", parameters);
            return response.result["token"].ToString();
        }

        /// <summary>
        ///  This method allow to buy DID
        /// </summary>
        /// <param name="token"></param>
        public void Buy(string token)
        {
            List<object> parameters = new List<object>() { token };
            dynamic response = this.client.MakeRequest("did/store.buy_order", parameters);
        }
        #endregion
    }
}
