using System;
using System.Collections.Generic;
using CallrApi.Helper;
using CallrApi.Json;
using CallrApi.Objects.RealTime;
using CallrApi.Objects.Misc;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class allows Dialr Service management.
    /// </summary>
    public class DialrService : ClientBaseService
    {
        #region Private members
        private NestedCall _call = null;
        #endregion

        #region Public members
        /// <summary>
        /// This class allows Dialr call management.
        /// </summary>
        public NestedCall Call
        {
            get
            {
                if (_call == null) _call = new NestedCall(this);
                return _call;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public DialrService(string url, string login, string password)
            : base(url, login, password)
        {}

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public DialrService(string login, string password)
            : this(null, login, password)
        {}
        #endregion

        #region Class dialr/call
        /// <summary>
        /// This class allows Media email management.
        /// </summary>
        public class NestedCall
        {
            #region Private members
            private DialrService Parent;
            #endregion

            #region Constructors
            /// <summary>
            /// Constructor.
            /// </summary>
            public NestedCall(DialrService parent)
            {
                this.Parent = parent;
            }
            #endregion

            #region Public methods
            /// <summary>
            /// This methods starts an outbound call on multiple targets.
            /// </summary>
            /// <param name="app">Voice App ID.</param>
            /// <param name="target">The phone number to call <see cref="CallrApi.Objects.Misc.Target" />.</param>
            /// <param name="options">Call options (CLI, CDR field...) <see cref="CallrApi.Objects.RealTime.RealTimeCallOptions" />.</param>
            /// <seealso cref="CallrApi.Objects.Misc.Target"/>
            public string RealTime(string app, Target target, RealTimeCallOptions options)
            {
                List<object> parameters = new List<object>() { app, target, options };
                JsonResponse response = this.Parent.client.MakeRequest("dialr/call.realtime", parameters);
                return Helper.Converter<string>.ToObject(response.result, "return");
            }
            #endregion
        }
        #endregion
    }
}
