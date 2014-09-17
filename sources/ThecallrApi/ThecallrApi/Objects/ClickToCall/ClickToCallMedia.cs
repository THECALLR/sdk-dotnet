using System.Collections.Generic;

namespace ThecallrApi.Objects.ClickToCall
{
    /// <summary>
    /// This class represents a Click-to-Call media.
    /// </summary>
    public class ClickToCallMedia : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Played to A while calling B.
        /// </summary>
        public int A_ringtone { get; set; }

        /// <summary>
        /// Played to A immediately.
        /// </summary>
        public int A_welcome { get; set; }

        /// <summary>
        /// Played to both parties before bridging the call.
        /// </summary>
        public int AB_bridge { get; set; }

        /// <summary>
        /// Played to B only (A still hears the ringtone).
        /// </summary>
        public int B_whisper { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.A_ringtone = Helper.Converter<int>.ToObject(dico, "A_ringtone");
            this.A_welcome = Helper.Converter<int>.ToObject(dico, "A_welcome");
            this.AB_bridge = Helper.Converter<int>.ToObject(dico, "AB_bridge");
            this.B_whisper = Helper.Converter<int>.ToObject(dico, "B_whisper");
        }
        #endregion
    }
}
