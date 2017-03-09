using System.Collections.Generic;
using CallrApi.Objects.App.Param;

namespace CallrApi.Objects.ClickToCall
{
    /// <summary>
    /// This class represents a Click-to-Call with dynamic A/B parties.
    /// </summary>
    public class ClickToCall : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Medias.
        /// </summary>
        public ClickToCallMedia Medias { get; set; }

        /// <summary>
        /// Options.
        /// </summary>
        public ClickToCallOptions Options { get; set; }

        /// <summary>
        /// Voicemail for A if B does not answer.
        /// </summary>
        public Vms Vms { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Medias = Helper.Creator<ClickToCallMedia>.Object(dico, "medias");
            this.Options = Helper.Creator<ClickToCallOptions>.Object(dico, "options");
            this.Vms = Helper.Creator<Vms>.Object(dico, "vms");
        }
        #endregion
    }
}
