using System.Collections.Generic;

namespace CallrApi.Objects.CallTracking
{
    /// <summary>
    /// This class represents a CallTracking Google Analytics.
    /// </summary>
    public class GA : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Google Analytics Web Property ID.
        /// </summary>
        public string Ua { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Ua = Helper.Converter<string>.ToObject(dico, "ua");
        }
        #endregion
    }
}
