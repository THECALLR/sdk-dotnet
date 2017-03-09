using System;
using CallrApi.Json;

namespace CallrApi.Exception
{
    /// <summary>
    /// This class represents a remote API error.
    /// </summary>
    [Serializable]
    public class RemoteApiException : System.Exception
    {
        #region Member variables
        /// <summary>
        /// API error.
        /// </summary>
        public JsonError Error { get; private set; }

        /// <summary>
        /// Error Code.
        /// </summary>
        public int Code { get { return this.Error != null ? this.Error.code : 0; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="error">API Error.</param>
        public RemoteApiException(JsonError error)
            : base(error.message)
        {
            this.Error = error;
        } 
        #endregion
    }
}
