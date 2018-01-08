using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using PropertyInfo = System.Reflection.PropertyInfo;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// Class XtrmAddons Object Extensions.
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
        ///  Method to get property value of an object.
        /// </summary>
        /// <param name="target">Target object.</param>
        /// <param name="name">A name of a property.</param>
        /// <returns></returns>
        public static object GetProperty(this object target, string name)
        {
            try
            {
                var site = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(0, name, target.GetType(), new[] { CSharpArgumentInfo.Create(0, null) }));
                return site.Target(site, target);
            }
            catch (Exception e)
            {
                log.Fatal("OjectExtension get object property. Failed !");
                log.Fatal(target);
                log.Fatal(string.Format("string property : {0} ", name));
                log.Fatal(e.Message);
                log.Fatal(e.StackTrace);

                throw new InvalidOperationException("OjectExtension get object property. Failed !", e);
            }
        }

        /// <summary>
        /// Method to check if has a property or its set to null.
        /// </summary>
        /// <typeparam name="T">The object class type.</typeparam>
        /// <param name="obj">The object to search in.</param>
        /// <param name="propertyName">A name of a property.</param>
        /// <returns>True if exists and not null otherwise false.</returns>
        public static bool HasPropertyOrNull<T>(this T obj, string propertyName) where T : class
        {
            return obj.GetProperty(propertyName) != null;
        }

        /// <summary>
        /// Method to bind public properties of an objet to another of the same type.
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
                    prop.SetValue(obj, binding.GetProperty(prop.Name));
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