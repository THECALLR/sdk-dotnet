
namespace CallrApi.Enums
{
    /// <summary>
    /// This class defines all Media Library/Recording Statuses.
    /// </summary>
    public static class MediaStatuses
    {
        /// <summary>
        /// Media ready.
        /// </summary>
        public static readonly string READY = "READY";

        /// <summary>
        /// Media is empty, pending content.
        /// </summary>
        public static readonly string PENDING_CONTENT = "PENDING_CONTENT";

        /// <summary>
        /// Content is set, pending conversion.
        /// </summary>
        public static readonly string PENDING_CONVERSION = "PENDING_CONVERSION";

        /// <summary>
        /// An error occured while processing the media.
        /// </summary>
        public static readonly string ERROR = "ERROR";

        /// <summary>
        /// Processing the media into internal formats.
        /// </summary>
        public static readonly string PROCESSING = "PROCESSING";
    }
}
