using System;
using System.Collections.Generic;
using CallrApi.Objects.Misc;

namespace CallrApi.Objects.ClickToCall
{
    /// <summary>
    /// This class represents a Click-to-Call Call.
    /// </summary>
    public class Call : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Party A call status.
        /// </summary>
        public CallStatus AStatus { get; set; }

        /// <summary>
        /// Targets called first ("A").
        /// </summary>
        public List<Target> ATargets { get; set; }

        /// <summary>
        /// Voice App.
        /// </summary>
        public App.App App { get; set; }

        /// <summary>
        /// Party B call status.
        /// </summary>
        public CallStatus BStatus { get; set; }

        /// <summary>
        /// Targets called second ("B").
        /// </summary>
        public List<Target> BTargets { get; set; }

        /// <summary>
        /// Custom CDR field.
        /// </summary>
        public string CdrField { get; set; }

        /// <summary>
        /// CLI presented to party A. Party B will see the party A target number that answered the call.
        /// </summary>
        public string Cli { get; set; }

        /// <summary>
        /// Date and time of creation.
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Date and time scheduled.
        /// </summary>
        public DateTime DateScheduled { get; set; }

        /// <summary>
        /// Date and time started.
        /// </summary>
        public DateTime DateStarted { get; set; }

        /// <summary>
        /// Date and time of last update.
        /// </summary>
        public DateTime DateUpdate { get; set; }

        /// <summary>
        /// Call unique ID.
        /// </summary>
        public string Hash { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.AStatus = Helper.Creator<CallStatus>.Object(dico, "a_status");
            this.ATargets = Helper.Creator<Target>.ObjectList(dico, "a_targets");
            this.App = Helper.Creator<App.App>.Object(dico, "app");
            this.BStatus = Helper.Creator<CallStatus>.Object(dico, "b_status");
            this.BTargets = Helper.Creator<Target>.ObjectList(dico, "b_targets");
            this.CdrField = Helper.Converter<string>.ToObject(dico, "cdr_field");
            this.Cli = Helper.Converter<string>.ToObject(dico, "cli");
            this.DateCreation = Helper.Converter<DateTime>.ToObject(dico, "date_creation");
            this.DateScheduled = Helper.Converter<DateTime>.ToObject(dico, "date_scheduled");
            this.DateStarted = Helper.Converter<DateTime>.ToObject(dico, "date_started");
            this.DateUpdate = Helper.Converter<DateTime>.ToObject(dico, "date_update");
            this.Hash = Helper.Converter<string>.ToObject(dico, "hash");
        }
        #endregion
    }
}
