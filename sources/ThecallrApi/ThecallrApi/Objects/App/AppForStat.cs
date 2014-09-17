using System.Collections.Generic;

namespace ThecallrApi.Objects.App
{
    /// <summary>
    /// This class represents a simple Voice App.
    /// </summary>
    public class AppForStat : BaseClass
    {
        #region Member variables
        /// <summary>
        /// App unique ID.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// App name.
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
            this.Name = Helper.Converter<string>.ToObject(dico, "name");
        } 
        #endregion
    }
}
