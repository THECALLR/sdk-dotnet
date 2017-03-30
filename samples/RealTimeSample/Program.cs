using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CallrApi.Enums;
using CallrApi.Exception;
using CallrApi.Objects.App;
using CallrApi.Objects.Did;
using CallrApi.Objects.Misc;
using CallrApi.Objects.RealTime;
using CallrApi.Services.Client;

namespace RealTimeSample
{
    /// <summary>
    /// This class gives an example of Real Time call control.
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
        /// This method shows you how to configure Real Time with outbound calls.
        /// </summary>
        public void RealTimeWithOutboundCall()
        {
            try
            {
                // 1 - Create a Dialer app
                // Application name
                string application_name = "My first Dialer app with outbound call";

                // Webservice access parameters
                RealTime rt = new RealTime();
                rt.DataFormat = RealTimeDataFormats.JSON; // Data format. The only format supported right now is "JSON"
                rt.Url = "http://__YOUR_SERVER_HOST__/RealTime.aspx"; // Your URL callback. Our system will POST call status to your URL, and your answers will control the call
                rt.Login = ""; // Login if your URL is password protected (HTTP Basic Authentication)
                rt.Password = ""; // Password If your URL is password protected (HTTP Basic Authentication)

                // Init services
                DialrService dialr = new DialrService(this.login, this.password);
                AppsService appServ = new AppsService(this.login, this.password);

                // Create the app
                App app = appServ.Create(ApplicationTypes.REALTIME, application_name, rt);
                string app_id = app.Hash;

                // 2 - Make an outbound call from CALLR
                // Specify first callee phone number(s) declaration
                Target target = new Target();
                target.Number = "+33123456789";
                target.Timeout = 20;

                RealTimeCallOptions opt = new RealTimeCallOptions();
                // Specify calling Line Identification. Can be "BLOCKED", any DID you have on your account, or any phone we have previously authorized on your account
                opt.cli = "BLOCKED";
                // Specify a custom field visible in CDR (can be used to tag calls)
                opt.cdr_field = "myDialrField";

                // 3 - Start the call
                string call_id = dialr.Call.RealTime(app_id, target, opt);

                // Display the result
                Console.WriteLine("Call ID: {0}", call_id);
            }
            catch (RemoteApiException remote_ex)
            {
                // An API error is returned
                Console.WriteLine("#REMOTE# {0} : {1}", remote_ex.Code, remote_ex.Message);
            }
            catch (LocalApiException local_ex)
            {
                // A library error is returned
                Console.WriteLine("#LOCAL# {0}", local_ex.Message);
            }
            catch (System.Exception ex)
            {
                // An uncaught error is returned
                Console.WriteLine("~UNCAUGHT~ {0}", ex.Message);
            }
        }

        /// <summary>
        /// This method shows you how to configure Real Time with inbound calls.
        /// </summary>
        public void RealTimeWithInboundCall()
        {
            try
            {
                // 1 - Create a Dialer app
                // Application name
                string application_name = "My first Dialer app with inbound call";

                // Webservice access parameters
                RealTime rt = new RealTime();
                rt.DataFormat = RealTimeDataFormats.JSON; // Data format. The only format supported right now is "JSON"
                rt.Url = "http://__YOUR_SERVER_HOST__/RealTime.aspx"; // Your URL callback. Our system will POST call status to your URL, and your answers will control the call
                rt.Login = ""; // Login if your URL is password protected (HTTP Basic Authentication)
                rt.Password = ""; // Password If your URL is password protected (HTTP Basic Authentication)

                AppsService appServ = new AppsService(this.login, this.password);
                DialrService dialr = new DialrService(this.login, this.password);

                // Create the app
                App app = appServ.Create(ApplicationTypes.REALTIME, application_name, rt);
                string app_id = app.Hash;

                // 2 - Assign a Did to the App
                Did did = appServ.AssignFirstAvailableDid(app_id);

                // Display the result
                Console.WriteLine("You can now call the {0} to test Real Time with the application {1}.", did.IntlNumber, app_id);
            }
            catch (RemoteApiException remote_ex)
            {
                // An API error is returned
                Console.WriteLine("#REMOTE# {0} : {1}", remote_ex.Code, remote_ex.Message);
            }
            catch (LocalApiException local_ex)
            {
                // A library error is returned
                Console.WriteLine("#LOCAL# {0}", local_ex.Message);
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
            // TODO : Don't forget to fill login and password
            Program prog = new Program();

            // Make Real Time with an outbound call
            //prog.RealTimeWithOutboundCall();

            // Make Real Time with an inbound call
            //prog.RealTimeWithInboundCall();
        }
    }
}
