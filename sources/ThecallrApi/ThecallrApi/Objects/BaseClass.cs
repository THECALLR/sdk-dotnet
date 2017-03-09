using System.Collections.Generic;

namespace CallrApi.Objects
{
    /// <summary>
    /// This class represents the base class for JSON received objects.
    /// </summary>
    public abstract class BaseClass
    {
        #region Public methods
        /// <summary>
        /// This method initializes object properties from the parameter dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        public abstract void InitFromDictionary(Dictionary<string, object> dico);
        #endregion
    }
}
