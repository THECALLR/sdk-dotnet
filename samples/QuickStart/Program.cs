using System;
using System.Collections.Generic;
using CallrApi.Exception;
using CallrApi.Helper;
using CallrApi.Objects.App;
using CallrApi.Services.Client;

namespace CallrApi.Samples.QuickStart
{
    /// <summary>
    /// This class gives an example of simple server requests.
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
        /// This method shows you how to call an API method without parameter.
        /// </summary>
        public void ExampleCallWithoutParameter()
        {
            try
            {
                SystemService service = new SystemService(this.login, this.password);

                // Request the current timestamp on the CALLR server
                int timestamp = service.GetTimestamp();

                // Display the result
                Console.WriteLine("The current UNIX time from CALLR server is {0}.", timestamp);
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
        /// This method shows you how to call an API method with parameters.
        /// </summary>
        public void ExampleCallWithParameters()
        {
            try
            {
                AppsService service = new AppsService(this.login, this.password);

                // Request the list of your Voice Apps with numbers
                bool with_numbers = true;
                List<App> app_list = service.GetList(with_numbers);

                // Display the result
                Console.WriteLine(Tools.ObjectDump(app_list));
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
        /// This method shows you a call that generates an error.
        /// </summary>
        public void ExampleCallWithError()
        {
            try
            {
                AppsService service = new AppsService(this.login, this.password);

                // Request an application with an invalid ID (it must throws an exception)
                string app_id = "__INVALID_APP_ID__";
                App app = service.Get(app_id);

                // You should never see this display and have a RemoteApiException
                Console.WriteLine(Tools.ObjectDump(app));
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
                
            // Make a request without parameter
            // prog.ExampleCallWithoutParameter();
                
            // Make a request with parameter
            // prog.ExampleCallWithParameters();

            // Make a request throwing an exception
            // prog.ExampleCallWithError();
        }
    }
}
