using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;
using CallrApi.Enums;
using System.Collections.Generic;
using CallrApi.Objects.Misc;
using CallrApi.Exception;
using CallrApi.Objects.App;
using CallrApi.Objects.Did;

namespace ThecallrApiTest
{
    /// <summary>
    /// This class tests App service methods.
    /// </summary>
    [TestClass]
    public class AppsServiceTest
    {
        #region Static members
        /// <summary>
        /// Apps Service.
        /// </summary>
        private static AppsService Service { get; set; }

        /// <summary>
        /// App.
        /// </summary>
        private static App App { get; set; }

        /// <summary>
        /// App ID;
        /// </summary>
        private static string AppId { get { return App.Hash; } }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new AppsService("https://api.thecallr.com", "login", "password");
            App = Service.Create(ApplicationTypes.CALLTRACKING, "Unit Test App", null);
        }

        /// <summary>
        /// This method cleans class objects.
        /// </summary>
        [ClassCleanup]
        public static void Clean()
        {
            if (!string.IsNullOrEmpty(AppId))
            {
                Service.Delete(AppId);
            }
        }
        #endregion

        #region Test methods
        /// <summary>
        /// This method tests that the Create method throws an exception when the type is invalid.
        /// </summary>
        [TestMethod]
        public void Create_WithInvalidType_Test()
        {
            App app = null;
            try 
	        {	        
		        Service.Create("INVALID_TYPE", "My new App", null);
                Assert.Fail("This call must throw an exception because the app type is unknown.");
	        }
	        catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "Class AppINVALID_TYPE does not exist");
	        }
            finally
            {
                if (app != null)
                    Service.Delete(app.Hash);
            }
        }

        /// <summary>
        /// This method tests that the Create method throws an exception when the params object is invalid.
        /// </summary>
        [TestMethod]
        public void Create_WithInvalidAppObject_Test()
        {
            try
            {
                Service.Create(ApplicationTypes.CALLTRACKING, "My new App", "BAD_OBJECT");
                Assert.Fail("This call must throw an exception because the params object is invalid.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [params]");
            }
        }

        /// <summary>
        /// This method tests that the Create method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void Create_Success_Test()
        {
            App app = Service.Create(ApplicationTypes.CALLTRACKING, "Unit test App", null);
            Assert.IsNotNull(app, "This call must return a valid App object.");
            Service.Delete(app.Hash);
        }

        /// <summary>
        /// This method tests that the Edit method throws an exception when the App ID is invalid.
        /// </summary>
        [TestMethod]
        public void Edit_WithInvalidAppId_Test()
        {
            try
            {
                Service.Edit("INVALID_APP_ID", null, null);
                Assert.Fail("This call must throw an exception because the app id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the Edit method throws an exception when the Params object is invalid.
        /// </summary>
        [TestMethod]
        public void Edit_WithInvalidAppObject_Test()
        {
            try
            {
                Service.Edit(AppId, null, "BAD_OBJECT");
                Assert.Fail("This call must throw an exception because the params object is invalid.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [params]");
            }
        }

        /// <summary>
        /// This method tests that the Edit method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void Edit_SuccessWithName_Test()
        {
            string newName = "New App Name";
            App app = Service.Edit(AppId, newName, null);
            Assert.AreEqual(newName, app.Name, "This call must return a valid App object with the name changed.");
        }

        /// <summary>
        /// This method tests that the Delete method throws an exception when the app id is incorrect.
        /// </summary>
        [TestMethod]
        public void Delete_WithInvalidAppID_Test()
        {
            try
            {
                Service.Delete("INVALID_APP_ID");
                Assert.Fail("This call must throw an exception because the app id is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the Get method throws an exception when the app id is incorrect.
        /// </summary>
        [TestMethod]
        public void Get_WithInvalidAppID_Test()
        {
            try
            {
                Service.Get("INVALID_APP_ID");
                Assert.Fail("This call must throw an exception because the app id is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the Get method method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void Get_Success_Test()
        {
            App app = Service.Get(AppId);
            Assert.IsNotNull(app, "This call must return a valid App object.");
        }

        /// <summary>
        /// This method tests that the GetList method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetList_Success_Test()
        {
            List<App> appList = Service.GetList(true);
            Assert.IsNotNull(appList, "This call must return a valid List of App.");
        }

        /// <summary>
        /// This method tests that the GetDids method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetDids_Success_Test()
        {
            List<Did> appList = Service.GetDids(true);
            Assert.IsNotNull(appList, "This call must return a valid List of Did.");
        }

        /// <summary>
        /// This method tests that the AssignDid method throws an exception when the App ID is incorrect.
        /// </summary>
        [TestMethod]
        public void AssignDid_WithInvalidAppID_Test()
        {
            try
            {
                Service.AssignDid("INVALID_APP_ID", "DID_ID");
                Assert.Fail("This call must throw an exception because the App ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the AssignDid method throws an exception when the Did ID is incorrect.
        /// </summary>
        [TestMethod]
        public void AssignDid_WithInvalidDidID_Test()
        {
            try
            {
                Service.AssignDid(AppId, "INVALID_DID_ID");
                Assert.Fail("This call must throw an exception because the Did ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [did]");
            }
        }

        /// <summary>
        /// This method tests that the AssignFirstAvailableDid method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void AssignFirstAvailableDid_Success_Test()
        {
            Did did = Service.AssignFirstAvailableDid(AppId);
            Assert.IsNotNull(did, "This call must return a valid Did object.");
            Service.RemoveDid(did.Hash);
        }

        /// <summary>
        /// This method tests that the AssignFirstAvailableDid method throws an exception when the App ID is incorrect.
        /// </summary>
        [TestMethod]
        public void AssignFirstAvailableDid_WithInvalidAppID_Test()
        {
            try
            {
                Service.AssignFirstAvailableDid("INVALID_APP_ID");
                Assert.Fail("This call must throw an exception because the App ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the RemoveDid method throws an exception when the Did ID is incorrect.
        /// </summary>
        [TestMethod]
        public void RemoveDid_WithInvalidDidID_Test()
        {
            try
            {
                Service.RemoveDid("INVALID_DID_ID");
                Assert.Fail("This call must throw an exception because the Did ID is incorrect.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [did]");
            }
        }

        /// <summary>
        /// This method tests that the GetAuthorizedClis method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetAuthorizedClis_Success_Test()
        {
            List<CustomerCli> cliList = Service.GetAuthorizedClis(CliAuthTypes.CALL);
            Assert.IsNotNull(cliList, "This call must return a valid List of CustomerCli.");
        }

        /// <summary>
        /// This method tests that the GetAuthorizedClis method throws an exception when the type is invalid.
        /// </summary>
        [TestMethod]
        public void GetAuthorizedClis_WithInvalidType_Test()
        {
            try
            {
                List<CustomerCli> cliList = Service.GetAuthorizedClis(null);
                Assert.Fail("This call must throw an exception because the cli type is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [type]");
            }
        }
        #endregion
    }
}
