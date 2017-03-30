using CallrApi.Json;

namespace CallrApi.Services.Client
{
    /// <summary>
    /// This class is the base class of all API services.
    /// </summary>
    public abstract class ClientBaseService
    {
        #region Member variables
        /// <summary>
        /// Object that manages JSON RPC requests.
        /// </summary>
        protected JsonRpcClient client { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public ClientBaseService(string url, string login, string password)
        {
            this.client = new JsonRpcClient(url, login, password);
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public ClientBaseService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion
    }
}
