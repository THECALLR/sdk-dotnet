
namespace CallrApi.Enums
{
    /// <summary>
    /// This class defines all outbound voicemail detection methods.
    /// </summary>
    public static class VoicemailDetectMethods
    {
        /// <summary>
        /// Silence detection. If we do not detect silence, it is probably a voicemail prompt.
        /// </summary>
        public static readonly string SILENCE = "SILENCE";

        /// <summary>
        /// The callee has to press a key to say "Hey I am here!".
        /// </summary>
        public static readonly string DTMF = "DTMF";
    }
}
