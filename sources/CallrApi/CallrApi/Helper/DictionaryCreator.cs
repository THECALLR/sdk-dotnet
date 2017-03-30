using System.Collections.Generic;
using CallrApi.Exception;
using CallrApi.Objects;

namespace CallrApi.Helper
{
    /// <summary>
    /// This class allows you to create a dictonary of objects in their internal types.
    /// </summary>
    /// <typeparam name="K">The dictionary key type (must be string or int).</typeparam>
    /// <typeparam name="T">The dictionary value type.</typeparam>
    internal class DictionaryCreator<K, T>
        where T : BaseClass, new()
    {
        /// <summary>
        /// This method returns an object value dictionary casted in the expected type.
        /// </summary>
        /// <param name="obj">Object to cast.</param>
        /// <param name="property">Property name (used in case of error).</param>
        /// <returns>A dictionary of key/value pairs of type K/T corresponding to the key associted value, otherwise the Dictionary with key / value pairs K / T type default value.</returns>
        public static Dictionary<K, T> Object(object obj, string property)
        {
            Dictionary<K, T> obj_dico = default(Dictionary<K, T>);
            if (obj != null)
            {
                if (obj.GetType() != typeof(Dictionary<string, object>))
                    throw new LocalApiException(string.Format("The '{0}' type of '{1}' property does not match the expected 'Dictionary<string, object>' type.", obj.GetType(), property));
                obj_dico = new Dictionary<K, T>();
                T new_obj;
                foreach (KeyValuePair<string, object> obj_loop in (Dictionary<string, object>)obj)
                {
                    new_obj = Helper.Creator<T>.Object(obj_loop.Value, string.Format("{0} (iteration)", property));
                    if (new_obj != null)
                        obj_dico.Add(Converter<K>.ToObject(obj_loop.Key, "key"), new_obj);
                }
            }
            return obj_dico;
        }
    }
}
