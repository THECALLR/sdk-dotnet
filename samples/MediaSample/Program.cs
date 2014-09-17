using System;
using System.Collections.Generic;
using System.IO;
using ThecallrApi.Enums;
using ThecallrApi.Exception;
using ThecallrApi.Objects.Media;
using ThecallrApi.Services.Client;

namespace ThecallrApi.Samples.MediaSample
{
    /// <summary>
    /// This class gives an example of Media manipulation.
    /// </summary>
    class Program
    {
        /// <summary>
        /// API connexion login.
        /// </summary>
        /// <remarks>You must have received it when you subscribed.</remarks>
        private string login = "";

        /// <summary>
        /// API connexion password.
        /// </summary>
        /// <remarks>You must have received it when you subscribed.</remarks>
        private string password = "";

        /// <summary>
        /// This method shows you how to upload a file in the library.
        /// </summary>
        public void UploadFile()
        {
            try
            {
                // Define yout media name
                string madia_name = "My test message with audio file";

                // Create a new media
                MediaService service = new MediaService(this.login, this.password);
                int media_id = service.Library.Create(madia_name);

                // Define your media text promt
                string text = "Waiting music 01";

                // Audio file content (base64 encoded)
                byte[] filebytes;
                using (FileStream fs = new FileStream("../../assets/Media_sample.wav", FileMode.Open, FileAccess.Read)) // be careful to setup the right path of the file
                {
                    filebytes = new byte[fs.Length];
                    fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                }
                string audio_data = Convert.ToBase64String(filebytes, Base64FormattingOptions.None);

                // Assign the content to the created media
                service.Library.SetContent(media_id, text, audio_data);

                // Keywords definition
                Dictionary<string, List<string>> tags = new Dictionary<string, List<string>>();
                tags["CATEGORY"] = new List<string>() { MediaLibraryCategories.WELCOME, MediaLibraryCategories.RINGTONE }; // Predefined tag (possible values defined in MediaLibraryCategories class)
                tags["VERSION"] = new List<string>() { "1" }; // Custom tag
                tags["CUSTOM"] = new List<string>() { "SDKexample" }; // Custom tag
                service.Library.SetTags(media_id, tags);

                // Display the result
                Console.WriteLine("File Message ID: {0}", media_id);
            }
            catch (RemoteApiException api_ex)
            {
                // An API error is returned
                Console.WriteLine("#REMOTE# {0} : {1}", api_ex.Code, api_ex.Message);
            }
            catch (LocalApiException api_ex)
            {
                // A library error is returned
                Console.WriteLine("#LOCAL# {0}", api_ex.Message);
            }
            catch (System.Exception ex)
            {
                // An uncaught error is returned
                Console.WriteLine("~UNCAUGHT~ {0}", ex.Message);
            }
        }

        /// <summary>
        /// This method shows you how to create a media with Text-To-Speech
        /// </summary>
        public void TtsGeneration()
        {
            try
            {
                // Define yout media name
                string madia_name = "My test message with TTS";
                // Create a new media
                MediaService service = new MediaService(this.login, this.password);
                int media_id = service.Library.Create(madia_name);

                // Define your text
                string text = "Welcome on your test application";
                // Define the voice (possible values are defined in MediaTtsVoices class)
                string voice = "NUANCE_FR_AUDREY";
                // Define options
                TtsOptions options = new TtsOptions();
                options.Rate = 50;
                // Assign the content to the created media
                service.Tts.SetContent(media_id, text, voice, options);

                // Keywords definition
                Dictionary<string, List<string>> tags = new Dictionary<string, List<string>>();
                tags["CATEGORY"] = new List<string>() { MediaLibraryCategories.WELCOME, MediaLibraryCategories.RINGTONE }; // Predefined tag (possible values are defined in MediaLibraryCategories class)
                tags["LANGUAGE"] = new List<string>() { "en_US" }; // Predefined tag
                tags["SOURCE"] = new List<string>() { "SDKexample" }; // Custom tag
                service.Library.SetTags(media_id, tags);
                // Display the result
                Console.WriteLine("TTS Message ID: {0}", media_id);
            }
            catch (RemoteApiException api_ex)
            {
                // An API error is returned
                Console.WriteLine("#REMOTE# {0} : {1}", api_ex.Code, api_ex.Message);
            }
            catch (LocalApiException api_ex)
            {
                // A library error is returned
                Console.WriteLine("#LOCAL# {0}", api_ex.Message);
            }
            catch (System.Exception ex)
            {
                // An uncaught error is returned
                Console.WriteLine("~UNCAUGHT~ {0}", ex.Message);
            }
        }

        /// <summary>
        /// This method shows you how to delete a media.
        /// </summary>
        public void DeleteMedia()
        {
            try
            {
                // The ID of media you want to delete
                int media_id = int.MinValue;

                // Delete the media
                MediaService service = new MediaService(this.login, this.password);
                service.Library.Delete(media_id);

                // Display the result
                Console.WriteLine("Media {0} has been deleted", media_id);
            }
            catch (RemoteApiException api_ex)
            {
                // An API error is returned
                Console.WriteLine("#REMOTE# {0} : {1}", api_ex.Code, api_ex.Message);
            }
            catch (LocalApiException api_ex)
            {
                // A library error is returned
                Console.WriteLine("#LOCAL# {0}", api_ex.Message);
            }
            catch (System.Exception ex)
            {
                // An uncaught error is returned
                Console.WriteLine("~UNCAUGHT~ {0}", ex.Message);
            }
        }

        /// <summary>
        /// Entry point.
        /// </summary>
        /// <remarks>Uncomment the method you want to test.</remarks>
        static void Main()
        {
            // TODO : Don't forget to fill login and password in App.config file
            Program prog = new Program();

            // Upload a file in the library
            //prog.UploadFile();

            // Create a new with TTS generation
            //prog.TtsGeneration();

            // Delete a media
            //prog.DeleteMedia();
        }
    }
}
