using System;
using System.Collections.Generic;

namespace CallrApi.Enums
{
    /// <summary>
    /// This class defines all the categories of Media Library.
    /// </summary>
    public static class MediaLibraryCategories
    {
        /// <summary>
        /// Failure related Media.
        /// </summary>
        public static readonly string FAILURE = "FAILURE";

        /// <summary>
        /// Welcoming Media.
        /// </summary>
        public static readonly string WELCOME = "WELCOME";

        /// <summary>
        /// Music and other ringing Media.
        /// </summary>
        public static readonly string RINGTONE = "RINGTONE";

        /// <summary>
        /// Voicemail related.
        /// </summary>
        public static readonly string VOICEMAIL = "VOICEMAIL";

        /// <summary>
        /// Miscellaneous.
        /// </summary>
        public static readonly string MISC = "MISC";

        /// <summary>
        /// IVR related.
        /// </summary>
        public static readonly string IVR = "IVR";

        /// <summary>
        /// Whispering.
        /// </summary>
        public static readonly string WHISPER = "WHISPER";
    }
}
