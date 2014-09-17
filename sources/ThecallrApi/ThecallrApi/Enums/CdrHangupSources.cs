using System;
using System.Collections.Generic;

namespace ThecallrApi.Enums
{
    /// <summary>
    /// This class defines all hangup sources.
    /// </summary>
    public static class CdrHangupSources
    {
        /// <summary>
        /// The call was hungup by our gateway.
        /// </summary>
        public static readonly string GATEWAY = "GATEWAY";

        /// <summary>
        /// The caller hung up the call.
        /// </summary>
        public static readonly string CALLER = "CALLER";

        /// <summary>
        /// The callee hung up the call.
        /// </summary>
        public static readonly string CALLEE = "CALLEE";
    }
}
