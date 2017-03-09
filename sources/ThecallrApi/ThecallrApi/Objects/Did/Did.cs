using System.Collections.Generic;

namespace CallrApi.Objects.Did
{
    /// <summary>
    /// This class represents a DID.
    /// </summary>
    public class Did : DidForStat
    {
        #region Member variables
        /// <summary>
        /// DID class (possible values are defined in <see cref="CallrApi.Enums.DidClasses"/> class).
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// DID type (possible values are defined in <see cref="CallrApi.Enums.DidTypes"/> class).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// DID country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Voice app ID assigned to the DID (null if no app assigned).
        /// </summary>
        public string App { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            base.InitFromDictionary(dico);
            this.Class = Helper.Converter<string>.ToObject(dico, "class");
            this.Type = Helper.Converter<string>.ToObject(dico, "type");
            this.CountryCode = Helper.Converter<string>.ToObject(dico, "country_code");
            this.App = Helper.Converter<string>.ToObject(dico, "app");
        }
        #endregion
    }
}
