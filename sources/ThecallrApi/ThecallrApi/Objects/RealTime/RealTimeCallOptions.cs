using System.Collections.Generic;

namespace ThecallrApi.Objects.RealTime
{
    /// <summary>
    /// 
    /// </summary>
    public class RealTimeCallOptions
    {
        #region Member variables
        /// <summary>
        /// Custom field written in the CDR.
        /// Format: cdr_customer_field (32 alphanumeric characters maximum)
        /// </summary>
        public string cdr_field { get; set; }

        /// <summary>
        /// Calling Line Identification. Can be "BLOCKED", any DID you have on your account, or any phone number we have authorized on your account.
        /// Format: cli_phone_number (International E.164 format "+CCNSN". Example: "+33123456789" or "BLOCKED")
        /// </summary>
        public string cli { get; set; }
        #endregion
    }
}
