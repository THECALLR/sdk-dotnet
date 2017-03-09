using System;
using System.Collections.Generic;
using System.Globalization;
using CallrApi.Exception;

namespace CallrApi.Helper
{
    /// <summary>
    /// This class allows you to convert an object in its internal type.
    /// </summary>
    /// <typeparam name="T">The expected conversion type.</typeparam>
    internal static class Converter<T>
    {
        /// <summary>
        /// This method returns the key associted value in the dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        /// <param name="key">Key.</param>
        /// <returns>An object of type T corresponding to the key associted value, otherwise the T type default value.</returns>
        public static T ToObject(Dictionary<string, object> dico, string key)
        {
            // Existence check
            if (dico != null && dico.ContainsKey(key))
                return Converter<T>.ToObject(dico[key], key);
            return default(T);
        }

        /// <summary>
        /// This method casts object value in the expected type.
        /// </summary>
        /// <param name="obj">Object to cast.</param>
        /// <param name="property">Property name (used in case of error).</param>
        /// <returns>An oject of type T corresponding to the casted object.</returns>
        public static T ToObject(object obj, string property)
        {
            T result = default(T);
            if (obj != null)
            {
                if (obj.GetType() == typeof(T))
                    result = (T)obj;
                else if (obj.GetType() == typeof(string))
                {
                    if (typeof(T) == typeof(DateTime))
                    {
                        if (obj.ToString() != "0000-00-00 00:00:00")
                            result = (T)((object)DateTime.ParseExact(obj.ToString(), Tools.DATETIME_FORMAT, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AssumeUniversal));
                        else
                            result = (T)((object)DateTime.MinValue);
                    }
                    else if (typeof(T) == typeof(decimal))
                    {
                        string number = obj.ToString();
                        number = number.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        result = (T)((object)Decimal.Parse(number));
                    }
                    else if (typeof(T) == typeof(bool))
                    {
                        result = (T)((object)Boolean.Parse(obj.ToString()));
                    }
                    else if (typeof(T) == typeof(int))
                    {
                        result = (T)((object)Int32.Parse(obj.ToString()));
                    }
                }
                else
                    throw new LocalApiException(string.Format("The '{0}' type of '{1}' property does not match the expected '{2}' type.", obj.GetType(), property, typeof(T).ToString()));
            }
            return result;
        }

        /// <summary>
        /// This method returns the key associted value list in the dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        /// <param name="key">Key.</param>
        /// <returns>An object list of type T corresponding to the key associted value, otherwise the T type default value.</returns>
        public static List<T> ToObjectList(Dictionary<string, object> dico, string key)
        {
            if (dico != null && dico.ContainsKey(key))
                return Helper.Converter<T>.ToObjectList(dico[key], key);
            return default(List<T>);
        }

        /// <summary>
        /// This method returns an object value list casted in the expected type.
        /// </summary>
        /// <param name="obj">Object to cast.</param>
        /// <param name="property">Property name (used in case of error).</param>
        /// <returns>An oject list of type T corresponding to the casted object.</returns>
        public static List<T> ToObjectList(object obj, string property)
        {
            List<T> obj_list = default(List<T>);
            if (obj != null)
            {
                if (obj.GetType() != typeof(object[]))
                    throw new LocalApiException(string.Format("The '{0}' type of '{1}' property does not match the expected 'object[]' type.", obj.GetType(), property));
                obj_list = new List<T>();
                T new_obj;
                foreach (object obj_loop in (object[])obj)
                {
                    new_obj = Helper.Converter<T>.ToObject(obj_loop, string.Format("{0} (iteration)", property));
                    if (new_obj != null)
                        obj_list.Add(new_obj);
                }
            }
            return obj_list;
        }

        /// <summary>
        /// This method returns the key associted value dictionary in the dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        /// <param name="key">Key.</param>
        /// <returns>A dictionary of key/value pairs of type string/List of T corresponding to the key associted value, otherwise the Dictionary with key / value pairs string / List of T type default value.</returns>
        public static Dictionary<string, List<T>> ToDictionaryList(Dictionary<string, object> dico, string key)
        {
            Dictionary<string, List<T>> obj_dico = default(Dictionary<string, List<T>>);
            if (dico != null && dico.ContainsKey(key) && dico[key] != null)
            {
                if (dico[key].GetType() != typeof(Dictionary<string, object>))
                    throw new LocalApiException(string.Format("The '{0}' type of '{1}' property does not match the expected 'Dictionary<string, object[]>' type.", dico[key].GetType(), key));
                obj_dico = new Dictionary<string, List<T>>();
                List<T> new_obj;
                foreach (KeyValuePair<string, object> obj_loop in (Dictionary<string, object>)dico[key])
                {
                    new_obj = Helper.Converter<T>.ToObjectList(obj_loop.Value, string.Format("{0} (iteration)", key));
                    if (new_obj != null)
                        obj_dico.Add(obj_loop.Key, new_obj);
                }
            }
            return obj_dico;
        }
    }
}
