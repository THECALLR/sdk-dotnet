
namespace CallrApi.Json
{
    /// <summary>
    /// This class represents data contained in a JSON-RPC response.
    /// </summary>
    public class JsonResponse
    {
        #region Member variables
        /// <summary>
        /// JSON-RPC protocol version.
        /// </summary>
        public string jsonrpc { get; set; }

        /// <summary>
        /// Method call result.
        /// </summary>
        /// <remarks>Set only in case of success call.</remarks>
        public object result { get; set; }

        /// <summary>
        /// Method call error.
        /// </summary>
        /// <remarks>Set only in case of error.</remarks>
        public JsonError error { get; set; }

        /// <summary>
        /// Related request ID.
        /// </summary>
        public int? id { get; set; }
        #endregion
    }
}
