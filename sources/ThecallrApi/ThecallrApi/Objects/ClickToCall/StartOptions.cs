using System;
using System.Collections.Generic;

namespace CallrApi.Objects.ClickToCall
{
    /// <summary>
    /// This class represents Click To Call start options.
    /// </summary>
    public class StartOptions : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Scheduled time of the call.
        /// </summary>
        public DateTime Schedule { get; set; }

        /// <summary>
        /// Cli used to call A.
        /// </summary>
        public string Cli { get; set; }

        /// <summary>
        /// Custom CDR field.
        /// </summary>
        public string CdrField { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Schedule = Helper.Converter<DateTime>.ToObject(dico, "schedule");
            this.Cli = Helper.Converter<string>.ToObject(dico, "cli");
            this.CdrField = Helper.Converter<string>.ToObject(dico, "cdr_field");
        }
        #endregion
    }
}
