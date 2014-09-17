using System;
using System.Collections.Generic;

namespace ThecallrApi.Enums
{
    /// <summary>
    /// This class defines all the authorized CLIs.
    /// </summary>
    public static class CliAuthTypes
    {
        /// <summary>
        /// Authorized for calls.
        /// </summary>
        public static readonly string CALL = "CALL";

        /// <summary>
        /// Authorized for SMS.
        /// </summary>
        public static readonly string SMS = "SMS";
    }
}
