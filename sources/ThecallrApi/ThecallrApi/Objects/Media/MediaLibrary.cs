using System.Collections.Generic;

namespace ThecallrApi.Objects.Media
{
    /// <summary>
    /// This class represents a media library.
    /// </summary>
    public class MediaLibrary : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Media ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Media Hash ID.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Media name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Media text content if provided.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Media duration.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Text-to-Speech Voice ID (possible values are defined in <see cref="ThecallrApi.Enums.MediaTtsVoices"/> class).
        /// </summary>
        public string Voice { get; set; }

        /// <summary>
        /// Media status (possible values are defined in <see cref="ThecallrApi.Enums.MediaStatuses"/> class).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Media languages.
        /// </summary>
        public List<string> Language { get; private set; }

        /// <summary>
        /// Media categories (possible values are defined in <see cref="ThecallrApi.Enums.MediaLibraryCategories"/> class).
        /// </summary>
        public List<string> Category { get; private set; }

        /// <summary>
        /// Dictionary (key/value) of tags. Key is the tag key (string). Value in an array of string (tag values).
        /// </summary>
        public Dictionary<string, List<string>> Tags { get; set; }

        /// <summary>
        /// Media MP3 URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Is the media editable ?
        /// </summary>
        public bool IsEditable { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.Category = Helper.Converter<string>.ToObjectList(dico, "category");
            this.Content = Helper.Converter<string>.ToObject(dico, "content");
            this.Duration = Helper.Converter<int>.ToObject(dico, "duration");
            this.Hash = Helper.Converter<string>.ToObject(dico, "hash");
            this.Id = Helper.Converter<int>.ToObject(dico, "id");
            this.IsEditable = Helper.Converter<bool>.ToObject(dico, "is_editable");
            this.Language = Helper.Converter<string>.ToObjectList(dico, "language");
            this.Name = Helper.Converter<string>.ToObject(dico, "name");
            this.Status = Helper.Converter<string>.ToObject(dico, "status");
            this.Tags = Helper.Converter<string>.ToDictionaryList(dico, "tags");
            this.Url = Helper.Converter<string>.ToObject(dico, "url");
            this.Voice = Helper.Converter<string>.ToObject(dico, "voice");
        }
        #endregion
    }
}
