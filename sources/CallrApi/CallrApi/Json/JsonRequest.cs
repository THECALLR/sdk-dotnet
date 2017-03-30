using System.Text;
using System.Web.Script.Serialization;

namespace CallrApi.Json
{
    /// <summary>
    /// This class represents data sent to API server during a JSON-RPC request.
    /// </summary>
    public class JsonRequest
    {
        #region Member variables
        /// <summary>
        /// Request ID.
        /// The server will respond with the same ID in order to identify it.
        /// </summary>
        /// <remarks>Object type can be int, string or null.</remarks>
        public int? id { get; private set; }

        /// <summary>
        /// JSON-RPC protocol version to use.
        /// </summary>
        public string version { get; private set; }

        /// <summary>
        /// Method to process on the server.
        /// </summary>
        public string method { get; private set; }

        /// <summary>
        /// Structured object acting as the method parameter.
        /// </summary>
        public object parameters { get; private set; } 
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Request ID.</param>
        /// <param name="method">Method to process.</param>
        /// <param name="parameter">Method parameter.</param>
        public JsonRequest(int? id, string method, object parameter)
        {
            this.version = "2.0";
            this.id = id;
            this.method = method;
            this.parameters = parameter;
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Build the request in JSON-RPC format.
        /// </summary>
        /// <returns>The request in JSON-RPC format.</returns>
        /// <seealso cref="System.Web.Script.Serialization.JavaScriptSerializer"/>
        public string GetJson()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.RegisterConverters(new[] { new CallrApi.Helper.BaseClassJavaScriptConverter() });
            StringBuilder buffer = new StringBuilder();

            buffer.Append("{");
            buffer.AppendFormat("\"jsonrpc\": {0}", js.Serialize(this.version));
            buffer.AppendFormat(", \"method\": {0}", js.Serialize(this.method));
            buffer.AppendFormat(", \"params\": {0}", js.Serialize(this.parameters));
            if (this.id.HasValue)
                buffer.AppendFormat(", \"id\": {0}", js.Serialize(this.id));
            buffer.Append("}");
            return buffer.ToString();
        } 
        #endregion
    }
}
