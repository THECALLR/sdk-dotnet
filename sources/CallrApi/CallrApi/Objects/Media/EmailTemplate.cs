using System.Collections.Generic;

namespace CallrApi.Objects.Media
{
    /// <summary>
    /// This class represents an email template.
    /// </summary>
    public class EmailTemplate : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Template ID.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Template type (possible values are defined in <see cref="CallrApi.Enums.MediaEmailTemplates"/> class).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        public string Name { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Hash = Helper.Converter<string>.ToObject(dico, "hash");
            this.Type = Helper.Converter<string>.ToObject(dico, "type");
            this.Name = Helper.Converter<string>.ToObject(dico, "name");
        }
        #endregion
    }
}
