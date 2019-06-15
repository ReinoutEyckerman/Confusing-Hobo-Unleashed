using System;
using System.Collections.Generic;
using System.Linq;

namespace Confusing_Hobo_Unleashed.Tools
{
    public static class EnumExtensions
    {
        public static T Next<T>(this T source) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));

            var array = (T[]) Enum.GetValues(source.GetType());
            int j = Array.IndexOf(array, source) + 1;
            return array.Length == j ? array[0] : array[j];
        }

        public static T Previous<T>(this T source) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));

            var array = (T[]) Enum.GetValues(source.GetType());
            int j = Array.IndexOf(array, source) - 1;
            return 0 == j ? array[array.Length - 1] : array[j];
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T Parse<T>(string input) where T : struct
        {
            return (T) Enum.Parse(typeof(T), input);
        }
    }
}