using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    /// <summary>
    /// Provides an extension method for converting the double array class to a string
    /// </summary>
    
    public static class DoubleArrayExtension
    {
        /// <summary>
        /// Converts double array to string
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>String representatin of double array</returns>
        public static string DoubleArrayToString(this double[] numbers)
        {
            string stringNumbers = "";
            foreach (var number in numbers)
                stringNumbers += $"{number} ";
            return stringNumbers;
        }
    }
}
