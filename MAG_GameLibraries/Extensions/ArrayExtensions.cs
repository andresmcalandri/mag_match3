using MAG_GameLibraries.Documentation;
using System;
using System.Collections.Generic;

namespace MAG_GameLibraries.Extensions
{
    [CustomerFacing]
    public static class ArrayExtensions
    {
        public static T[] Shuffle<T>(this T[] array)
        {
            var random = new Random();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                // Swap elements
                (array[i], array[j]) = (array[j], array[i]);
            }

            return array;
        }

        public static Stack<T> ToStack<T>(this T[] array)
        {
            var stack = new Stack<T>(array.Length);
            foreach (var item in array)
            {
                stack.Push(item);
            }

            return stack;
        }
    }
}
