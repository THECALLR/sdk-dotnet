using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;

namespace CallrApiTest
{
    /// <summary>
    /// This class tests System service methods.
    /// </summary>
    [TestClass]
    public class SystemServiceTest
    {
        #region Static members
        /// <summary>
        /// Media Service.
        /// </summary>
        private static SystemService Service { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new SystemService(null, "login", "password");
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
        /// This method tests that the GetTimestamp method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetTimestamp_Success_Test()
        {
            int timestamp = Service.GetTimestamp();
            Assert.IsTrue(timestamp > 0, "This call must return a positive value.");
        }
        #endregion
    }
}
