using System;
using System.Collections.Generic;
using CallrApi.Exception;
using System.Linq;
using CallrApi.Helper;
using CallrApi.Services.Client;
using CallrApi.Objects.App;
using CallrApi.Objects.Misc;
using CallrApi.Objects.Did;

namespace CallrApi.Samples.CallTrackingSample
{
    /// <summary>
    /// This class gives an example of Call Tracking manipulation.
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
        /// This method shows you how to create a new Call Tracking application.
        /// </summary>
        public void CreateCallTrackingApplication()
        {
            try
            {
                // Application name
                string application_name = "My first CallTraking app";

                // Create the new Call Tracking Application
                CallTrackingService service = new CallTrackingService(this.login, this.password);
                App app = service.Create(application_name);

                // Display the result
                Console.WriteLine("Created application:\n{0}", Tools.ObjectDump(app));
                
                // Edit the new app
                // Media configuration
                app.Ct.Medias.Welcome = 84; // welcome message id
                app.Ct.Medias.Ringtone = 3; // waiting message id
                app.Ct.Medias.Whisper = 0; // callee message id
                app.Ct.Medias.Bridge = 0; //caller message id

                // Target configuration
                app.Ct.Targets.Add(new Target() { Number = "+33123456789", Timeout = 20 });

                // Edit the application (we don't want to change the app name so we set second parameter to null)
                app = service.Edit(app.Hash, null, app.Ct);

                // Display the result after edit
                // Console.WriteLine("Edited application:\n{0}", Tools.ObjectDump(app));
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
        /// This method shows you how to assign the first available Did to an existing application.
        /// </summary>
        public void AssignFirstAvailableDid()
        {
            try
            {
                // Application ID you want to assign with a Did
                string app_id = "__APP_ID__";
                CallTrackingService service = new CallTrackingService(this.login, this.password);

                // Assign the application to the first available did
                Did did = service.AssignFirstAvailableDid(app_id);

                Console.WriteLine(Tools.ObjectDump(did));
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
        /// This method shows you how to assign a Did to an existing application.
        /// </summary>
        public void AssignDid()
        {
            try
            {
                // Application ID you want to assign with a Did
                string app_id = "__APP_ID__";

                // Retrieve all available dids from the apps service
                bool only_available_dids = true;
                AppsService apps_service = new AppsService(this.login, this.password);

                List<Did> dids = apps_service.GetDids(only_available_dids);
                if (dids.Count > 0)
                {
                    // We take, for example, the last did
                    Did did = dids.Last();
                    // Assign the application to did
                    CallTrackingService ct_service = new CallTrackingService(this.login, this.password);
                    ct_service.AssignDid(app_id, did.Hash);
                    Console.WriteLine("The application {0} has been successfully assigned to the Did {1}", app_id, did.Hash);
                }
                else
                    Console.WriteLine("No available did to assign.");
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
        /// This method shows you how to remove a Did assignation.
        /// </summary>
        public void RemoveDid()
        {
            try
            {
                // Did ID you want to remove assignations
                string did_id = "__DID_ID__";

                // Remove did assignation
                CallTrackingService ct_service = new CallTrackingService(this.login, this.password);

                ct_service.RemoveDid(did_id);

                Console.WriteLine("The Did {0} has been removed successfully", did_id);
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
            // TODO : Don't forget to fill login and password in App.config file
            Program prog = new Program();

            // Create a new Call Tracking Application
            // prog.CreateCallTrackingApplication();

            // Assign first available did
            //prog.AssignFirstAvailableDid();

            // Assign a did
            //prog.AssignDid();

            // Remove Did assignation
            //prog.RemoveDid();
        }
    }
}
