using System.Collections.Generic;
using CallrApi.Json;
using CallrApi.Objects.App;
using CallrApi.Objects.Misc;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class acts as base class for application services thats allows you CRUD operations.
    /// </summary>
    public abstract class AppsBaseService : ClientBaseService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public AppsBaseService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public AppsBaseService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method retrieves a Voice App.
        /// </summary>
        /// <param name="hash">App ID.</param>
        /// <returns><see cref="CallrApi.Objects.App.App" /> object representing the Voice App.</returns>
        /// <seealso cref="CallrApi.Objects.App.App"/>
        public App Get(string hash)
        {
            List<object> parameters = new List<object>() { hash };
            JsonResponse response = this.client.MakeRequest("apps.get", parameters);
            return Helper.Creator<App>.Object(response.result, "return");
        }

        /// <summary>
        /// This method deletes Voice App.
        /// </summary>
        /// <param name="hash">App ID.</param>
        /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
        public bool Delete(string hash)
        {
            List<object> parameters = new List<object>() { hash };
            JsonResponse response = this.client.MakeRequest("apps.delete", parameters);
            return true;
        }

        /// <summary>
        /// This method lists the authorized CLIs on your account.
        /// </summary>
        /// <param name="type">CLI type (possible values are defined in <see cref="CallrApi.Enums.CliAuthTypes"/> class).</param>
        /// <returns><see cref="CallrApi.Objects.Misc.CustomerCli" /> object list representing the authorized CLIs on your account.</returns>
        /// <seealso cref="CallrApi.Enums.CliAuthTypes"/>
        /// <seealso cref="CallrApi.Objects.Misc.CustomerCli" />
        public List<CustomerCli> GetAuthorizedClis(string type)
        {
            List<object> parameters = new List<object>() { type };
            JsonResponse response = this.client.MakeRequest("apps.get_authorized_clis", parameters);
            return Helper.Creator<CustomerCli>.ObjectList(response.result, "return");
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// This method creates a new Voice App, and optionally configure it at the same time.
        /// </summary>
        /// <param name="type">Voice App type (possible values are defined in <see cref="CallrApi.Enums.ApplicationTypes" /> class).</param>
        /// <param name="name">Voice App name.</param>
        /// <param name="obj">Optional Voice App parameters (possible objects are <see cref="CallrApi.Objects.CallTracking.CallTracking"/>, <see cref="CallrApi.Objects.ClickToCall.ClickToCall"/>, <see cref="CallrApi.Objects.RealTime.RealTime"/>).</param>
        /// <returns><see cref="CallrApi.Objects.App.App" /> object representing the new Voice App.</returns>
        /// <seealso cref="CallrApi.Objects.App.App"/>
        /// <seealso cref="CallrApi.Objects.CallTracking.CallTracking"/>
        /// <seealso cref="CallrApi.Objects.ClickToCall.ClickToCall"/>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTime"/>
        /// <seealso cref="CallrApi.Enums.ApplicationTypes"/>
        protected App Create(string type, string name, object obj)
        {
            List<object> parameters = new List<object>() { type, name, obj };
            JsonResponse response = this.client.MakeRequest("apps.create", parameters);
            return Helper.Creator<App>.Object(response.result, "return");
        }

        /// <summary>
        /// This method edits a Voice App.
        /// </summary>
        /// <param name="hash">Voice App ID.</param>
        /// <param name="name">The App name. Send <c>null</c> if you do not want to edit the name.</param>
        /// <param name="app">An object containing the parameters you want to edit (possible objects are <see cref="CallrApi.Objects.CallTracking.CallTracking"/>, <see cref="CallrApi.Objects.ClickToCall.ClickToCall"/>, <see cref="CallrApi.Objects.RealTime.RealTime"/>).</param>
        /// <returns><see cref="CallrApi.Objects.App.App" /> object representing the edited Voice App.</returns>
        /// <seealso cref="CallrApi.Objects.App.App"/>
        /// <seealso cref="CallrApi.Objects.CallTracking.CallTracking"/>
        /// <seealso cref="CallrApi.Objects.ClickToCall.ClickToCall"/>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTime"/>
        protected App Edit(string hash, string name, object app)
        {
            List<object> parameters = new List<object>() { hash, name, app };
            JsonResponse response = this.client.MakeRequest("apps.edit", parameters);
            return Helper.Creator<App>.Object(response.result, "return");
        }
        #endregion
    }
}
