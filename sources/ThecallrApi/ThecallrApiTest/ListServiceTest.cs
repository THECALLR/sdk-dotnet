using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Objects.Misc;
using CallrApi.Services.Client;
using System.Collections.Generic;
using CallrApi.Exception;

namespace CallrApiTest
{
    /// <summary>
    /// This class tests List service methods.
    /// </summary>
    [TestClass]
    public class ListServiceTest
    {
        #region Static members
        /// <summary>
        /// List Service.
        /// </summary>
        private static ListService Service { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new ListService(null, "login", "password");
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
        /// This method tests that the GetCountries method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetCountries_Success_Test()
        {
            Dictionary<string, Country> countries = Service.GetCountries();
            Assert.IsNotNull(countries, "This call must return a valid List of KeyValuePair<string, Country>.");
        }

        /// <summary>
        /// This method tests that the GetNumberInfos method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void GetNumberInfos_Success_Test()
        {
            NumberInfos numberInfos = Service.GetNumberInfos("+33123456789");
            Assert.IsNotNull(numberInfos);
        }

        /// <summary>
        /// This method tests that the GetNumberInfos method returns an invalid object when the number specified is incorrect.
        /// </summary>
        [TestMethod]
        public void GetNumberInfos_WithInvalidNumber_Test()
        {
            NumberInfos numberInfos = Service.GetNumberInfos("INVALID_PHONE_NUMBER");
            Assert.IsFalse(numberInfos.IsValid, "This call should have returned an invalid object.");
        }

        /// <summary>
        /// This method tests that the GetTimezones method works in a valid situation.
        /// </summary>
        [TestMethod]
        public void GetTimezones_Success_Test()
        {
            Dictionary<int, Timezone> timezones = Service.GetTimezones();
            Assert.IsNotNull(timezones, "This call must return a valid List of KeyValuePair<int, Timezone>.");
        } 
        #endregion
    }
}
