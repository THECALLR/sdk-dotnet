using System;
using System.Collections.Generic;
using CallrApi.Json;
using CallrApi.Objects;
using CallrApi.Objects.Misc;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class allows you to retrieve static items.
    /// </summary>
    public class ListService : ClientBaseService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public ListService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public ListService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method retrieves all managed countries.
        /// </summary>
        /// <returns>A dictionary of string/<see cref="CallrApi.Objects.Misc.Country" /> key/value pairs.</returns>
        /// <seealso cref="CallrApi.Objects.Misc.Country"/>
        public Dictionary<string, Country> GetCountries()
        {
            List<object> parameters = new List<object>() { };
            JsonResponse response = this.client.MakeRequest("list.countries", parameters);
            return Helper.DictionaryCreator<string, Country>.Object(response.result, "return");
        }

        /// <summary>
        /// This method retrieves informations on a specific phone number.
        /// </summary>
        /// <param name="number">Phone number to inspect.</param>
        /// <returns><see cref="CallrApi.Objects.Misc.NumberInfos" /> object representing number informations.</returns>
        /// <seealso cref="CallrApi.Objects.Misc.NumberInfos"/>
        public NumberInfos GetNumberInfos(string number)
        {
            List<object> parameters = new List<object>() { number };
            JsonResponse response = this.client.MakeRequest("list.number_infos", parameters);
            return Helper.Creator<NumberInfos>.Object(response.result, "return");
        }

        /// <summary>
        /// This method retrieves all managed timezones.
        /// </summary>
        /// <returns>A dictionary of string/<see cref="CallrApi.Objects.Misc.Timezone" /> key/value pairs.</returns>
        /// <seealso cref="CallrApi.Objects.Misc.Timezone"/>
        public Dictionary<int, Timezone> GetTimezones()
        {
            List<object> parameters = new List<object>() { };
            JsonResponse response = this.client.MakeRequest("list.timezones", parameters);
            return Helper.DictionaryCreator<int, Timezone>.Object(response.result, "return");
        }
        #endregion
    }
}
