using System.Collections.Generic;

namespace ThecallrApi.Objects.App.Param
{
    /// <summary>
    /// This class represents Outbound Voicemail Detection.
    /// </summary>
    public class VmsDetect : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Active ?
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// When using the DTMF method, how many times do we try to have a DTMF ? (default: 2).
        /// </summary>
        public int DtmfIterations { get; set; }

        /// <summary>
        /// When using the DTMF method, Media played before detection (default: 0).
        /// </summary>
        public int DtmfMedia { get; set; }

        /// <summary>
        /// When using the DTMF method, how long do we wait for a DTMF to be sent ? (default: 2).
        /// </summary>
        public int DtmfTimeout { get; set; }

        /// <summary>
        /// Detection method (possible values are defined in <see cref="ThecallrApi.Enums.VoicemailDetectMethods"/> class).
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// When using the SILENCE method, how many times do we try ? (default: 1, min: 1, max: 30).
        /// </summary>
        public int SilenceIterations { get; set; }

        /// <summary>
        /// When using the SILENCE method, Media played before detection (default: 0).
        /// </summary>
        public int SilenceMedia { get; set; }

        /// <summary>
        /// When using the SILENCE method, how long must be the silence in milliseconds ? (default: 1800, min: 50, max: 10000).
        /// </summary>
        public int SilenceMs { get; set; }

        /// <summary>
        /// When using the SILENCE method, how long do we try to detect silence ? (default: 3, min: 0, max: 120).
        /// </summary>
        public int SilenceTimeout { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Active = Helper.Converter<bool>.ToObject(dico, "active");
            this.DtmfIterations = Helper.Converter<int>.ToObject(dico, "dtmf_iterations");
            this.DtmfMedia = Helper.Converter<int>.ToObject(dico, "dtmf_media");
            this.DtmfTimeout = Helper.Converter<int>.ToObject(dico, "dtmf_timeout");
            this.Method = Helper.Converter<string>.ToObject(dico, "method");
            this.SilenceIterations = Helper.Converter<int>.ToObject(dico, "silence_iterations");
            this.SilenceMedia = Helper.Converter<int>.ToObject(dico, "silence_media");
            this.SilenceMs = Helper.Converter<int>.ToObject(dico, "silence_ms");
            this.SilenceTimeout = Helper.Converter<int>.ToObject(dico, "silence_timeout");
        }
        #endregion
    }
}
