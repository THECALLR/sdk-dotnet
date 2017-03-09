
namespace CallrApi.Enums
{
    /// <summary>
    /// This class defines all the SMS statuses.
    /// </summary>
    public static class SmsStatuses
    {
        /// <summary>
        /// Message created on our side.
        /// </summary>
        public static readonly string CREATED = "CREATED";

        /// <summary>
        /// Message is being sent.
        /// </summary>
        public static readonly string PENDING = "PENDING";

        /// <summary>
        /// Message sent, but not received.
        /// </summary>
        public static readonly string SENT = "SENT";

        /// <summary>
        /// Generic error.
        /// </summary>
        public static readonly string ERROR = "ERROR";

        /// <summary>
        /// Message received.
        /// </summary>
        public static readonly string RECEIVED = "RECEIVED";

        /// <summary>
        /// Message is being delivered.
        /// </summary>
        public static readonly string REMOTE_QUEUED = "REMOTE_QUEUED";

        /// <summary>
        /// Message timed out.
        /// </summary>
        public static readonly string EXPIRED = "EXPIRED";
    }
}
