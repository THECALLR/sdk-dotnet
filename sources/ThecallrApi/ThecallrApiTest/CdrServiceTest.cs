using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;
using System.Collections.Generic;
using CallrApi.Objects.Cdr;
using CallrApi.Exception;

namespace CallrApiTest
{
    /// <summary>
    /// This class tests CDR service methods.
    /// </summary>
    [TestClass]
    public class CdrServiceTest
    {
        #region Static members
        /// <summary>
        /// Cdr Service.
        /// </summary>
        private static CdrService Service { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new CdrService(null, "login", "password");
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
        /// This method tests that the GetInboundCdrs method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetInboundCdrs_Success_Test()
        {
            List<CdrIn> cdrList = Service.GetInboundCdrs(DateTime.Today.AddMonths(-3), DateTime.Now);
            Assert.IsNotNull(cdrList, "This call must return a valid List of CdrIn.");
        }

        /// <summary>
        /// This method tests that the GetInboundCdrs method throws an exception when from > to dates.
        /// </summary>
        [TestMethod]
        public void GetInboundCdrs_WithInvalidDates_Test()
        {
            try
            {
                List<CdrIn> cdrList = Service.GetInboundCdrs(DateTime.Today.AddMonths(1), DateTime.Now);
                Assert.Fail("This call must throw an exception because the from date is after the to date.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "TO_BEFORE_FROM");
            }
        }

        /// <summary>
        /// This method tests that the GetInboundCdrs method throws an exception when app id is invalid.
        /// </summary>
        [TestMethod]
        public void GetInboundCdrs_WithInvalidAppId_Test()
        {
            try
            {
                List<CdrIn> cdrList = Service.GetInboundCdrs(DateTime.Today.AddMonths(-1), DateTime.Now, "INVALID_APP_ID");
                Assert.Fail("This call must throw an exception because the app id is invalid.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        }

        /// <summary>
        /// This method tests that the GetOutboundCdrs method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetOutboundCdrs_Success_Test()
        {
            List<CdrOut> cdrList = Service.GetOutboundCdrs(DateTime.Today.AddMonths(-3), DateTime.Now);
            Assert.IsNotNull(cdrList, "This call must return a valid List of CdrOut.");
        }

        /// <summary>
        /// This method tests that the GetOutboundCdrs method throws an exception when from > to dates.
        /// </summary>
        [TestMethod]
        public void GetOutboundCdrs_WithInvalidDates_Test()
        {
            try
            {
                List<CdrOut> cdrList = Service.GetOutboundCdrs(DateTime.Today.AddMonths(1), DateTime.Now);
                Assert.Fail("This call must throw an exception because the from date is after the to date.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "TO_BEFORE_FROM");
            }
        }

        /// <summary>
        /// This method tests that the GetOutboundCdrs method throws an exception when app id is invalid.
        /// </summary>
        [TestMethod]
        public void GetOutboundCdrs_WithInvalidAppId_Test()
        {
            try
            {
                List<CdrOut> cdrList = Service.GetOutboundCdrs(DateTime.Today.AddMonths(-1), DateTime.Now, "INVALID_APP_ID");
                Assert.Fail("This call must throw an exception because the app id is invalid.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [app]");
            }
        } 
        #endregion
    }
}
