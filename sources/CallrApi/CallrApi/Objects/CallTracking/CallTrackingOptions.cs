using System.Collections.Generic;

namespace CallrApi.Objects.CallTracking
{
    /// <summary>
    /// This class represents Call Tracking options.
    /// </summary>
    public class CallTrackingOptions : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Activate call recording.
        /// </summary>
        public bool RecordCalls { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.RecordCalls = Helper.Converter<bool>.ToObject(dico, "record_calls");
        }
        #endregion
    }
}
