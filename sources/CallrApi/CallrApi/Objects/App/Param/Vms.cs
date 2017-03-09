using System.Collections.Generic;

namespace CallrApi.Objects.App.Param
{
    /// <summary>
    /// This class represents a Voicemail
    /// </summary>
    public class Vms : BaseClass
    {
        #region Member variables
        /// <summary>
        /// If not activated, the call is hang up.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Media prompt.
        /// </summary>
        public int Intro { get; set; }

        /// <summary>
        /// File attachment format (possible values are defined in <see cref="CallrApi.Enums.VoicemailFileFormats"/> class).
        /// </summary>
        public string FileFormat { get; set; }

        /// <summary>
        /// File attachment name.
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// Email template.
        /// </summary>
        public string EmailTemplate { get; set; }

        /// <summary>
        /// If <c>false</c>, the call is hang up after playing the prompt.
        /// </summary>
        public bool Record { get; set; }

        /// <summary>
        /// Max recording length in seconds.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Locale used for date/time formatting.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Timezone IANA name.
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Email recipients.
        /// </summary>
        public List<string> Emails { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Active = Helper.Converter<bool>.ToObject(dico, "active");
            this.Intro = Helper.Converter<int>.ToObject(dico, "intro");
            this.FileFormat = Helper.Converter<string>.ToObject(dico, "file_format");
            this.FileName = Helper.Converter<string>.ToObject(dico, "file_name");
            this.EmailTemplate = Helper.Converter<string>.ToObject(dico, "email_template");
            this.Record = Helper.Converter<bool>.ToObject(dico, "record");
            this.Timeout = Helper.Converter<int>.ToObject(dico, "timeout");
            this.Locale = Helper.Converter<string>.ToObject(dico, "locale");
            this.Timezone = Helper.Converter<string>.ToObject(dico, "timezone");
            this.Emails = Helper.Converter<string>.ToObjectList(dico, "emails");
        }
        #endregion
    }
}
