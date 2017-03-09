using System.Collections.Generic;

namespace CallrApi.Objects.Sms
{
    /// <summary>
    /// This class represents SMS options.
    /// </summary>
    public class SmsOptions : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Send the SMS as a Flash Message (text will be shown on phone but not stored - not supported by all carriers and phone).
        /// </summary>
        public bool FlashMessage { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.FlashMessage = Helper.Converter<bool>.ToObject(dico, "flash_message");
        }
        #endregion
    }
}
