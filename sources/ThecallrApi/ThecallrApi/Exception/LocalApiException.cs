
using System;
namespace ThecallrApi.Exception
{
    /// <summary>
    /// This class represents an internal library error.
    /// </summary>
    [Serializable]
    public class LocalApiException : System.Exception
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public LocalApiException(string message, System.Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public LocalApiException(string message)
            : base(message)
        { } 
        #endregion
    }
}
