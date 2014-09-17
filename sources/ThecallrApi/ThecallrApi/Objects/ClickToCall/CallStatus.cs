using System.Collections.Generic;

namespace ThecallrApi.Objects.ClickToCall
{
    /// <summary>
    /// This class represents a Click-to-Call Call status.
    /// </summary>
    public class CallStatus : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Call Unique ID (CDR).
        /// </summary>
        public int Callid { get; set; }

        /// <summary>
        /// The number dialing or answered.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Call status (possible values are defined in <see cref="ThecallrApi.Enums.ClickToCallCallStatuses"/> class).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Call try.
        /// </summary>
        public int Try { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Callid = Helper.Converter<int>.ToObject(dico, "callid");
            this.Number = Helper.Converter<string>.ToObject(dico, "number");
            this.Status = Helper.Converter<string>.ToObject(dico, "status");
            this.Try = Helper.Converter<int>.ToObject(dico, "try");
        }
        #endregion
    }
}
