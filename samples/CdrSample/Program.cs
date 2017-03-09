using System;
using System.Collections.Generic;
using CallrApi.Exception;
using CallrApi.Helper;
using CallrApi.Objects.Cdr;
using CallrApi.Services.Client;

namespace CallrApi.Samples.CdrSample
{
    /// <summary>
    /// This class gives an example of CDR manipulation.
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
        /// This method shows you how to retrieve inbound CDR.
        /// </summary>
        public void GetInboundCdrs()
        {
            try
            {
                CdrService service = new CdrService(login, password);

                // Get, for example, all inbound CDR over the last three months
                List<CdrIn> cdr_in = service.GetInboundCdrs(DateTime.Now.AddMonths(-3), DateTime.Now);

                // Display the result
                Console.WriteLine(Tools.ObjectDump(cdr_in));
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
        /// This method shows you how to retrieve outbound CDR.
        /// </summary>
        public void GetOutboundCdrs()
        {
            try
            {
                CdrService service = new CdrService(login, password);
                // Get, for example, all outbound CDR over the last three onths (you can filter by application and / or by Did if you want)
                string filter_application = null;
                string filter_did = null;
                List<CdrOut> cdr_out = service.GetOutboundCdrs(DateTime.Now.AddMonths(-3), DateTime.Now, filter_application, filter_did);
                // Display the result
                Console.WriteLine(Tools.ObjectDump(cdr_out));
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

            // List inbound CDR
            //prog.GetInboundCdrs();

            // List outbound CDR
            //prog.GetOutboundCdrs();
        }
    }
}
