using System;
using System.Collections.Generic;

namespace ThecallrApi.Objects.Sms
{
    /// <summary>
    /// This class represents a SMS text message.
    /// </summary>
    public class Sms : BaseClass
    {
        #region Member variables
        /// <summary>
        /// SMS type (possible values are defined in <see cref="ThecallrApi.Enums.SmsTypes"/> class).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// SMS ID.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Sender.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Recipient.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// SMS content.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// SMS options.
        /// </summary>
        public SmsOptions Options { get; set; }

        /// <summary>
        /// Billing mode (possible values are defined in <see cref="ThecallrApi.Enums.BillingModes"/> class).
        /// </summary>
        public string BCustomerMode { get; set; }

        /// <summary>
        /// Amount debited.
        /// </summary>
        public decimal BCustomerDebit { get; set; }

        /// <summary>
        /// SMS status (possible values are defined in <see cref="ThecallrApi.Enums.SmsStatuses"/> class).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Descriptive error if status is "ERROR".
        /// </summary>
        public string StatusError { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Date of last update (status update).
        /// </summary>
        public DateTime DateUpdate { get; set; }

        /// <summary>
        /// Sent date (if sent).
        /// </summary>
        public DateTime DateSent { get; set; }

        /// <summary>
        /// Received date (if received).
        /// </summary>
        public DateTime DateReceived { get; set; }

        /// <summary>
        /// Number of SMS parts billed. May be > 1 if your text is too long.
        /// </summary>
        public int Parts { get; set; }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Type = Helper.Converter<string>.ToObject(dico, "type");
            this.Hash = Helper.Converter<string>.ToObject(dico, "hash");
            this.From = Helper.Converter<string>.ToObject(dico, "from");
            this.To = Helper.Converter<string>.ToObject(dico, "to");
            this.Text = Helper.Converter<string>.ToObject(dico, "text");
            this.Options = Helper.Creator<SmsOptions>.Object(dico, "options");
            this.BCustomerMode = Helper.Converter<string>.ToObject(dico, "b_customer_mode");
            this.BCustomerDebit = Helper.Converter<decimal>.ToObject(dico, "b_customer_debit");
            this.Status = Helper.Converter<string>.ToObject(dico, "status");
            this.StatusError = Helper.Converter<string>.ToObject(dico, "status_error");
            this.DateCreation = Helper.Converter<DateTime>.ToObject(dico, "date_creation");
            this.DateUpdate = Helper.Converter<DateTime>.ToObject(dico, "date_update");
            this.DateSent = Helper.Converter<DateTime>.ToObject(dico, "date_sent");
            this.DateReceived = Helper.Converter<DateTime>.ToObject(dico, "date_received");
            this.Parts = Helper.Converter<int>.ToObject(dico, "parts");
        }
        #endregion
    }
}
