using System;
using System.Collections;
using System.Reflection;
using System.Text;
using ThecallrApi.Objects;

namespace ThecallrApi.Helper
{
    /// <summary>
    /// This class gives usefull helpers.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Date and Time format used by the API.
        /// </summary>
        public static readonly string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// This method lets you display an object content.
        /// </summary>
        /// <param name="obj">The object to display.</param>
        /// <param name="depth">The current depth of recursion.</param>
        /// <returns>A string containing the object dump.</returns>
        public static string ObjectDump(object obj, int depth = 0)
        {
            StringBuilder buffer = new StringBuilder();
            if (obj == null)
                return string.Empty;
            if (depth < 5)
            {
                try
                {
                    // Display variables
                    string indent = String.Empty;
                    string spaces = "|   ";
                    string trail = "|...";
                    // Reflexion
                    Type type = obj.GetType();
                    if (typeof(ICollection).IsInstanceOfType(obj))
                    {
                        int elementCount = 0;
                        foreach (var item in (ICollection)obj)
                        {
                            string elementName = String.Format("[{0}]", elementCount);
                            if (depth > 0)
                                indent = new StringBuilder(string.Empty).Insert(0, spaces, depth).ToString();
                            buffer.AppendFormat("{0}{1} = {2}{3}", indent, elementName, item.ToString(), Environment.NewLine);
                            buffer.Append(ObjectDump(item, depth + 1));
                            elementCount++;
                        }
                    }
                    else
                    {
                        PropertyInfo[] properties = type.GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                             object value = property.GetValue(obj, null);
                            // Indent management
                            if (depth > 0)
                                indent = new StringBuilder(trail).Insert(0, spaces, depth - 1).ToString();
                            if (value != null)
                            {
                                // If the value is a string, add quotation marks
                                string displayValue = value.ToString();
                                if (value is string)
                                    displayValue = String.Concat('"', displayValue, '"');
                                // Add property name and value to return string
                                buffer.AppendFormat("{0}{1} = {2}{3}", indent, property.Name, displayValue, Environment.NewLine);
                                // Collection management
                                if (value is ICollection)
                                    buffer.Append(ObjectDump(value, depth));
                                else if (value is BaseClass)
                                    buffer.Append(ObjectDump(value, depth + 1));
                            }
                            else
                                buffer.AppendFormat("{0}{1} = {2}{3}", indent, property.Name, "null", Environment.NewLine);
                        }
                    }
                }
                catch { }
            }
            return buffer.ToString();
        }

        /// <summary>
        /// This method returns the date in UTC and API waiting format string.
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>The date in UTC and API waiting format string.</returns>
        public static string UtcDateString(DateTime date)
        {
            return date.ToUniversalTime().ToString(Tools.DATETIME_FORMAT);
        }
    }
}
