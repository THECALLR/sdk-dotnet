using System;
using System.Collections.Generic;
using ThecallrApi.Exception;
using ThecallrApi.Helper;
using ThecallrApi.Objects.App;
using ThecallrApi.Objects.ClickToCall;
using ThecallrApi.Objects.Misc;
using ThecallrApi.Services.Client;

namespace ClickToCallSample
{
    /// <summary>
    /// This class gives an example of Click To Call manipulation.
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
        /// This method shows you how to create a new ClickToCall application.
        /// </summary>
        public void CreateClickToCallApplication()
        {
            try
            {
                // Application name
                string application_name = "My first ClickToCall app";

                // Create the new ClickToCall Application
                ClickToCallService service = new ClickToCallService(this.login, this.password);
                App app = service.Create(application_name);

                // Display the result
                Console.WriteLine("Created application:\n{0}", Tools.ObjectDump(app));

                // Edit the new app
                // Media configuration
                app.Ctc.Medias.A_welcome = 84; // welcome message id played to A immediatly
                app.Ctc.Medias.A_ringtone = 3; // waiting message id played to A while calling B
                app.Ctc.Medias.B_whisper = 0; // message id played to B only (A still hears the ringtone)
                app.Ctc.Medias.AB_bridge = 0; // message id played to both parties before bridging the call

                // Options configuration
                app.Ctc.Options.A_attempts = 1; // call attempts (must be between 1 and 5)
                app.Ctc.Options.A_retrypause = 30; // Pause between attempts (must be between 30 and 300)

                // Edit the application (we don't want to change the app name so we set second parameter to null)
                app = service.Edit(app.Hash, null, app.Ctc);

                // Display the result after edit
                Console.WriteLine("Edited application:\n{0}", Tools.ObjectDump(app));
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
        /// This method shows you how to start and bridge 2 calls.
        /// On your website the user will specify his phone number and optionally when he wants to call back.
        /// </summary>
        public void StartAndBridge2Calls()
        {
            // WARNING : executing this method will make the call
            try
            {
                // ClickToCall application ID
                string app_id = "__APP_ID__";

                // "A" phone number list configuration
                List<Target> a_targets = new List<Target>();
                a_targets.Add(new Target() { Number = "__PHONE_NUMBER_A__", Timeout = 30 });

                // "B" phone number list configuration
                List<Target> b_targets = new List<Target>();
                b_targets.Add(new Target() { Number = "__PHONE_NUMBER_B__", Timeout = 30 });

                // Options configuration
                StartOptions options = new StartOptions();
                options.Schedule = DateTime.Now.AddSeconds(30); // Scheduled time of the call (on 30 seconds).
                options.Cli = "BLOCKED"; // E.164 format caller phone number or "BLOCKED" if blocked
                options.CdrField = "myClickToCallField"; // Custom field visible in CDR (can be used to tag calls)

                // Start and Bridge the 2 calls
                ClickToCallService service = new ClickToCallService(this.login, this.password);
                string call_id = service.Start2Calls(app_id, a_targets, b_targets, options);

                // Display the result
                Console.WriteLine("ClickToCall call ID: {0}", call_id);
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
        /// This method shows you how to retrieve call properties.
        /// </summary>
        public void GetCallStatus()
        {
            try
            {
                // Call ID
                string call_id = "__CALL_ID__";

                // Request the status of the call
                ClickToCallService service = new ClickToCallService(this.login, this.password);
                Call call = service.GetCallStatus(call_id);

                // Display the result
                Console.WriteLine(Tools.ObjectDump(call));
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

            // Create a new CreateClickToCallApplication Application
            //prog.CreateClickToCallApplication();

            // Start and bridge 2 calls
            //prog.StartAndBridge2Calls();

            // Get call status
            //prog.GetCallStatus();
        }
    }
}
