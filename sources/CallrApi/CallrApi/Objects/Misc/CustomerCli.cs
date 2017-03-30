using System.Collections.Generic;

namespace CallrApi.Objects.Misc
{
    /// <summary>
    /// This class represents authorized Customer CLI.
    /// </summary>
    public class CustomerCli : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Phone number/SMS Sender authorized.
        /// </summary>
        public string Cli { get; set; }

        /// <summary>
        /// Custom comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Custom label.
        /// </summary>
        public string Label { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Cli = Helper.Converter<string>.ToObject(dico, "cli");
            this.Comment = Helper.Converter<string>.ToObject(dico, "comment");
            this.Label = Helper.Converter<string>.ToObject(dico, "label");
        }
        #endregion
    }
}
