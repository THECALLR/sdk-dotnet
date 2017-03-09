using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;
using CallrApi.Objects.App;
using CallrApi.Objects.RealTime;
using CallrApi.Enums;
using CallrApi.Exception;
using System.Collections.Generic;
using CallrApi.Objects.Misc;

namespace CallrApiTest
{
    /// <summary>
    /// This class tests TheDialr service methods.
    /// </summary>
    [TestClass]
    public class DialrServiceTest
    {
        #region Static members
        /// <summary>
        /// Media Service.
        /// </summary>
        private static AppsService Service { get; set; }
        private static DialrService Dialr { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new AppsService(null, "login", "password");
            Dialr = new DialrService(null, "login", "password");
        }

        /// <summary>
        /// This method cleans class objects.
        /// </summary>
        [ClassCleanup]
        public static void Clean()
        {}
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
                // TheDialr object initialization
                RealTime rt = new RealTime();
                rt.Url = "http://dev.thecallr.com/";
                rt.DataFormat = RealTimeDataFormats.JSON;
                rt.Login = string.Empty;
                rt.Password = string.Empty;
                app = Service.Create(ApplicationTypes.REALTIME, "Unit test Dialr App", rt);
                Assert.IsNotNull(app.Rt, "This call must return a valid Dialr object.");
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
                app = Service.Create(ApplicationTypes.REALTIME, "Unit test Dialr App", null);
                string oldUrl = app.Rt.Url;
                app.Rt.Url = "http://thecallr.com";
                app = Service.Edit(app.Hash, null, app.Rt);
                Assert.AreNotEqual(oldUrl, app.Rt.Url, "This call should have modified the Url property.");
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
        /// This method tests that the Call method throws an exception when the App ID is incorrect.
        /// </summary>
        [TestMethod]
        public void Call_WithInvalidAppId_Test()
        {
            try
            {
                Dialr.Call.RealTime("INVALID_APP_ID", null, null);
                Assert.Fail("This call must throw an exception because the App ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the Call method throws an exception when the targets are incorrect.
        /// </summary>
        [TestMethod]
        public void Call_WithInvalidTargets_Test()
        {
            App app = null;
            try
            {
                app = Service.Create(ApplicationTypes.REALTIME, "Unit test TheDialr App", null);
                Dialr.Call.RealTime(app.Hash, null, null);
                Assert.Fail("This call must throw an exception because the targets are incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [target]");
            }
            finally
            {
                if (app != null)
                    Service.Delete(app.Hash);
            }
        }

        /// <summary>
        /// This method tests that the Call method throws an exception when the cli incorrect.
        /// </summary>
        [TestMethod]
        public void Call_WithInvalidCli_Test()
        {
            App app = null;
            try
            {
                app = Service.Create(ApplicationTypes.REALTIME, "Unit test TheDialr App", null);

                Target target = new Target();
                target.Number = "+33123456789";
                target.Timeout = 20;

                RealTimeCallOptions opt = new RealTimeCallOptions();
                opt.cdr_field = string.Empty;
                opt.cli = "INVALID_CLI";

                Dialr.Call.RealTime(app.Hash, target, opt);
                Assert.Fail("This call must throw an exception because the cli is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [options.cli]");
            }
            finally
            {
                if (app != null)
                    Service.Delete(app.Hash);
            }
        }

        /// <summary>
        /// This method tests that the Call method throws an exception when the cdr_field is incorrect.
        /// </summary>
        [TestMethod]
        public void Call_WithInvalidCdr_Test()
        {
            App app = null;
            try
            {
                app = Service.Create(ApplicationTypes.REALTIME, "Unit test TheDialr App", null);

                Target target = new Target();
                target.Number = "+33123456789";
                target.Timeout = 20;

                RealTimeCallOptions opt = new RealTimeCallOptions();
                opt.cdr_field = null;
                opt.cli = "BLOCKED";

                Dialr.Call.RealTime(app.Hash, target, opt);
                Assert.Fail("This call must throw an exception because the cdr_field is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [options.cdr_field]");
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
