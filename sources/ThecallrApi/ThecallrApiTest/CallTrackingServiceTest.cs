using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;
using CallrApi.Objects.App;
using CallrApi.Objects.CallTracking;
using CallrApi.Objects.Misc;
using System.Collections.Generic;
using CallrApi.Objects.App.Param;
using CallrApi.Enums;

namespace ThecallrApiTest
{
    /// <summary>
    /// This class tests CallTracking service methods.
    /// </summary>
    [TestClass]
    public class CallTrackingServiceTest
    {
        #region Static members
        /// <summary>
        /// CallTracking Service.
        /// </summary>
        private static CallTrackingService Service { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new CallTrackingService(null, "login", "password");
        }

        /// <summary>
        /// This method cleans class objects.
        /// </summary>
        [ClassCleanup]
        public static void Clean()
        {
        }
        #endregion

        #region Test methods
        /// <summary>
        /// This method tests that the Create method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void Create_Success_Test()
        {
            App app = null;
            try
            {
                // CallTracking object initialization
                CallTracking ct = new CallTracking();
                ct.Ga = new GA() { Ua = string.Empty }; // Google Analytics
                ct.Medias = new CallTrackingMedia(); // Media
                ct.Options = new CallTrackingOptions() { RecordCalls = false }; // Options
                ct.Targets = new List<Target>(); // Targets
                ct.Targets.Add(new Target() { Number = "+33123456789", Timeout = 20 });
                ct.Vms = new Vms() // Voicemail
                {
                    FileFormat = VoicemailFileFormats.MP3,
                    FileName = "{DATETIME}",
                    EmailTemplate = "THECALLR",
                    Timeout = 30,
                    Locale = "fr_FR",
                    Timezone = "Europe/Paris",
                    Emails = new List<string>()
                };
                // Service method call
                app = Service.Create("Unit test CallTracking App", ct);
                Assert.IsNotNull(app.Ct, "This call must return a valid Call Tracking object.");
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("This call should not throw an exception: {0}.", ex.Message));
            }
            finally
            {
                if (app != null)
                    Service.Delete(app.Hash);
            }
        }

        /// <summary>
        /// This method tests that the Create method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void Edit_Success_Test()
        {
            App app = null;
            try
            {
                // Service method call
                app = Service.Create("Unit test CallTracking App", null);
                int nbBefore = app.Ct.Targets.Count;
                app.Ct.Targets.Add(new Target() { Number = "+33123456789", Timeout = 20 });
                app = Service.Edit(app.Hash, null, app.Ct);
                int nbAfter = app.Ct.Targets.Count;
                Assert.AreNotEqual(nbBefore, nbAfter, "This call should have modified the Target number.");
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("This call should not throw an exception: {0}.", ex.Message));
            }
            finally
            {
                if (app != null)
                    Service.Delete(app.Hash);
            }
        } 
        #endregion
    }
}
