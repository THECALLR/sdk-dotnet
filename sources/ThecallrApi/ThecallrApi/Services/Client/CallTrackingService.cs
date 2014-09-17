using ThecallrApi.Enums;
using ThecallrApi.Objects.CallTracking;
using ThecallrApi.Objects.App;

namespace ThecallrApi.Services.Client
{
    /// <summary>
    /// This class allows CallTracking management.
    /// </summary>
    public class CallTrackingService : AppsBaseExtendedService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public CallTrackingService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public CallTrackingService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method creates a new CallTracking App, and optionally configure it at the same time.
        /// </summary>
        /// <param name="name">CallTracking App name.</param>
        /// <param name="ct">CallTracking App parameters (Optional).</param>
        /// <returns><see cref="ThecallrApi.Objects.App.App" /> object representing the new CallTracking App.</returns>
        /// <seealso cref="ThecallrApi.Objects.App.App"/>
        /// <seealso cref="ThecallrApi.Objects.CallTracking.CallTracking"/>
        public App Create(string name, CallTracking ct = null)
        {
            return base.Create(ApplicationTypes.CALLTRACKING, name, ct);
        }

        /// <summary>
        /// This method edits a CallTracking App.
        /// </summary>
        /// <param name="app">CallTracking App ID.</param>
        /// <param name="name">The App name. Send <c>null</c> if you do not want to edit the name.</param>
        /// <param name="ct">A CallTracking object containing the parameters you want to edit.</param>
        /// <returns><see cref="ThecallrApi.Objects.App.App" /> object representing the edited CallTracking App.</returns>
        /// <seealso cref="ThecallrApi.Objects.App.App"/>
        /// <seealso cref="ThecallrApi.Objects.CallTracking.CallTracking"/>
        public App Edit(string app, string name, CallTracking ct)
        {
            return base.Edit(app, name, ct);
        }
        #endregion
    }
}
