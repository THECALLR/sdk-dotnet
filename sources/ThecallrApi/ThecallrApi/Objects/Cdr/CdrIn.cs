using System.Collections.Generic;

namespace ThecallrApi.Objects.Cdr
{
    /// <summary>
    /// This class represents an Inbound Call Detail Records.
    /// </summary>
    public class CdrIn : Cdr
    {
        #region Member variables
        /// <summary>
        /// DID number Format.
        /// </summary>
        public string DidIntlNumber { get; set; }

        /// <summary>
        /// DID unique ID.
        /// </summary>
        public string DidHash { get; set; }

        /// <summary>
        /// CLI country code if available, ISO 3166-1 alpha-2 country code (eg “FR” for France).
        /// </summary>
        public string CliCountryCode { get; set; }

        /// <summary>
        /// CLI number type if available.
        /// </summary>
        public string CliNumberType { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            base.InitFromDictionary(dico);
            this.CliCountryCode = Helper.Converter<string>.ToObject(dico, "cli_country_code");
            this.CliNumberType = Helper.Converter<string>.ToObject(dico, "cli_number_type");
            this.DidIntlNumber = Helper.Converter<string>.ToObject(dico, "did_intl_number");
            this.DidHash = Helper.Converter<string>.ToObject(dico, "did_hash");
        }
        #endregion
    }
}
