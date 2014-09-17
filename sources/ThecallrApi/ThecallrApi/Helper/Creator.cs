using System.Collections.Generic;
using ThecallrApi.Exception;
using ThecallrApi.Objects;

namespace ThecallrApi.Helper
{
    /// <summary>
    /// This class allows you to create an object in its internal type.
    /// </summary>
    /// <typeparam name="T">
    /// The expected conversion type.
    /// <remarks>It must inherit from BaseClass.</remarks>
    /// </typeparam>
    internal static class Creator<T> where T : BaseClass, new()
    {
        /// <summary>
        ///  This method returns the key associted value in the dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        /// <param name="key">Key.</param>
        /// <returns>An object of type T corresponding to the key associted value, otherwise the T type default value.</returns>
        public static T Object(Dictionary<string, object> dico, string key)
        {
            if (dico != null && dico.ContainsKey(key))
                return Creator<T>.Object(dico[key], key);
            return default(T);
        }

        /// <summary>
        /// This method creates the value object in the expected type.
        /// </summary>
        /// <param name="obj">Object to cast.</param>
        /// <param name="property">Property name (used in case of error).</param>
        /// <returns>An oject of type T corresponding to the created object.</returns>
        public static T Object(object obj, string property)
        {
            T new_obj = default(T);
            if (obj != null)
            {
                if (obj.GetType() != typeof(Dictionary<string, object>))
                    throw new LocalApiException(string.Format("The '{0}' type of '{1}' property does not match the expected 'Dictionary<string, object>' type.", obj.GetType(), property));
                new_obj = new T();
                new_obj.InitFromDictionary((Dictionary<string, object>)obj);
            }
            return new_obj;
        }

        /// <summary>
        /// This method returns the key associted value list in the dictionary.
        /// </summary>
        /// <param name="dico">Dictionary.</param>
        /// <param name="key">Key.</param>
        /// <returns>An object list of type T corresponding to the key associted value, otherwise the T type default value.</returns>
        public static List<T> ObjectList(Dictionary<string, object> dico, string key)
        {
            if (dico != null && dico.ContainsKey(key))
                return Creator<T>.ObjectList(dico[key], key);
            return default(List<T>);
        }

        /// <summary>
        /// This method returns an object value list casted in the expected type.
        /// </summary>
        /// <param name="obj">Object to cast.</param>
        /// <param name="property">Property name (used in case of error).</param>
        /// <returns>An oject list of type T corresponding to the casted object.</returns>
        public static List<T> ObjectList(object obj, string property)
        {
            List<T> obj_list = default(List<T>);
            if (obj != null)
            {
                obj_list = new List<T>();
                T new_obj;
                if (obj.GetType() == typeof(Dictionary<string, object>))
                {
                    foreach (KeyValuePair<string, object> obj_loop in (Dictionary<string, object>)obj)
                    {
                        new_obj = Helper.Creator<T>.Object(obj_loop.Value, string.Format("{0} (iteration)", property));
                        if (new_obj != null)
                            obj_list.Add(new_obj);
                    }
                }
                else if (obj.GetType() == typeof(object[]))
                {
                    foreach (object obj_loop in (object[])obj)
                    {
                        new_obj = Helper.Creator<T>.Object(obj_loop, string.Format("{0} (iteration)", property));
                        if (new_obj != null)
                            obj_list.Add(new_obj);
                    }
                }
                else
                    throw new LocalApiException(string.Format("The '{0}' type of '{1}' property does not match one of the expected 'Dictionary<string, object>' or 'object[]' types.", obj.GetType(), property));
            }
            return obj_list;
        }
    }
}
