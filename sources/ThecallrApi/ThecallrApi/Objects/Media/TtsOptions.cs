using System.Collections.Generic;

namespace ThecallrApi.Objects.Media
{
    /// <summary>
    /// This class represents Media Text-to-Speech Options.
    /// </summary>
    public class TtsOptions : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Speech rate. min:0 max:100 default:50.
        /// </summary>
        public int Rate { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Rate = Helper.Converter<int>.ToObject(dico, "rate");
        }
        #endregion
    }
}
