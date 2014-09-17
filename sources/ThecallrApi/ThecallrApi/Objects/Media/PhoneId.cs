using System.Collections.Generic;

namespace ThecallrApi.Objects.Media
{
    /// <summary>
    /// This class represents a phone ID (DTMF sequence + phone number).
    ///</summary>
    public class PhoneId : BaseClass
    {
        #region Member variables
        /// <summary>
        /// DTMF sequence.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string Number { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Code = Helper.Converter<string>.ToObject(dico, "code");
            this.Number = Helper.Converter<string>.ToObject(dico, "number");
        }
        #endregion
    }
}
