using System.Collections.Generic;

namespace CallrApi.Objects.App
{
    /// <summary>
    /// This class reresents a voice app package.
    /// </summary>
    public class Package : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Package name (possible values are defined in <see cref="CallrApi.Enums.ApplicationTypes"/> class).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Package type (possible values are defined in <see cref="CallrApi.Enums.ApplicationPackageTypes"/> class).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Determines if the Voice App can be assigned a DID.
        /// </summary>
        public bool HasDid { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Name = Helper.Converter<string>.ToObject(dico, "name");
            this.Type = Helper.Converter<string>.ToObject(dico, "type");
            this.HasDid = Helper.Converter<bool>.ToObject(dico, "has_did");
        }
        #endregion
    }
}
