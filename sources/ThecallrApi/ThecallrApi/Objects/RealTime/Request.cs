using System.Collections.Generic;

namespace ThecallrApi.Objects.RealTime
{
    /// <summary>
    /// This class represents a Real-Time Request (Our POST to your server).
    /// </summary>
    public class Request
    {
        #region Member variables
        /// <summary>
        /// Voice App ID.
        /// </summary>
        public string app { get; set; }

        /// <summary>
        /// Call Unique ID (CDR).
        /// </summary>
        public int callid { get; set; }

        /// <summary>
        /// Outbound Request ID (if outbound call).
        /// </summary>
        public string request_hash { get; set; }

        /// <summary>
        /// CLI name.
        /// </summary>
        public string cli_name { get; set; }

        /// <summary>
        /// CLI number.
        /// </summary>
        public string cli_number { get; set; }

        /// <summary>
        /// DID/Outbound phone number.
        /// </summary>
        public string number { get; set; }

        /// <summary>
        /// The command name related to this request.
        /// </summary>
        public string command { get; set; }

        /// <summary>
        /// The command id related to this request.
        /// </summary>
        public int command_id { get; set; }

        /// <summary>
        /// The command result related to this request.
        /// </summary>
        public string command_result { get; set; }

        /// <summary>
        /// The command error (if any) related to this request.
        /// </summary>
        public string command_error { get; set; }

        /// <summary>
        /// Call status (possible values are defined in <see cref="ThecallrApi.Enums.RealTimeCallStatuses"/> class).
        /// </summary>
        public string call_status { get; set; }

        /// <summary>
        /// Key/Value object sent back with each request. You can use this as a session object.
        /// </summary>
        public Dictionary<string, object> variables { get; set; }

        /// <summary>
        /// When the call has started.
        /// </summary>
        public string date_started { get; set; }
        #endregion
    }
}
