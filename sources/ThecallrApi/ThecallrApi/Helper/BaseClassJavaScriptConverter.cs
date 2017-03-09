using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using CallrApi.Objects;

namespace CallrApi.Helper
{
    /// <summary>
    /// This class is a converter for BaseClass objects.
    /// <remarks>
    /// A conversion is made :
    /// - to change DateTime output during serialization
    /// - to change BaseClass obect property names in the JSON serialized object
    /// </remarks>
    /// </summary>
    internal class BaseClassJavaScriptConverter : JavaScriptConverter
    {
        #region Member variables
        /// <summary>
        /// Property that defines converter class supported types.
        /// <remarks>In our case, we only support BaseClass class.</remarks>
        /// </summary>
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(BaseClass) }; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// This method converts the provided dictionary into an object of the specified type.
        /// </summary>
        /// <param name="dictionary">An instance of property data stored as name/value pairs.</param>
        /// <param name="type">The type of the resulting object.</param>
        /// <param name="serializer">The <see cref="System.Web.Script.Serialization.JavaScriptSerializer"/> instance.</param>
        /// <returns>The deserialized object.</returns>
        /// <remarks>We do not need to implement this method for our converter.</remarks>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method builds a dictionary of name/value pairs.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="serializer">The object that is responsible for the serialization.</param>
        /// <returns>An object that contains key/value pairs that represent the object’s data.</returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            IDictionary<string, object> serialized = new Dictionary<string, object>();
            if (obj != null)
            {
                foreach (PropertyInfo pi in obj.GetType().GetProperties())
                {
                    // Change the JSON property names
                    string propertyName = this.GetJsonPropertyName(pi.Name);
                    if (pi.PropertyType == typeof(DateTime))
                        // Translate DateTime to UTC
                        serialized[propertyName] = Tools.UtcDateString(((DateTime)pi.GetValue(obj, null)));
                    else
                        serialized[propertyName] = pi.GetValue(obj, null);
                }
            }
            return serialized;
        } 
        #endregion

        #region Private methods
        /// <summary>
        /// This method transfors PascalCase string to "pascal_case" string.
        /// </summary>
        /// <param name="propertyName">PascalCase string.</param>
        /// <returns>The string in "pascal_case" format.</returns>
        private string GetJsonPropertyName(string propertyName)
        {
            // Exception management
            List<string> exceptions = new List<string>()
            {
                "A_ringtone",
                "A_welcome",
                "AB_bridge",
                "B_whisper",
                "A_attempts",
                "A_retrypause",
                "A_vms_detect",
                "B_vms_detect"
            };
            if (exceptions.Contains(propertyName))
                return propertyName;
            StringBuilder buffer = new StringBuilder();
            // Split the string
            string[] stringArray = Regex.Split(propertyName, "([A-Z][a-z0-9]*)");
            foreach (string str in stringArray)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    if (buffer.Length > 0)
                        buffer.Append("_");
                    buffer.Append(str.ToLower());
                }
            }
            return buffer.Length == 0 ? propertyName : buffer.ToString();
        } 
        #endregion
    }
}
