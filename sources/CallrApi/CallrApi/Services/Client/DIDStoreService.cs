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
        /// <param name="AreaCodeID"></param>
        /// <param name="DidClassType"></param>
        /// <param name="Quantity"></param>
        /// <param name="Sequence"></param>
        /// <returns></returns>
        public string ReserveDid(int AreaCodeID,string DidClassType, int Quantity, string Sequence)
        {
            List<object> parameters = new List<object>() { AreaCodeID, DidClassType, Quantity, Sequence };
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

        /// <summary>
        ///  This method allow to cancel an order
        /// </summary>
        /// <param name="token"></param>
        public void Cancel(string token)
        {
            List<object> parameters = new List<object>() { token };
            dynamic response = this.client.MakeRequest("did/store.cancel_order", parameters);
        }

        /// <summary>
        /// This method allow to cancel a DID subscription
        /// </summary>
        /// <param name="hash"></param>
        public void CancelSubscription(string hash){
            List<object> parameters = new List<object>() { hash };
            dynamic response = this.client.MakeRequest("did/store.cancel_subscription", parameters);
        }

        /// <summary>
        /// This method allow to get quota status
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public List<object> GetQuotaStatus(){
            List<object> parameters = new List<object>() {};
            dynamic response = this.client.MakeRequest("did/store.get_quota_status", parameters);
            return reponse.result;
        }

        /// <summary>
        /// This method allow to get a quote without reserving DIDs
        /// </summary>
        /// <param name="AreaCodeID"></param>
        /// <param name="DidClassType"></param>
        /// <param name="Quantity"></param>
        /// <returns></returns>
        public List<object> GetQuote(int AreaCodeID,string DidClassType, int Quantity){
            List<object> parameters = new List<object>() {AreaCodeID, DidClassType, Quantity};
            dynamic response = this.client.MakeRequest("did/store.get_quote", parameters);
            return reponse.result;
        }


        ///<summary>
        /// This method allow to view your order 
        ///</summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<object> ViewOrder(string token){
            List<object> parameters = new List<object>() { token };
            dynamic response = this.client.MakeRequest("did/store.view_order", parameters);
            return reponse.result;
        }

        #endregion
    }
}
