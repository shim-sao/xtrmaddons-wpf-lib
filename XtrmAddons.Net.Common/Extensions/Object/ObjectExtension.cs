using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Linq;
using PropertyInfo = System.Reflection.PropertyInfo;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// <para>Class XtrmAddons Net Common Object Extensions.</para>
    /// <para>This Class add some methods object by extension.</para>
    /// </summary>
    public static class ObjectExtension
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        #region Methods

        /// <summary>
        /// Method to get a value of a property of an object.
        /// </summary>
        /// <param name="obj">The object to search in.</param>
        /// <param name="propertyName">The property name to get value.</param>
        /// <param name="ignorecase">Should ignore property name case ?</param>
        /// <returns>The value of the property. Null if object is null otherwise, throw an exception.</returns>
        /// <exception cref="ArgumentException">Occur if the property is not found.</exception>
        /// <exception cref="InvalidOperationException">See inner exception for details.</exception>
        public static object GetPropertyValue<T>(this T obj, string propertyName, bool ignorecase = false) where T : class
        {
            if(obj == null)
            {
                return null;
            }

            try
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(obj.GetType()).Find(propertyName, ignorecase);

                if(prop != null)
                {
                    return prop.GetValue(obj);
                }

                throw new ArgumentException(String.Format("Object [{0}] property '{1}' doesn't exists !", obj.GetType(), propertyName));
            }
            catch (Exception e)
            {
                log.Fatal("OjectExtension.GetPropertyValue Failed !", e);
                throw new InvalidOperationException("OjectExtension.GetPropertyValue Failed !", e);
            }
        }

        /// <summary>
        /// Method to check if has a property not null.
        /// </summary>
        /// <typeparam name="T">The object class type.</typeparam>
        /// <param name="obj">The object to search in.</param>
        /// <param name="propertyName">A name of a property.</param>
        /// <returns>True if exists and not null otherwise false.</returns>
        public static bool HasPropertyNotNull<T>(this T obj, string propertyName) where T : class
        {
            return obj.GetPropertyValue(propertyName) != null;
        }

        /// <summary>
        /// Method to check if has a property.
        /// </summary>
        /// <typeparam name="T">The object Class.</typeparam>
        /// <param name="obj">The object to search in.</param>
        /// <param name="propertyName">A name of a property.</param>
        /// <param name="ignorecase">Ignore sensitive case ?.</param>
        /// <returns>True if the property exists in this object type otherwise false.</returns>
        public static bool HasProperty(this object obj, string propertyName, bool ignorecase = false)
        {
            try
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(obj.GetType()).Find(propertyName, ignorecase);
                return prop != null;
            }
            catch (Exception e)
            {
                log.Fatal("OjectExtension.HasProperty Failed !", e);
                throw new InvalidOperationException("OjectExtension.HasProperty Failed !", e);
            }
        }

        /// <summary>
        /// Method to bind public properties of an object to another of the same type.
        /// </summary>
        /// <typeparam name="T">The object class type.</typeparam>
        /// <param name="obj">The object to bind in.</param>
        /// <param name="binding">The object to bind</param>
        /// <param name="ignore">An array of properties to ignore.</param>
        public static void Bind<T>(this T obj, T binding, string[] ignore = null) where T : class
        {
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (ignore != null && !ignore.Contains(prop.Name))
                {
                    prop.SetValue(obj, binding.GetPropertyValue(prop.Name));
                }
            }
        }

        /// <summary>
        /// Method to bind public properties of an object to another.
        /// </summary>
        /// <typeparam name="T">The object class type.</typeparam>
        /// <param name="obj">The object to bind in.</param>
        /// <param name="binding">The object to bind</param>
        /// <param name="ignore">An array of properties to ignore.</param>
        public static void Bind<T>(this T obj, object binding, string[] ignore = null) where T : class
        {
            PropertyInfo[] props = binding.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (obj.HasProperty(prop.Name) && ignore != null && !ignore.Contains(prop.Name))
                {
                    prop.SetValue(obj, binding.GetPropertyValue(prop.Name));
                }
            }
        }

        /// <summary>
        /// Method to initialize null properties of the Object.
        /// </summary>
        /// <typeparam name="T">The object class type.</typeparam>
        /// <param name="obj">The object to bind in.</param>
        /// <param name="ignore">An array of properties to ignore.</param>
        public static void InitializeNulls<T>(this T obj, string[] ignore = null) where T : class
        {
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(obj) == null)
                {
                    if(prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(obj, "");
                    }

                    else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(double))
                    {
                        prop.SetValue(obj, 0);
                    }

                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        prop.SetValue(obj, DateTime.Now);
                    }
                }
            }
        }

        /// <summary>
        /// Method to clone with public properties the Object.
        /// </summary>
        /// <typeparam name="T">The object class type.</typeparam>
        /// <param name="obj">The object to clone.</param>
        /// <returns>A new object with cloned public properties.</returns>
        public static T Clone<T>(this T obj) where T : class
        {
            T instance = Activator.CreateInstance<T>();
            instance.Bind(obj);
            return instance;
        }

        /// <summary>
        /// Method to set an object property value.
        /// </summary>
        /// <param name="obj">The object to set property value.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        public static void SetPropertyValue(this object obj, string propertyName, object value)
        {
            object[] values = new object[] { value };

            PropertyInfo prop = obj.GetType()
                .GetProperty
                (
                    propertyName,
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance
                );

            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
            }
        }

        /// <summary>
        /// Method to get instance to Json string format.
        /// </summary>
        /// <param name="obj">The object to convert to Json.</param>
        /// <returns>Json instance serialization.</returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(
                obj,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }
            );
        }

        #endregion
    }
}