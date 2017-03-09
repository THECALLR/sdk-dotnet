using System.Collections.Generic;
using CallrApi.Json;
using CallrApi.Objects.App;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class allows Voice Apps manipulation.
    /// </summary>
    public class AppsService : AppsBaseExtendedService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public AppsService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public AppsService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
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
        public new App Create(string type, string name, object obj)
        {
            return base.Create(type, name, obj);
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
        public new App Edit(string hash, string name, object app)
        {
            return base.Edit(hash, name, app);
        }

        /// <summary>
        /// This method retrieves the list of your Voice Apps.
        /// </summary>
        /// <param name="with_numbers">If <c>true</c>, also returns the list of DIDs associated with each app.</param>
        /// <returns><see cref="CallrApi.Objects.App.App" /> object list representing the list of Voice Apps.</returns>
        /// <seealso cref="CallrApi.Objects.App.App"/>
        public List<App> GetList(bool with_numbers)
        {
            List<object> parameters = new List<object>() { with_numbers };
            JsonResponse response = this.client.MakeRequest("apps.get_list", parameters);
            return Helper.Creator<App>.ObjectList(response.result, "result");
        }
        #endregion
    }
}
