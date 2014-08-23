using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineCatalog.Infrastructure.Helpers
{
    /// <summary>
    /// Provides helper methods to work with enumerations in the application
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the name of the enumberation with for the provided value
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">Value of the enum</param>
        /// <returns>String name</returns>
        public static string Name<T>(Enum value)
        {
            return Enum.GetName(typeof(T), value);
        }

        /// <summary>
        /// Gets the list of enumeration names for an enum type
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <returns>List of string of names for the enum type</returns>
        public static List<string> Names<T>()
        {
            var names = Enum.GetNames(typeof(T));
            return names.ToList();
        }
    }
}
