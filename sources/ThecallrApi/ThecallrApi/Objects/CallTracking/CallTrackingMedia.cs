using System.Collections.Generic;

namespace ThecallrApi.Objects.CallTracking
{
    /// <summary>
    /// This class represents a Call Tracking media.
    /// </summary>
    public class CallTrackingMedia : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Played immediately to the caller.
        /// </summary>
        public int Welcome { get; set; }

        /// <summary>
        /// Played while the target is ringing.
        /// </summary>
        public int Ringtone { get; set; }

        /// <summary>
        /// Played to the target only (callee whispering).
        /// </summary>
        public int Whisper { get; set; }

        /// <summary>
        /// Played to both parties before bridging the call.
        /// </summary>
        public int Bridge { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Welcome = Helper.Converter<int>.ToObject(dico, "welcome");
            this.Ringtone = Helper.Converter<int>.ToObject(dico, "ringtone");
            this.Whisper = Helper.Converter<int>.ToObject(dico, "whisper");
            this.Bridge = Helper.Converter<int>.ToObject(dico, "bridge");
        }
        #endregion
    }
}
