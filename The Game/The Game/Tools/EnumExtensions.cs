using System;

namespace Confusing_Hobo_Unleashed.Tools
{
    public static class EnumExtensions
    {
        public static T Next<T>(this T source) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            T[] array = (T[]) Enum.GetValues(source.GetType());
            int j = Array.IndexOf<T>(array, source) + 1;
            return (array.Length == j) ? array[0] : array[j];
        }
        
        public static T Previous<T>(this T source) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            T[] array = (T[]) Enum.GetValues(source.GetType());
            int j = Array.IndexOf<T>(array, source) - 1;
            return (0 == j) ? array[array.Length-1] : array[j];
        }
    }
}