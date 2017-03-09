using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;
using CallrApi.Objects.ClickToCall;
using CallrApi.Objects.App;
using CallrApi.Objects.App.Param;
using CallrApi.Enums;
using System.Collections.Generic;
using System.Linq;
using CallrApi.Exception;
using CallrApi.Objects.Misc;

namespace ThecallrApiTest
{
    /// <summary>
    /// This class tests Click-To-Call service methods.
    /// </summary>
    [TestClass]
    public class ClickToCallServiceTest
    {
        #region Static members
        /// <summary>
        /// ClickToCall Service.
        /// </summary>
        private static ClickToCallService Service { get; set; }

        /// <summary>
        /// Apps Service.
        /// </summary>
        private static AppsService AppsService { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new ClickToCallService(null, "login", "password");
            AppsService = new AppsService(null, "login", "password");
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
                // ClickToCall object initialization
                ClickToCall ctc = new ClickToCall();
                ctc.Medias = new ClickToCallMedia(); // Media
                ctc.Options = new ClickToCallOptions(); // Options
                ctc.Options.A_attempts = 1;
                ctc.Options.A_retrypause = 30;
                ctc.Vms = new Vms() // Voicemail
                {
                    FileFormat = VoicemailFileFormats.MP3,
                    FileName = "{DATETIME}",
                    EmailTemplate = "THECALLR",
                    Timeout = 30,
                    Locale = "fr_FR",
                    Timezone = "Europe/Paris",
                    Emails = new List<string>()
                };
                app = Service.Create("Unit test ClickToCall App", ctc);
                Assert.IsNotNull(app.Ctc, "This call must return a valid Click-To-Call object.");
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
                app = Service.Create("Unit test ClickToCall App", null);
                int ringtoneBefore = app.Ctc.Medias.A_ringtone;
                app.Ctc.Medias.A_ringtone = 1;
                app = Service.Edit(app.Hash, null, app.Ctc);
                int ringtoneAfter = app.Ctc.Medias.A_ringtone;
                Assert.AreNotEqual(ringtoneBefore, ringtoneAfter, "This call should have modified the A_Ringtone Medias property.");
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
        /// This method tests that the GetCallList method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetCallList_Success_Test()
        {
            List<App> appList = AppsService.GetList(false);
            App app = appList.FirstOrDefault();
            List<Call> callList = Service.GetCallList(app.Hash, DateTime.Now.AddMonths(-1), DateTime.Now);
            Assert.IsNotNull(callList, "This call must return a valid List of Call.");
        }

        /// <summary>
        /// This method tests that the GetCallList method throws an exception when the App ID is incorrect.
        /// </summary>
        [TestMethod]
        public void GetCallList_WithInvalidAppId_Test()
        {
            try
            {
                List<Call> callList = Service.GetCallList("INVALID_APP_ID", DateTime.Now.AddMonths(-1), DateTime.Now);
                Assert.Fail("This call must throw an exception because the App ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the CancelCall method throws an exception when the Call ID is incorrect.
        /// </summary>
        [TestMethod]
        public void CancelCall_WithInvalidCallId_Test()
        {
            try
            {
                Service.CancelCall("INVALID_CALL_ID");
                Assert.Fail("This call must throw an exception because the Call ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [call]");
            }
        }

        /// <summary>
        /// This method tests that the GetCallStatus method throws an exception when the Call ID is incorrect.
        /// </summary>
        [TestMethod]
        public void GetCallStatus_WithInvalidCallId_Test()
        {
            try
            {
                Service.GetCallStatus("INVALID_CALL_ID");
                Assert.Fail("This call must throw an exception because the Call ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [call]");
            }
        }

        /// <summary>
        /// This method tests that the GetCallStatus method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void GetCallStatus_Success_Test()
        {
            // TODO : need to find a good CALL ID
            //Call call = Service.GetCallStatus("1");
            //Assert.IsNotNull(call, "This call must return a valid Call object.");
        }

        /// <summary>
        /// This method tests that the Start2Calls method throws an exception when the App ID is incorrect.
        /// </summary>
        [TestMethod]
        public void Start2Calls_WithInvalidAppId_Test()
        {
            try
            {
                Service.Start2Calls("INVALID_APP_ID", null, null, null);
                Assert.Fail("This call must throw an exception because the App ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the Start2Calls method throws an exception when the a_targets is incorrect.
        /// </summary>
        [TestMethod]
        public void Start2Calls_WithInvalidATargets_Test()
        {
            try
            {
                List<App> appList = AppsService.GetList(false);
                App app = appList.FirstOrDefault();
                // a_targets param initialization
                List<Target> a_targets = new List<Target>();
                a_targets.Add(new Target() { Number = "INVALID_PHONE_NUMBER", Timeout = 20 });
                Service.Start2Calls(app.Hash, a_targets, null, null);
                Assert.Fail("This call must throw an exception because the a_targets is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [a_targets]");
            }
        }

        /// <summary>
        /// This method tests that the Start2Calls method throws an exception when the b_targets is incorrect.
        /// </summary>
        [TestMethod]
        public void Start2Calls_WithInvalidBTargets_Test()
        {
            try
            {
                List<App> appList = AppsService.GetList(false);
                App app = appList.FirstOrDefault();
                // a_targets param initialization
                List<Target> a_targets = new List<Target>();
                a_targets.Add(new Target() { Number = "+33176450020", Timeout = 20 });
                // b_targets param initialization
                List<Target> b_targets = new List<Target>();
                b_targets.Add(new Target() { Number = "INVALID_PHONE_NUMBER", Timeout = 20 });
                Service.Start2Calls(app.Hash, a_targets, b_targets, null);
                Assert.Fail("This call must throw an exception because the b_targets is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [b_targets]");
            }
        }

        /// <summary>
        /// This method tests that the Start2Calls method throws an exception when the app type is incorrect.
        /// </summary>
        [TestMethod]
        public void Start2Calls_WithInvalidAppType_Test()
        {
            App app = null;
            try
            {
                app = AppsService.Create(ApplicationTypes.CALLTRACKING, "Unit test ClickToCall App", null);
                // a_targets param initialization
                List<Target> a_targets = new List<Target>();
                a_targets.Add(new Target() { Number = "+33123456789", Timeout = 20 });
                // b_targets param initialization
                List<Target> b_targets = new List<Target>();
                b_targets.Add(new Target() { Number = "+33123456789", Timeout = 20 });
                Service.Start2Calls(app.Hash, a_targets, b_targets, null);
                Assert.Fail("This call must throw an exception because the options is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "BAD_APP_TYPE");
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
