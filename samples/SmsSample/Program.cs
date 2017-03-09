using System;
using System.Collections.Generic;
using CallrApi.Exception;
using CallrApi.Helper;
using CallrApi.Services.Client;
using CallrApi.Objects.Sms;

namespace CallrApi.Samples.SmsSample
{
    /// <summary>
    /// This class gives an example of SMS manipulation.
    /// </summary>
    class Program
    {
        /// <summary>
        /// API connexion login.
        /// </summary>
        /// <remarks>You must have received it when you subscribed.</remarks>
        private string login = "";

        /// <summary>
        /// API connexion password.
        /// </summary>
        /// <remarks>You must have received it when you subscribed.</remarks>
        private string password = "";

        /// <summary>
        /// This method shows you how to send an SMS.
        /// </summary>
        public void SendSms()
        {
            try
            {
                // SMS sender must be alphanumeric (at least one character - cannot be digits only). Max length = 11 characters
                string sender = "SMS";

                // Mobile number you want to send an sms to (E.164 format)
                string mobile_number = "__PHONE_NUMBER__";

                // Sms content
                string message = "This is my first SMS with CALLR API!";

                // SMS Options
                SmsOptions options = new SmsOptions();
                options.FlashMessage = false;

                SmsService service = new SmsService(this.login, this.password);

                // Send the SMS to the specified mobile number
                string sms_id = service.Send(sender, mobile_number, message, options);

                // Display the result
                Console.WriteLine("SMS ID: {0}", sms_id);
            }
            catch (RemoteApiException api_ex)
            {
                // An API error is returned
                Console.WriteLine("#REMOTE# {0} : {1}", api_ex.Code, api_ex.Message);
            }
            catch (LocalApiException api_ex)
            {
                // A library error is returned
                Console.WriteLine("#LOCAL# {0}", api_ex.Message);
            }
            catch (System.Exception ex)
            {
                // An uncaught error is returned
                Console.WriteLine("~UNCAUGHT~ {0}", ex.Message);
            }
        }

        /// <summary>
        /// This method shows you how to retrieve sent SMS from the beginning of the day.
        /// </summary>
        public void ListSentSms()
        {
            try
            {
                SmsService service = new SmsService(this.login, this.password);
                // Retrieve today sms
                // The SDK assumes that the dates specified use the CurrentCulture
                List<Sms> sms_list = service.GetOutList(DateTime.Today, DateTime.Now);
                // Display the result
                Console.WriteLine(Tools.ObjectDump(sms_list));
            }
            catch (RemoteApiException api_ex)
            {
                // An API error is returned
                Console.WriteLine("#REMOTE# {0} : {1}", api_ex.Code, api_ex.Message);
            }
            catch (LocalApiException api_ex)
            {
                // A library error is returned
                Console.WriteLine("#LOCAL# {0}", api_ex.Message);
            }
            catch (System.Exception ex)
            {
                // An uncaught error is returned
                Console.WriteLine("~UNCAUGHT~ {0}", ex.Message);
            }
        }

        /// <summary>
        /// Entry point.
        /// </summary>
        /// <remarks>Uncomment the method you want to test.</remarks>
        static void Main()
        {
            // TODO : Don't forget to fill login and password in App.config file
            Program prog = new Program();

            // Create a new SMS
            //prog.SendSms();

            // List sent SMS
            //prog.ListSentSms();
        }
    }
}
