using System.Collections.Generic;

namespace CallrApi.Objects.Misc
{
    /// <summary>
    /// This class represents a Timezone.
    /// </summary>
    public class Timezone : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Timezone ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Timezone name.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// PHP/IANA timezone name.
        /// </summary>
        public string PhpName { get; set; }

        /// <summary>
        /// Indicate if the timezone is subject to Daylight Saving Time.
        /// </summary>
        public string Dst { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Dst = Helper.Converter<string>.ToObject(dico, "dst");
            this.Id = Helper.Converter<int>.ToObject(dico, "id");
            this.Label = Helper.Converter<string>.ToObject(dico, "label");
            this.PhpName = Helper.Converter<string>.ToObject(dico, "php_name");
        }
        #endregion
    }
}
