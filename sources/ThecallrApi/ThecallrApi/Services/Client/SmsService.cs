using System;
using System.Collections.Generic;
using CallrApi.Enums;
using CallrApi.Helper;
using CallrApi.Json;
using CallrApi.Objects;
using CallrApi.Objects.Sms;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class allows SMS manipulation.
    /// </summary>
    public class SmsService : ClientBaseService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public SmsService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public SmsService(string login, string password) : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method sends a text message.
        /// </summary>
        /// <param name="from">The SMS sender. Must be alphanumeric (at least one character - cannot be digits only). Max length = 11 characters.</param>
        /// <param name="to">The SMS recipient.</param>
        /// <param name="text">Text message.</param>
        /// <param name="options"><see cref="CallrApi.Objects.Sms.SmsOptions" /> options.</param>
        /// <returns>String object representing the identifier you can use to get detailed sms status.</returns>
        /// <seealso cref="CallrApi.Objects.Sms.SmsOptions"/>
        public string Send(string from, string to, string text, SmsOptions options = null)
        {
            List<object> parameters = new List<object>() { from, to, text, options };
            JsonResponse response = this.client.MakeRequest("sms.send", parameters);
            return Helper.Converter<string>.ToObject(response.result, "return");
        }

        /// <summary>
        /// This method gets more informations on a specific SMS.
        /// </summary>
        /// <param name="id">SMS identifier.</param>
        /// <returns><see cref="CallrApi.Objects.Sms.Sms" /> object representing the SMS.</returns>
        /// <seealso cref="CallrApi.Objects.Sms.Sms"/>
        public Sms Get(string id)
        {
            List<object> parameters = new List<object>() { id, };
            JsonResponse response = this.client.MakeRequest("sms.get", parameters);
            return Helper.Creator<Sms>.Object(response.result, "result");
        }

        /// <summary>
        /// This method retrieves the list of your inbound SMS.
        /// </summary>
        /// <param name="from">Retrieve from date.</param>
        /// <param name="to">Retrieve to date.</param>
        /// <returns><see cref="CallrApi.Objects.Sms.Sms" /> object list.</returns>
        /// <seealso cref="CallrApi.Objects.Sms.Sms"/>
        /// <seealso cref="CallrApi.Enums.SmsTypes"/>
        public List<Sms> GetInList(DateTime from, DateTime to)
        {
            List<object> parameters = new List<object>() { SmsTypes.IN, Tools.UtcDateString(from), Tools.UtcDateString(to) };
            JsonResponse response = this.client.MakeRequest("sms.get_list", parameters);
            return Helper.Creator<Sms>.ObjectList(response.result, "result");
        }

        /// <summary>
        /// This method retrieves the list of your outbound SMS.
        /// </summary>
        /// <param name="from">Retrieve from date.</param>
        /// <param name="to">Retrieve to date. </param>
        /// <returns><see cref="CallrApi.Objects.Sms.Sms" /> object list.</returns>
        /// <seealso cref="CallrApi.Objects.Sms.Sms"/>
        /// <seealso cref="CallrApi.Enums.SmsTypes"/>
        public List<Sms> GetOutList(DateTime from, DateTime to)
        {
            List<object> parameters = new List<object>() { SmsTypes.OUT, Tools.UtcDateString(from), Tools.UtcDateString(to) };
            JsonResponse response = this.client.MakeRequest("sms.get_list", parameters);
            return Helper.Creator<Sms>.ObjectList(response.result, "result");
        }
        #endregion
    }
}
