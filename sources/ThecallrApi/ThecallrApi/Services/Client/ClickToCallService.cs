using System;
using System.Collections.Generic;
using ThecallrApi.Enums;
using ThecallrApi.Helper;
using ThecallrApi.Json;
using ThecallrApi.Objects.App;
using ThecallrApi.Objects.ClickToCall;
using ThecallrApi.Objects.Misc;

namespace ThecallrApi.Services.Client
{
    /// <summary>
    /// This class allows Click-To-Call manipulation.
    /// </summary>
    public class ClickToCallService : AppsBaseService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public ClickToCallService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public ClickToCallService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method creates a new Click-To-Call App, and optionally configure it at the same time.
        /// </summary>
        /// <param name="name">Click-To-Call App name.</param>
        /// <param name="ctc">Click-To-Call App parameters (Optional).</param>
        /// <returns><see cref="ThecallrApi.Objects.App.App" /> object representing the new Click-To-Call App.</returns>
        /// <seealso cref="ThecallrApi.Objects.App.App"/>
        /// <seealso cref="ThecallrApi.Objects.ClickToCall.ClickToCall"/>
        public App Create(string name, ClickToCall ctc = null)
        {
            return base.Create(ApplicationTypes.CLICKTOCALL, name, ctc);
        }

        /// <summary>
        /// This method edits a Click-To-Call App.
        /// </summary>
        /// <param name="app">Click-To-Call App ID.</param>
        /// <param name="name">The App name. Send <c>null</c> if you do not want to edit the name.</param>
        /// <param name="ctc">A Click-To-Call object containing the parameters you want to edit.</param>
        /// <returns><see cref="ThecallrApi.Objects.App.App" /> object representing the edited Click-To-Call App.</returns>
        /// <seealso cref="ThecallrApi.Objects.App.App"/>
        /// <seealso cref="ThecallrApi.Objects.ClickToCall.ClickToCall"/>
        public App Edit(string app, string name, ClickToCall ctc)
        {
            return base.Edit(app, name, ctc);
        }

        /// <summary>
        /// This method cancels a scheduled call. You cannot cancel a call that has already started.
        /// </summary>
        /// <param name="call">The call identifier of the call to cancel.</param>
        /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
        public bool CancelCall(string call)
        {
            List<object> parameters = new List<object>() { call };
            JsonResponse response = this.client.MakeRequest("clicktocall/calls.cancel", parameters);
            return true;
        }

        /// <summary>
        /// This method lists calls for a specific Voice App.
        /// </summary>
        /// <param name="app">Voice App ID.</param>
        /// <param name="from">List calls between this date (inclusive).</param>
        /// <param name="to">And this date (inclusive).</param>
        /// <returns><see cref="ThecallrApi.Objects.ClickToCall.Call" /> object list.</returns>
        /// <seealso cref="ThecallrApi.Objects.ClickToCall.Call"/>
        public List<Call> GetCallList(string app, DateTime from, DateTime to)
        {
            List<object> parameters = new List<object>() { app, Tools.UtcDateString(from), Tools.UtcDateString(to) };
            JsonResponse response = this.client.MakeRequest("clicktocall/calls.get_list", parameters);
            return Helper.Creator<Call>.ObjectList(response.result, "result");
        }

        /// <summary>
        /// This method gets a call status.
        /// </summary>
        /// <param name="hash">Call identifier.</param>
        /// <returns><see cref="ThecallrApi.Objects.ClickToCall.Call" /> object.</returns>
        /// <seealso cref="ThecallrApi.Objects.ClickToCall.Call"/>
        public Call GetCallStatus(string hash)
        {
            List<object> parameters = new List<object>() { hash };
            JsonResponse response = this.client.MakeRequest("clicktocall/calls.get_status", parameters);
            return Helper.Creator<Call>.Object(response.result, "result");
        }

        /// <summary>
        /// This method starts 2 calls (party A, party B).
        /// </summary>
        /// <param name="app">The Click-to-Call Voice App ID.</param>
        /// <param name="a_targets">Party A targets.</param>
        /// <param name="b_targets">Party B targets.</param>
        /// <param name="options">Options.</param>
        /// <returns>The Call identifier.</returns>
        /// <seealso cref="ThecallrApi.Objects.Misc.Target"/>
        /// <seealso cref="ThecallrApi.Objects.ClickToCall.StartOptions"/>
        public string Start2Calls(string app, List<Target> a_targets, List<Target> b_targets, StartOptions options)
        {
            List<object> parameters = new List<object>() { app, a_targets, b_targets, options };
            JsonResponse response = this.client.MakeRequest("clicktocall/calls.start_2", parameters);
            return Helper.Converter<string>.ToObject(response.result, "result");
        }
        #endregion
    }
}
