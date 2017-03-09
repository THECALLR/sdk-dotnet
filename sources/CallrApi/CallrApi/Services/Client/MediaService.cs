using System;
using System.Collections.Generic;
using CallrApi.Json;
using CallrApi.Objects;
using CallrApi.Objects.Media;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class allows Media management (Library, Text-to-Speech, Recordings...).
    /// </summary>
    public class MediaService : ClientBaseService
    {
        #region Private members
        private NestedEmail _email = null;
        private NestedLibrary _library = null;
        private NestedTts _tts = null;
        #endregion

        #region Public members
        /// <summary>
        /// This class allows Media email management.
        /// </summary>
        public NestedEmail Email
        {
            get {
                if (_email == null) _email = new NestedEmail(this);
                return _email;
            }
        }

        /// <summary>
        /// This class allows Media library management.
        /// </summary>
        public NestedLibrary Library
        {
            get
            {
                if (_library == null) _library = new NestedLibrary(this);
                return _library;
            }
        }

        /// <summary>
        /// This class allows Media tts management.
        /// </summary>
        public NestedTts Tts
        {
            get
            {
                if (_tts == null) _tts = new NestedTts(this);
                return _tts;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public MediaService(string url, string login, string password)
            : base(url, login, password)
        {}

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public MediaService(string login, string password)
            : this(null, login, password)
        {}
        #endregion

        #region Class media/email
        /// <summary>
        /// This class allows Media email management.
        /// </summary>
        public class NestedEmail
        {
            private MediaService Parent;

            /// <summary>
            /// Constructor.
            /// </summary>
            public NestedEmail(MediaService parent)
            {
                this.Parent = parent;
            }
            /// <summary>
            /// This methods retireves email templates (used in Voicemails, recording alerts, etc.)
            /// </summary>
            /// <param name="templateType">Template type (possibles values are defined in <see cref="CallrApi.Enums.MediaEmailTemplates" /> class).</param>
            /// <returns>Dictionary (string key type, <see cref="CallrApi.Objects.Media.EmailTemplate" /> value type) object representing the list of available templates.</returns>
            /// <seealso cref="CallrApi.Enums.MediaEmailTemplates" />
            /// <seealso cref="CallrApi.Objects.Media.EmailTemplate" />
            public Dictionary<string, EmailTemplate> GetTemplates(string templateType)
            {
                List<object> parameters = new List<object>() { templateType };
                JsonResponse response = this.Parent.client.MakeRequest("media/email.get_templates", parameters);
                // MediaService.this.client
                return Helper.DictionaryCreator<string, EmailTemplate>.Object(response.result, "return");
            }
        }
        #endregion

        #region Class media/library
        /// <summary>
        /// This class allows Media library management.
        /// </summary>
        public class NestedLibrary
        {
            private MediaService Parent;

            /// <summary>
            /// Constructor.
            /// </summary>
            public NestedLibrary(MediaService parent)
            {
                this.Parent = parent;
            }
            /// <summary>
            /// This method creates a new MediaLibrary.
            /// </summary>
            /// <returns>Int object representing the media ID.</returns>
            public int Create(string name)
            {
                List<object> parameters = new List<object>() { name };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.create", parameters);
                return Helper.Converter<int>.ToObject(response.result, "return");
            }

            /// <summary>
            /// This method deletes a Media in the Library.
            /// </summary>
            /// <param name="mediaId">The media ID of the MediaLibrary to delete.</param>
            /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
            public bool Delete(int mediaId)
            {
                List<object> parameters = new List<object>() { mediaId };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.delete", parameters);
                return Helper.Converter<bool>.ToObject(response.result, "return");
            }

            /// <summary>
            /// This method retrieves a specific MediaLibrary.
            /// </summary>
            /// <param name="mediaId">Media ID.</param>
            /// <returns><see cref="CallrApi.Objects.Media.MediaLibrary" /> object representing the media.</returns>
            /// <seealso cref="CallrApi.Objects.Media.MediaLibrary" />
            public MediaLibrary Get(int mediaId)
            {
                List<object> parameters = new List<object>() { mediaId };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.get", parameters);
                return Helper.Creator<MediaLibrary>.Object(response.result, "return");
            }

            /// <summary>
            /// This method retrieves a list of Medias available in the Library by categories.
            /// </summary>
            /// <param name="categories">Filter by categories (possibles values are defined in <see cref="CallrApi.Enums.MediaLibraryCategories" /> class).</param>
            /// <returns>Dictionary (int key type, <see cref="CallrApi.Objects.Media.MediaLibrary" /> value type) object representing the medias.</returns>
            /// <seealso cref="CallrApi.Objects.Media.MediaLibrary"/>
            /// <seealso cref="CallrApi.Enums.MediaLibraryCategories" />
            public Dictionary<int, MediaLibrary> GetList(List<string> categories)
            {
                List<object> parameters = new List<object>() { categories };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.get_list", parameters);
                return Helper.DictionaryCreator<int, MediaLibrary>.Object(response.result, "return");
            }

            /// <summary>
            /// This method retrieves a DTMF sequence "phone_id" in order to record a MediaLibrary by phone.
            /// </summary>
            /// <param name="mediaId">The Media ID your want to record by phone.</param>
            /// <param name="countryCode">The country code you are in (we will give you a local phone number to call).</param>
            /// <returns><see cref="CallrApi.Objects.Media.PhoneId" /> object representing the Phone ID (DTMF sequence + phone number).</returns>
            /// <seealso cref="CallrApi.Objects.Media.PhoneId" />
            public PhoneId GetPhoneId(int mediaId, string countryCode)
            {
                List<object> parameters = new List<object>() { mediaId, countryCode };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.get_phone_id", parameters);
                return Helper.Creator<PhoneId>.Object(response.result, "return");
            }

            /// <summary>
            /// This method sets the MediaLibrary content with your own file.
            /// </summary>
            /// <param name="mediaId">The Media ID to change.</param>
            /// <param name="text">Text prompt (What is your Media saying?).</param>
            /// <param name="audioData">base64 encoded audio data file. Currently the file MUST BE "WAV" PCM encoded. 16 bit 48Khz mono is RECOMMENDED.</param>
            /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
            public bool SetContent(int mediaId, string text, string audioData)
            {
                List<object> parameters = new List<object>() { mediaId, text, audioData };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.set_content", parameters);
                return true;
            }

            /// <summary>
            /// This method sets MediaLibrary content from a recording previously created using Realtime command <c>record</c>.
            /// </summary>
            /// <param name="mediaId">The Media ID to change.</param>
            /// <param name="mediaFile">Recording path (<see cref="M:CallrApi.Services.Server.RealTimeService.Record"/>).</param>
            /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
            public bool SetContentFromRecording(int mediaId, string mediaFile)
            {
                List<object> parameters = new List<object>() { mediaId, mediaFile };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.set_content_from_recording", parameters);
                return true;
            }

            /// <summary>
            /// This method changes a MediaLibrary name.
            /// </summary>
            /// <param name="mediaId">The Media ID to change.</param>
            /// <param name="name">The new media name.</param>
            /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
            public bool SetName(int mediaId, string name)
            {
                List<object> parameters = new List<object>() { mediaId, name };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.set_name", parameters);
                return true;
            }

            /// <summary>
            /// This method sets Tags on a MediaLibrary.
            /// You can set as many tags as you want.
            /// </summary>
            /// <param name="media_id">The unique media id to edit.</param>
            /// <param name="tags">
            /// The tags to apply.
            /// It will completely replace previously set tags.
            /// <remarks>
            /// Special tag names :
            ///  * CATEGORY : if specified, values must be one of <see cref="CallrApi.Enums.MediaLibraryCategories" /> class.
            ///  * LANGUAGE : if specified, values must be in the form “en_US”, “en_GB”, “fr_FR”, etc.
            /// </remarks>
            /// </param>
            /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
            public bool SetTags(int media_id, Dictionary<string, List<string>> tags)
            {
                List<object> parameters = new List<object>() { media_id, tags };
                JsonResponse response = this.Parent.client.MakeRequest("media/library.set_tags", parameters);
                return Helper.Converter<bool>.ToObject(response.result, "return");
            }
        }
        #endregion

        #region Class media/tts
        /// <summary>
        /// This class allows Media tts management.
        /// </summary>
        public class NestedTts
        {
            private MediaService Parent;

            /// <summary>
            /// Constructor.
            /// </summary>
            public NestedTts(MediaService parent)
            {
                this.Parent = parent;
            }
            /// <summary>
            /// This method sets MediaLibrary content with Text-to-Speech.
            /// </summary>
            /// <param name="mediaId">The Media ID to change.</param>
            /// <param name="text">The text to say.</param>
            /// <param name="voice">A voice (possibles values are defined in <see cref="CallrApi.Enums.MediaTtsVoices" /> class).</param>
            /// <param name="options"><see cref="CallrApi.Objects.Media.TtsOptions" /> options.</param>
            /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
            /// <seealso cref="CallrApi.Objects.Media.TtsOptions" />
            /// <seealso cref="CallrApi.Enums.MediaTtsVoices" />
            public bool SetContent(int mediaId, string text, string voice, TtsOptions options)
            {
                List<object> parameters = new List<object>() { mediaId, text, voice, options };
                JsonResponse response = this.Parent.client.MakeRequest("media/tts.set_content", parameters);
                return true;
            }
        }
        #endregion
    }
}
