using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    class Search
    {
        public static bool LinearSearch(int[] array, int length, int element)
        {
            // Check for edge cases
            if (array == null || length == 0)
            {
                return false;
            }

            // Check each element starting from the first one
            for (int i = 0; i < length; i++)
            {
                // We found the element at index i, so return true.
                if (array[i] == element)
                {
                    return true;
                }
            }

            // We didn't find the element in the array.
            return false;
        }
    }
}
