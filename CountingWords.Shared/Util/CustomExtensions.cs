using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CountingWords.Shared.Util
{
    public static class CustomExtensions
    {
        /// <summary>
        /// Delete all values duplicates in array.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<int> DeleteDuplicateNumbers(this int[] values)
        {
            return values.Distinct();
        }
        /// <summary>
        /// Delete all value duplicate at string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// An IEnumerable of strings
        /// </returns>
        public static IEnumerable<string> CompareStrings(this string value)
        {

            var values = Regex.Split(value.ToLower(), @"[^\w0-9-]+")
                              .Where(x => !string.IsNullOrWhiteSpace(x)).Distinct();

            return values;
        }
    }
}
