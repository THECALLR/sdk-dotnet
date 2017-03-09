using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;

namespace CallrApiTest
{
    /// <summary>
    /// This class tests Billing service methods.
    /// </summary>
    [TestClass]
    public class BillingServiceTest
    {
        #region Static members
        /// <summary>
        /// Billing Service.
        /// </summary>
        private static BillingService Service { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new BillingService(null, "login", "password");
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
        /// This method tests that the GetPrepaidCredit method works fine.
        /// </summary>
        [TestMethod]
        public void GetPrepaidCredit_Success_Test()
        {
            decimal prepaidCredit = Service.GetPrepaidCredit();
        } 
        #endregion
    }
}
