using System.Collections.Generic;

namespace CallrApi.Objects.Cdr
{
    /// <summary>
    /// This class represents an Outbound Call Detail Records.
    /// </summary>
    public class CdrOut : Cdr
    {
        #region Member variables
        /// <summary>
        /// Inbound call ID if available.
        /// </summary>
        public int CallidIn { get; set; }

        /// <summary>
        /// Outbound number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Number country code, ISO 3166-1 alpha-2 country code (eg “FR” for France).
        /// </summary>
        public string NumberCountryCode { get; set; }

        /// <summary>
        /// Number type.
        /// </summary>
        public string NumberType { get; set; }

        /// <summary>
        /// Call state (possible values are defined in <see cref="CallrApi.Enums.DialStatuses"/> class).
        /// </summary>
        public string Dialstatus { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            base.InitFromDictionary(dico);
            this.CallidIn = Helper.Converter<int>.ToObject(dico, "callid_in");
            this.Dialstatus = Helper.Converter<string>.ToObject(dico, "dialstatus");
            this.Number = Helper.Converter<string>.ToObject(dico, "number");
            this.NumberCountryCode = Helper.Converter<string>.ToObject(dico, "number_country_code");
            this.NumberType = Helper.Converter<string>.ToObject(dico, "number_type");
        }
        #endregion
    }
}
