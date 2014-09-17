using System;
using System.Collections.Generic;
using ThecallrApi.Enums;
using ThecallrApi.Helper;
using ThecallrApi.Json;
using ThecallrApi.Objects.Cdr;

namespace ThecallrApi.Services.Client
{
    /// <summary>
    /// This class allows CDR management.
    /// </summary>
    public class CdrService : ClientBaseService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public CdrService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public CdrService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method retrieves inbound CDR.
        /// </summary>
        /// <param name="from">Retrieve from this date (inclusive). </param>
        /// <param name="to">Retrive to this date (inclusive).</param>
        /// <param name="app">(Optional) Filter CDRs with this Voice App.</param>
        /// <param name="number">(Optional) Filter CDRs with DID.</param>
        /// <returns><see cref="ThecallrApi.Objects.Cdr.CdrIn" /> object list.</returns>
        /// <seealso cref="ThecallrApi.Objects.Cdr.CdrIn"/>
        /// <seealso cref="ThecallrApi.Enums.CdrTypes"/>
        public List<CdrIn> GetInboundCdrs(DateTime from, DateTime to, string app = null, string number = null)
        {
            List<object> parameters = new List<object>()
            {
                CdrTypes.IN,
                Tools.UtcDateString(from),
                Tools.UtcDateString(to),
                app,
                number
            };
            JsonResponse response = this.client.MakeRequest("cdr.get", parameters);
            return Helper.Creator<CdrIn>.ObjectList(response.result, "return");
        }

        /// <summary>
        /// This method retrieves outbound CDR.
        /// </summary>
        /// <param name="from">Retrieve from this date (inclusive). </param>
        /// <param name="to">Retrive to this date (inclusive).</param>
        /// <param name="app">(Optional) Filter CDRs with this Voice App.</param>
        /// <param name="number">(Optional) Filter CDRs with DID.</param>
        /// <returns><see cref="ThecallrApi.Objects.Cdr.CdrOut" /> object list.</returns>
        /// <seealso cref="ThecallrApi.Objects.Cdr.CdrOut"/>
        /// <seealso cref="ThecallrApi.Enums.CdrTypes"/>
        public List<CdrOut> GetOutboundCdrs(DateTime from, DateTime to, string app = null, string number = null)
        {
            List<object> parameters = new List<object>()
            {
                CdrTypes.OUT,
                Tools.UtcDateString(from),
                Tools.UtcDateString(to),
                app,
                number
            };
            JsonResponse response = this.client.MakeRequest("cdr.get", parameters);
            return Helper.Creator<CdrOut>.ObjectList(response.result, "return");
        }
        #endregion
    }
}
