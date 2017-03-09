using System;
using System.Collections.Generic;

namespace CallrApi.Enums
{
    /// <summary>
    /// This class defines outbound dial statuses.
    /// </summary>
    public static class DialStatuses
    {
        /// <summary>
        /// The call was answered.
        /// </summary>
        public static readonly string ANSWER = "ANSWER";

        /// <summary>
        /// The call was not answered during given time.
        /// </summary>
        public static readonly string NOANSWER = "NOANSWER";

        /// <summary>
        /// The call was refused by a carrier (not us).
        /// </summary>
        public static readonly string CONGESTION = "CONGESTION";

        /// <summary>
        /// The target number is busy (not us).
        /// </summary>
        public static readonly string BUSY = "BUSY";

        /// <summary>
        /// The call was canceled (because the caller hung up).
        /// </summary>
        public static readonly string CANCEL = "CANCEL";

        /// <summary>
        /// The cal was refused by a carrier (not us).
        /// </summary>
        public static readonly string CHANUNAVAIL = "CHANUNAVAIL";

        /// <summary>
        /// The call was canceled while dialing.
        /// </summary>
        public static readonly string NODIAL = "NODIAL";
    }
}
