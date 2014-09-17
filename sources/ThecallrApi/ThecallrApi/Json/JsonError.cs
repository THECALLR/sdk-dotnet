namespace ThecallrApi.Json
{
    /// <summary>
    /// This class represents a JSON-RPC format error.
    /// </summary>
    public class JsonError
    {
        #region Member variables
        /// <summary>
        /// Error type.
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// Error description.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Object containing more error details (optional).
        /// </summary>
        public object data { get; set; }
        #endregion
    }
}
