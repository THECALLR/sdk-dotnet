using System;
using System.Collections.Generic;

namespace ThecallrApi.Enums
{
    /// <summary>
    /// This class defines all the Click-To-Call call statuses.
    /// </summary>
    public static class ClickToCallCallStatuses
    {
        /// <summary>
        /// No answer.
        /// </summary>
        public static readonly string NOANSWER = "NOANSWER";

        /// <summary>
        /// The call was answered.
        /// </summary>
        public static readonly string ANSWER = "ANSWER";

        /// <summary>
        /// Voicemail detected.
        /// </summary>
        public static readonly string VOICEMAIL_DETECTED = "VOICEMAIL_DETECTED";

        /// <summary>
        /// The call was hangup.
        /// </summary>
        public static readonly string HANGUP = "HANGUP";

        /// <summary>
        /// The call was aborted because the other party hung up.
        /// </summary>
        public static readonly string ABORTED = "ABORTED";

        /// <summary>
        /// The call is being dialed.
        /// </summary>
        public static readonly string DIALING = "DIALING";
    }
}
