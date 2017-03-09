using System;
using System.Collections.Generic;

namespace CallrApi.Enums
{
    /// <summary>
    /// This class defines all the types of voice applications.
    /// </summary>
    public static class ApplicationTypes
    {
        /// <summary>
        /// Call Tracking with call forwarding, prompts, and voicemail.
        /// </summary>
        public static readonly string CALLTRACKING = "CALLTRACKING10";

        /// <summary>
        /// Click-to-Call with dynamic parties and voicemail.
        /// </summary>
        public static readonly string CLICKTOCALL = "CLICKTOCALL10";

        /// <summary>
        /// Real-time app.
        /// </summary>
        public static readonly string REALTIME = "REALTIME10";
    }
}
