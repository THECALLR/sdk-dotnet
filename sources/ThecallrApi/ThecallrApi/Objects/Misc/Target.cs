using System.Collections.Generic;

namespace ThecallrApi.Objects.Misc
{
    /// <summary>
    /// This class represents a Target (Phone number + timeout).
    /// </summary>
    public class Target : BaseClass
    {
        #region Member variables
        /// <summary>
        /// The phone number to dial.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Ringing timeout in seconds. Must be between 5 and 300.
        /// </summary>
        public int Timeout { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Number = Helper.Converter<string>.ToObject(dico, "number");
            this.Timeout = Helper.Converter<int>.ToObject(dico, "timeout");
        }
        #endregion
    }
}
