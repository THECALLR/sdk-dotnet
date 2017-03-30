using System;
using System.Collections.Generic;

namespace CallrApi.Objects.Cdr
{
    /// <summary>
    /// This class represents a Call Detail Records.
    /// </summary>
    public class Cdr : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Unique call id.
        /// </summary>
        public int Callid { get; set; }

        /// <summary>
        /// CLI presentation (possible values are defined in <see cref="CallrApi.Enums.CliPresentations"/> class).
        /// </summary>
        public string CliPres { get; set; }

        /// <summary>
        /// CLI number if available.
        /// </summary>
        public string CliNumber { get; set; }

        /// <summary>
        /// CLI name if available.
        /// </summary>
        public string CliName { get; set; }

        /// <summary>
        /// Call start date and time.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Call answer date and time.
        /// </summary>
        public DateTime Answer { get; set; }

        /// <summary>
        /// Call hangup date and time.
        /// </summary>
        public DateTime Hangup { get; set; }

        /// <summary>
        /// Hangup source (possible values are defined in <see cref="CallrApi.Enums.CdrHangupSources"/> class).
        /// </summary>
        public string Hangupsource { get; set; }

        /// <summary>
        /// ISDN cause code.
        /// </summary>
        public string Hangupcause { get; set; }

        /// <summary>
        /// Call total duration in seconds.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Call answered duration in seconds.
        /// </summary>
        public int DurationAnswered { get; set; }

        /// <summary>
        /// Call billed duration in seconds.
        /// </summary>
        public int DurationBilled { get; set; }

        /// <summary>
        /// Billing destination name.
        /// </summary>
        public string BillingCustomerCostLabel { get; set; }

        /// <summary>
        /// Call debit in EUR cents.
        /// </summary>
        public decimal BillingCustomerDebitEur { get; set; }

        /// <summary>
        /// Call credit in EUR cents Format.
        /// </summary>
        public decimal BillingCustomerCreditEur { get; set; }

        /// <summary>
        /// Voice app name.
        /// </summary>
        public string ScenarioName { get; set; }

        /// <summary>
        /// Voice app ID.
        /// </summary>
        public string ScenarioHash { get; set; }

        /// <summary>
        /// Package name.
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// Custom CDR field.
        /// </summary>
        public string CustomerField { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Answer = Helper.Converter<DateTime>.ToObject(dico, "answer");
            this.BillingCustomerCostLabel = Helper.Converter<string>.ToObject(dico, "billing_customer_cost_label");
            this.BillingCustomerCreditEur = Helper.Converter<decimal>.ToObject(dico, "billing_customer_credit_eur");
            this.BillingCustomerDebitEur = Helper.Converter<decimal>.ToObject(dico, "billing_customer_debit_eur");
            this.Callid = Helper.Converter<int>.ToObject(dico, "callid");
            this.CliName = Helper.Converter<string>.ToObject(dico, "cli_name");
            this.CliNumber = Helper.Converter<string>.ToObject(dico, "cli_number");
            this.CliPres = Helper.Converter<string>.ToObject(dico, "cli_pres");
            this.CustomerField = Helper.Converter<string>.ToObject(dico, "customer_field");
            this.Duration = Helper.Converter<int>.ToObject(dico, "duration");
            this.DurationAnswered = Helper.Converter<int>.ToObject(dico, "duration_answered");
            this.DurationBilled = Helper.Converter<int>.ToObject(dico, "duration_billed");
            this.Hangup = Helper.Converter<DateTime>.ToObject(dico, "hangup");
            this.Hangupcause = Helper.Converter<string>.ToObject(dico, "hangupcause");
            this.Hangupsource = Helper.Converter<string>.ToObject(dico, "hangupsource");
            this.PackageName = Helper.Converter<string>.ToObject(dico, "package_name");
            this.ScenarioHash = Helper.Converter<string>.ToObject(dico, "scenario_hash");
            this.ScenarioName = Helper.Converter<string>.ToObject(dico, "scenario_name");
            this.Start = Helper.Converter<DateTime>.ToObject(dico, "start");
        }
        #endregion
    }
}
