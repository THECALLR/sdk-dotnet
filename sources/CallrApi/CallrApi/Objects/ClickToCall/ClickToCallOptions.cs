using System.Collections.Generic;
using CallrApi.Objects.App.Param;

namespace CallrApi.Objects.ClickToCall
{
    /// <summary>
    /// This class represents Click-to-Call options.
    /// </summary>
    public class ClickToCallOptions : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Call attempts. Must be between 1 and 5.
        /// </summary>
        public int A_attempts { get; set; }

        /// <summary>
        /// Pause between attempts. Must be between 30 and 300.
        /// </summary>
        public int A_retrypause { get; set; }

        /// <summary>
        /// Outbound voicemail detection on A.
        /// </summary>
        public VmsDetect A_vms_detect { get; set; }

        /// <summary>
        /// Outbound voicemail detection on B.
        /// </summary>
        public VmsDetect B_vms_detect { get; set; }

        /// <summary>
        /// Active call recording.
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
            this.A_attempts = Helper.Converter<int>.ToObject(dico, "A_attempts");
            this.A_retrypause = Helper.Converter<int>.ToObject(dico, "A_retrypause");
            this.A_vms_detect = Helper.Creator<VmsDetect>.Object(dico, "A_vms_detect");
            this.B_vms_detect = Helper.Creator<VmsDetect>.Object(dico, "B_vms_detect");
            this.RecordCalls = Helper.Converter<bool>.ToObject(dico, "record_calls");
        }
        #endregion
    }
}
