using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using ThecallrApi.Helper;
using ThecallrApi.Objects.RealTime;

/// <summary>
/// Summary description for RealTimeJavascriptSerializer
/// </summary>
public class RealTimeResponseJavascriptConverter : JavaScriptConverter
{
    #region Member variables
    /// <summary>
    /// Property that defines the converter class supported types.
    /// <remarks>In our example, we only support RealTimeResponse class for serialization.</remarks>
    /// </summary>
    public override IEnumerable<Type> SupportedTypes
    {
        get { return new[] { typeof(RealTimeResponse) }; }
    }
    #endregion

    #region Public methods
    /// <summary>
    /// We do not need to implement this method.
    /// </summary>
    public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This method allows you to serialize a RealTimeResponse object according to fixed rules :
    /// - all PasclaCase property names will be translated in "pascal_case" format into JSON object
    /// - all DateTime properties will be translated into UTC date
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
                string propertyName = this.GetJsonPropertyName(pi.Name);
                if (pi.PropertyType == typeof(DateTime))
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
    /// This method transforms a PascalCase format string to a "pascal_case" one.
    /// </summary>
    /// <param name="propertyName">PascalCase string.</param>
    /// <returns>The string in "pascal_case" format.</returns>
    private string GetJsonPropertyName(string propertyName)
    {
        StringBuilder buffer = new StringBuilder();
        // Split the string
        string[] stringArray = Regex.Split(propertyName, "([A-Z]+[a-z0-9]*)");
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