using System.Collections.Generic;
using CallrApi.Objects.App.Param;
using CallrApi.Objects.Misc;

namespace CallrApi.Objects.CallTracking
{
    /// <summary>
    /// This class represents Call Tracking with call forwarding, prompts, and voicemail.
    /// </summary>
    public class CallTracking : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Medias.
        /// </summary>
        public CallTrackingMedia Medias { get; set; }

        /// <summary>
        /// Options.
        /// </summary>
        public CallTrackingOptions Options { get; set; }

        /// <summary>
        /// Targets (Call forwarding).
        /// </summary>
        public List<Target> Targets { get; set; }

        /// <summary>
        /// Voicemail.
        /// </summary>
        public Vms Vms { get; set; }

        /// <summary>
        /// Google Analytics.
        /// </summary>
        public GA Ga { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Medias = Helper.Creator<CallTrackingMedia>.Object(dico, "medias");
            this.Options = Helper.Creator<CallTrackingOptions>.Object(dico, "options");
            this.Targets = Helper.Creator<Target>.ObjectList(dico, "targets");
            this.Vms = Helper.Creator<Vms>.Object(dico, "vms");
            this.Ga = Helper.Creator<GA>.Object(dico, "ga");
        }
        #endregion
    }
}
