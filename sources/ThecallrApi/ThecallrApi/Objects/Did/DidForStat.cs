using System.Collections.Generic;

namespace ThecallrApi.Objects.Did
{
    /// <summary>
    /// This class represents a simple DID.
    /// </summary>
    public class DidForStat : BaseClass
    {
        #region Member variables
        /// <summary>
        /// DID ID.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Phone number in local format.
        /// </summary>
        public string LocalNumber { get; set; }

        /// <summary>
        /// Phone number in international format.
        /// </summary>
        public string IntlNumber { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Hash = Helper.Converter<string>.ToObject(dico, "hash");
            this.LocalNumber = Helper.Converter<string>.ToObject(dico, "local_number");
            this.IntlNumber = Helper.Converter<string>.ToObject(dico, "intl_number");
        }
        #endregion
    }
}
