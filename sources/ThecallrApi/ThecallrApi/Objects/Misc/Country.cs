using System.Collections.Generic;

namespace CallrApi.Objects.Misc
{
    /// <summary>
    /// This class represents a country.
    /// </summary>
    public class Country : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Country's Capital 3-letter code.
        /// </summary>
        public string CapitalCode { get; set; }

        /// <summary>
        /// Country's Code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Country name (uppercase) in French.
        /// </summary>
        public string CountryFrLabel { get; set; }

        /// <summary>
        /// Country name (uppercase) in English.
        /// </summary>
        public string CountryEnLabel { get; set; }

        /// <summary>
        /// Country name (lowercase) in English.
        /// </summary>
        public string CountryLabel { get; set; }

        /// <summary>
        /// Country's Continent 3-letter code
        /// </summary>
        public string ContinentCode { get; set; }

        /// <summary>
        /// Country's Currency.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Country's Top Level Domain (TLD).
        /// </summary>
        public string CountryTld { get; set; }

        /// <summary>
        /// Country's Languages.
        /// </summary>
        public string CountryLanguages { get; set; }

        /// <summary>
        /// Country's Neighbours comma separated.
        /// </summary>
        public string CountryNeighbours { get; set; }

        /// <summary>
        /// Country's Longitude.
        /// </summary>
        public decimal CountryLongitude { get; set; }

        /// <summary>
        /// Country's Latitude.
        /// </summary>
        public decimal CountryLatitude { get; set; }

        /// <summary>
        /// Country's E.164 Dialcode.
        /// </summary>
        public string CountryDialcode { get; set; }

        /// <summary>
        /// Country's Local code.
        /// </summary>
        public string CountryLocalcode { get; set; }

        /// <summary>
        /// Country's Phone Numbers Length.
        /// </summary>
        public int CountryNumberLength { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.CapitalCode = Helper.Converter<string>.ToObject(dico, "capital_code");
            this.ContinentCode = Helper.Converter<string>.ToObject(dico, "continent_code");
            this.CountryCode = Helper.Converter<string>.ToObject(dico, "country_code");
            this.CountryDialcode = Helper.Converter<string>.ToObject(dico, "country_dialcode");
            this.CountryEnLabel = Helper.Converter<string>.ToObject(dico, "country_en_label");
            this.CountryFrLabel = Helper.Converter<string>.ToObject(dico, "country_fr_label");
            this.CountryLabel = Helper.Converter<string>.ToObject(dico, "country_label");
            this.CountryLanguages = Helper.Converter<string>.ToObject(dico, "country_languages");
            this.CountryLatitude = Helper.Converter<decimal>.ToObject(dico, "country_latitude");
            this.CountryLocalcode = Helper.Converter<string>.ToObject(dico, "country_localcode");
            this.CountryLongitude = Helper.Converter<decimal>.ToObject(dico, "country_longitude");
            this.CountryNeighbours = Helper.Converter<string>.ToObject(dico, "country_neighbours");
            this.CountryNumberLength = Helper.Converter<int>.ToObject(dico, "country_number_length");
            this.CountryTld = Helper.Converter<string>.ToObject(dico, "country_tld");
            this.CurrencyCode = Helper.Converter<string>.ToObject(dico, "currency_code");
        }
        #endregion
    }
}
