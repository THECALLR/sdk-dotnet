using System.Collections.Generic;

namespace CallrApi.Objects.RealTime
{
    /// <summary>
    /// This class represents Realtime App. Allows you to control the call in realtime.
    /// </summary>
    public class RealTime : BaseClass
    {
        #region Member variables
        /// <summary>
        /// Data format. The only format supported right now is "JSON" (possible values are defined in <see cref="CallrApi.Enums.RealTimeDataFormats"/> class).
        /// </summary>
        public string DataFormat { get; set; }

        /// <summary>
        /// Login if your URL is password protected (HTTP Basic Authentication).
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password If your URL is password protected (HTTP Basic Authentication).
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Your URL callback. Our system will POST call status to your URL, and your answers will control the call.
        /// </summary>
        public string Url { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public override void InitFromDictionary(Dictionary<string, object> dico)
        {
            this.DataFormat = Helper.Converter<string>.ToObject(dico, "data_format");
            this.Login = Helper.Converter<string>.ToObject(dico, "login");
            this.Password = Helper.Converter<string>.ToObject(dico, "password");
            this.Url = Helper.Converter<string>.ToObject(dico, "url");
        }
        #endregion
    }
}
