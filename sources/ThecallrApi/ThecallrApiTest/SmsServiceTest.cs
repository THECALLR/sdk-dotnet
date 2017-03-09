using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;
using CallrApi.Exception;
using System.Collections.Generic;
using CallrApi.Objects.Sms;
using System.Linq;

namespace ThecallrApiTest
{
    /// <summary>
    /// This class tests Sms service methods.
    /// </summary>
    [TestClass]
    public class SmsServiceTest
    {
        #region Static members
        /// <summary>
        /// Media Service.
        /// </summary>
        private static SmsService Service { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new SmsService("https://api.thecallr.com", "login", "password");
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
        /// This method tests that the Send method throws an exception when the from number is invalid.
        /// </summary>
        [TestMethod]
        public void Send_WithInvalidFrom_Test()
        {
            try
            {
                Service.Send("+33123", "+33123456789", "test", null);
                Assert.Fail("This call must throw an exception because the from number is invalid.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [from]");
            }
        }

        /// <summary>
        /// This method tests that the Send method throws an exception when the to number is invalid.
        /// </summary>
        [TestMethod]
        public void Send_WithInvalidTo_Test()
        {
            try
            {
                Service.Send("THECALLR", null, null, null);
                Assert.Fail("This call must throw an exception because the to number is invalid.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [to]");
            }
        }

        /// <summary>
        /// This method tests that the Send method throws an exception when the text is invalid.
        /// </summary>
        [TestMethod]
        public void Send_WithInvalidText_Test()
        {
            try
            {
                Service.Send("THECALLR", "+33123456789", null, null);
                Assert.Fail("This call must throw an exception because the text is invalid.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [body]");
            }
        }

        /// <summary>
        /// This method tests that the Get method throws an exception when the sms id is invalid.
        /// </summary>
        [TestMethod]
        public void Get_WithInvalidSmsId_Test()
        {
            try
            {
                Service.Get("INVALID_SMS_ID");
                Assert.Fail("This call must throw an exception because the sms id is invalid.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [id]");
            }
        }

        /// <summary>
        /// This method tests that the GetInList method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void GetInList_Success_Test()
        {
            List<Sms> smsList = Service.GetInList(DateTime.Now.AddMonths(-1), DateTime.Now);
            Assert.IsNotNull(smsList, "This call must return a valid List of Sms.");
        }

        /// <summary>
        /// This method tests that the GetOutList method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void GetOutList_Success_Test()
        {
            List<Sms> smsList = Service.GetOutList(DateTime.Now.AddMonths(-1), DateTime.Now);
            Assert.IsNotNull(smsList, "This call must return a valid List of Sms.");
        }
        #endregion
    }
}
