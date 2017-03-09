using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallrApi.Services.Client;
using System.Collections.Generic;
using CallrApi.Enums;
using CallrApi.Objects.Media;
using CallrApi.Exception;

namespace CallrApiTest
{
    /// <summary>
    /// This class tests Media service methods.
    /// </summary>
    [TestClass]
    public class MediaServiceTest
    {
        #region Static members
        /// <summary>
        /// Media Service.
        /// </summary>
        private static MediaService Service { get; set; }
        #endregion

        #region Static methods
        /// <summary>
        /// This method initializes class objects.
        /// </summary>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Service = new MediaService(null, "login", "password");
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
        /// This method tests that the Library.Create method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void Create_Success_Test()
        {
            int mediaId = Service.Library.Create("Unit test Media");
            Service.Library.Delete(mediaId);
        }

        /// <summary>
        /// This method tests that the Library.Create method throws an exception when the name is invalid.
        /// </summary>
        [TestMethod]
        public void Create_WithInvalidName_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create(null);
                Assert.Fail("This call must throw an exception because the name is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [name]");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Library.Delete method throws an exception when the media id is invalid.
        /// </summary>
        [TestMethod]
        public void Delete_WithInvalidMediaId_Test()
        {
            try
            {
                Service.Library.Delete(int.MinValue);
                Assert.Fail("This call must throw an exception because the media id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_id]");
            }
        }

        /// <summary>
        /// This method tests that the Library.GetList method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void GetLibrary_Success_Test()
        {
            Dictionary<int, MediaLibrary> media = Service.Library.GetList(new List<string>() { MediaLibraryCategories.WELCOME });
            Assert.IsNotNull(media, "This call must return a valid List of KeyValuePair<int, MediaLibrary>.");
        }

        /// <summary>
        /// This method tests that the Library.GetList method throws an exception when the category is invalid.
        /// </summary>
        [TestMethod]
        public void GetLibrary_WithInvalidCategory_Test()
        {
            try
            {
                Dictionary<int, MediaLibrary> media = Service.Library.GetList(new List<string>() { "INVALID_CATEGORY" });
                Assert.Fail("This call must throw an exception because the category is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [categories]");
            }
        }

        /// <summary>
        /// This method tests that the Email.GetTemplates method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void GetEmailTemplates_Success_Test()
        {
            Dictionary<string, EmailTemplate> emailTemplates = Service.Email.GetTemplates(MediaEmailTemplates.VMS);
            Assert.IsNotNull(emailTemplates, "This call must return a valid List of KeyValuePair<int, EmailTemplate>.");
        }

        /// <summary>
        /// This method tests that the Email.GetTemplates method throws an exception when the template is invalid.
        /// </summary>
        [TestMethod]
        public void GetEmailTemplates_WithInvalidTemplate_Test()
        {
            try
            {
                Dictionary<string, EmailTemplate> emailTemplates = Service.Email.GetTemplates("INVALID_TEMPLATE");
                Assert.Fail("This call must throw an exception because the template is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [type]");
            }
        }

        /// <summary>
        /// This method tests that the Library.Get method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void GetMediaDetails_Success_Test()
        {
            MediaLibrary media = Service.Library.Get(1);
            Assert.IsNotNull(media, "This call must return a valid MediaLibrary object.");
        }

        /// <summary>
        /// This method tests that the Library.Get method throws an exception when the media id is invalid.
        /// </summary>
        [TestMethod]
        public void GetMediaDetails_WithInvalidMediaId_Test()
        {
            try
            {
                Service.Library.Get(int.MinValue);
                Assert.Fail("This call must throw an exception because the media id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_id]");
            }
        }

        /// <summary>
        /// This method tests that the Library.GetPhoneId method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void GetPhoneId_Success_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                PhoneId phoneId = Service.Library.GetPhoneId(mediaId, "FR");
                Assert.IsNotNull(phoneId, "This call must return a valid PhoneId object.");
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("This call should not throw an exception: {0}.", ex.Message));
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Library.GetPhoneId method throws an exception when the media id is invalid.
        /// </summary>
        [TestMethod]
        public void GetPhoneId_WithInvalidMediaId_Test()
        {
            try
            {
                Service.Library.GetPhoneId(int.MinValue, "FR");
                Assert.Fail("This call must throw an exception because the media id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_id]");
            }
        }

        /// <summary>
        /// This method tests that the Library.GetPhoneId method throws an exception when a forbidden media is called.
        /// </summary>
        [TestMethod]
        public void GetPhoneId_Forbidden_Test()
        {
            try
            {
                Service.Library.GetPhoneId(1, "FR");
                Assert.Fail("This call must throw an exception because the media 1 is private.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "FORBIDDEN");
            }
        }

        /// <summary>
        /// This method tests that the Library.GetPhoneId method throws an exception when the country code is invalid.
        /// </summary>
        [TestMethod]
        public void GetPhoneId_WithInvalidCountryCode_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Library.GetPhoneId(mediaId, "INVALID_CODE");
                Assert.Fail("This call must throw an exception because the country code id is unknown.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [country_code]");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Library.SetContent method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void SetContent_Success_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Library.SetContent(mediaId, "Test message", null);
            }
            catch (Exception)
            {
                Assert.Fail("This call must not throw an exception.");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Library.SetContent method throws an exception when the media id is invalid.
        /// </summary>
        [TestMethod]
        public void SetContent_WithInvalidMediaId_Test()
        {
            try
            {
                Service.Library.SetContent(int.MinValue, null, null);
                Assert.Fail("This call must throw an exception because the media id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_id]");
            }
        }

        /// <summary>
        /// This method tests that the Library.SetContentFromRecording method throws an exception when the media id is invalid.
        /// </summary>
        [TestMethod]
        public void SetContentFromRecording_WithInvalidMediaId_Test()
        {
            try
            {
                Service.Library.SetContentFromRecording(int.MinValue, null);
                Assert.Fail("This call must throw an exception because the media id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_id]");
            }
        }

        /// <summary>
        /// This method tests that the Library.SetContentFromRecording method throws an exception when the media file is invalid.
        /// </summary>
        [TestMethod]
        public void SetContentFromRecording_WithInvalidMediaFile_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Library.SetContentFromRecording(mediaId, null);
                Assert.Fail("This call must throw an exception because the media file is unknown.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_file]");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Tts.SetContent method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void SetContentWithTts_Success_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Tts.SetContent(mediaId, "Text to say", MediaTtsVoices.NUANCE_FR_AUDREY, new TtsOptions() { Rate = 50 });
            }
            catch (Exception)
            {
                Assert.Fail("This call must not throw an exception.");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Tts.SetContent method throws an exception when the media id is invalid.
        /// </summary>
        [TestMethod]
        public void SetContentWithTts_WithInvalidMediaId_Test()
        {
            try
            {
                Service.Tts.SetContent(int.MinValue, null, null, null);
                Assert.Fail("This call must throw an exception because the media id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_id]");
            }
        }

        /// <summary>
        /// This method tests that the Tts.SetContent method throws an exception when the text to say is invalid.
        /// </summary>
        [TestMethod]
        public void SetContentWithTts_WithInvalidText_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Tts.SetContent(mediaId, null, null, null);
                Assert.Fail("This call must throw an exception because the text to say is unknown.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [text]");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Tts.SetContent method throws an exception when the voice is invalid.
        /// </summary>
        [TestMethod]
        public void SetContentWithTts_WithInvalidVoice_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Tts.SetContent(mediaId, "Text to say", "INVALID_VOICE", null);
                Assert.Fail("This call must throw an exception because the voice is unknown.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [voice]");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Tts.SetContent method throws an exception when the options are invalid.
        /// </summary>
        [TestMethod]
        public void SetContentWithTts_WithInvalidOptions_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Tts.SetContent(mediaId, "Text to say", MediaTtsVoices.NUANCE_FR_AUDREY, new TtsOptions() { Rate = 1000 });
                Assert.Fail("This call must throw an exception because the options are invalid.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [rate]");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Library.SetName method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void SetName_Success_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                string oldName = "Unit test Media";
                string newName = "New unit test media";
                mediaId = Service.Library.Create(oldName);
                Service.Library.SetName(mediaId, newName);
                MediaLibrary media = Service.Library.Get(mediaId);
                Assert.AreEqual(newName, media.Name, "The media name has not changed.");
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("This call must not throw an exception: {0}.", ex.Message));
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Library.SetName method throws an exception when the media id is invalid.
        /// </summary>
        [TestMethod]
        public void SetName_WithInvalidMediaId_Test()
        {
            try
            {
                Service.Library.SetName(int.MinValue, null);
                Assert.Fail("This call must throw an exception because the media id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_id]");
            }
        }

        /// <summary>
        /// This method tests that the Library.SetName method throws an exception when the media name is invalid.
        /// </summary>
        [TestMethod]
        public void SetName_WithInvalidMediaName_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Library.SetName(mediaId, null);
                Assert.Fail("This call must throw an exception because the media name is invalid.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [name]");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Library.SetTags method works with correct parameters.
        /// </summary>
        [TestMethod]
        public void SetTags_Success_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test media");
                Dictionary<string, List<string>> tags = new Dictionary<string,List<string>>();
                tags["UNITTEST"] = new List<string>() { "helloworld" };
                Service.Library.SetTags(mediaId, tags);
                MediaLibrary media = Service.Library.Get(mediaId);
                Assert.IsTrue(media.Tags.Count == 1, "The media tags have not changed.");
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("This call must not throw an exception: {0}.", ex.Message));
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }

        /// <summary>
        /// This method tests that the Library.SetTags method throws an exception when the media id is invalid.
        /// </summary>
        [TestMethod]
        public void SetTags_WithInvalidMediaId_Test()
        {
            try
            {
                Service.Library.SetTags(int.MinValue, null);
                Assert.Fail("This call must throw an exception because the media id is unknown.");
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "PROPERTY_VALUE_ERROR [media_id]");
            }
        }

        /// <summary>
        /// This method tests that the Library.SetTags method throws an exception when the tags are invalid.
        /// </summary>
        [TestMethod]
        public void SetTags_WithInvalidTags_Test()
        {
            int mediaId = int.MinValue;
            try
            {
                mediaId = Service.Library.Create("Unit test Media");
                Service.Library.SetTags(mediaId, null);
                Assert.Fail("This call must throw an exception because the tags are invalid.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(RemoteApiException));
                Assert.AreEqual(ex.Message, "INVALID_PARAM_FORMAT [tags]");
            }
            finally
            {
                if (mediaId != int.MinValue)
                    Service.Library.Delete(mediaId);
            }
        }
        #endregion
    }
}
