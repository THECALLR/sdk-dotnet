using System;
using System.Collections.Generic;

namespace ThecallrApi.Enums
{
    /// <summary>
    /// This class defines all the Real Time call statuses.
    /// </summary>
    public static class RealTimeCallStatuses
    {
        /// <summary>
        /// The call is live.
        /// </summary>
        public static readonly string UP = "UP";

        /// <summary>
        /// The call just hung up.
        /// </summary>
        public static readonly string HANGUP = "HANGUP";

        /// <summary>
        /// Incoming call.
        /// </summary>
        public static readonly string INCOMING_CALL = "INCOMING_CALL";

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
        /// Our system rejected the call.
        /// </summary>
        public static readonly string REJECTED = "REJECTED";
    }
}
