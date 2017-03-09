using System.Collections.Generic;
using CallrApi.Json;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class allows billing manipulation.
    /// </summary>
    public class BillingService : ClientBaseService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public BillingService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public BillingService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method gets realtime prepaid credit balance.
        /// </summary>
        /// <returns>Realtime balance.</returns>
        public decimal GetPrepaidCredit()
        {
            List<object> parameters = new List<object>() { };
            JsonResponse response = this.client.MakeRequest("billing.get_prepaid_credit", parameters);
            return Helper.Converter<decimal>.ToObject(response.result, "return");
        }
        #endregion
    }
}
