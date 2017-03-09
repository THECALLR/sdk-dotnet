using System.Collections.Generic;

namespace CallrApi.Objects.Misc
{
    /// <summary>
    /// This class represents number informations.
    /// </summary>
    public class NumberInfos : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Phone number type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Phone number in local format.
        /// </summary>
        public string LocalNumber { get; set; }

        /// <summary>
        /// Phone number in international format.
        /// </summary>
        public string IntlNumber { get; set; }

        /// <summary>
        /// International dial code.
        /// </summary>
        public string IntlCode { get; set; }

        /// <summary>
        /// Phone number minimum length.
        /// </summary>
        public int IntlMinLength { get; set; }

        /// <summary>
        /// Phone number maxmimum length.
        /// </summary>
        public int IntlMaxLength { get; set; }

        /// <summary>
        /// Local (in country) dial prefix.
        /// </summary>
        public string LocalPrefix { get; set; }

        /// <summary>
        /// Phone number location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Indicate if the phone number is correctly formatted.
        /// </summary>
        public bool IsValid { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.CountryCode = Helper.Converter<string>.ToObject(dico, "country_code");
            this.IntlCode = Helper.Converter<string>.ToObject(dico, "intl_code");
            this.IntlMaxLength = Helper.Converter<int>.ToObject(dico, "intl_max_length");
            this.IntlMinLength = Helper.Converter<int>.ToObject(dico, "intl_min_length");
            this.IntlNumber = Helper.Converter<string>.ToObject(dico, "intl_number");
            this.IsValid = Helper.Converter<bool>.ToObject(dico, "is_valid");
            this.LocalNumber = Helper.Converter<string>.ToObject(dico, "local_number");
            this.LocalPrefix = Helper.Converter<string>.ToObject(dico, "local_prefix");
            this.Location = Helper.Converter<string>.ToObject(dico, "location");
            this.Type = Helper.Converter<string>.ToObject(dico, "type");
        }
        #endregion
    }
}
