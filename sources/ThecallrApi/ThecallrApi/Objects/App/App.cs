using System;
using System.Collections.Generic;
using CallrApi.Enums;
using CallrApi.Objects.RealTime;

namespace CallrApi.Objects.App
{
    /// <summary>
    /// This class represents a Voice App.
    /// </summary>
    public class App : AppForStat
    {
        #region Member variables
        /// <summary>
        /// Call Tracking object.
        /// </summary>
        /// <remarks>Set only if it's a Call Tracking App.</remarks>
        public CallTracking.CallTracking Ct { get; set; }

        /// <summary>
        /// ClickToCall object.
        /// </summary>
        /// <remarks>Set only if it's a ClickToCall App.</remarks>
        public ClickToCall.ClickToCall Ctc { get; set; }

        /// <summary>
        /// RealTime object.
        /// </summary>
        /// <remarks>Set only if it's a RealTime App.</remarks>
        public RealTime.RealTime Rt { get; set; }

        /// <summary>
        /// DIDs assigned to the App.
        /// </summary>
        public List<Did.Did> Did { get; set; }

        /// <summary>
        /// App package.
        /// </summary>
        public Package Package { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Date of last update.
        /// </summary>
        public DateTime DateUpdate { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            base.InitFromDictionary(dico);

            this.Did = Helper.Creator<Did.Did>.ObjectList(dico, "did");
            this.Package = Helper.Creator<Package>.Object(dico, "package");
            this.DateCreation = Helper.Converter<DateTime>.ToObject(dico, "date_creation");
            this.DateUpdate = Helper.Converter<DateTime>.ToObject(dico, "date_update");
            if (this.Package != null)
            {
                if (this.Package.Name == ApplicationTypes.CALLTRACKING)
                    this.Ct = Helper.Creator<CallTracking.CallTracking>.Object(dico, "p");
                else if (this.Package.Name == ApplicationTypes.CLICKTOCALL)
                    this.Ctc = Helper.Creator<ClickToCall.ClickToCall>.Object(dico, "p");
                else if (this.Package.Name == ApplicationTypes.REALTIME)
                    this.Rt = Helper.Creator<RealTime.RealTime>.Object(dico, "p");
            }
        }
        #endregion
    }
}
