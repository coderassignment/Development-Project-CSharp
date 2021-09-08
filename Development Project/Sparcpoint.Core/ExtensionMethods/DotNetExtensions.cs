using System;

namespace UAL.ATW.Core.Extensions
{
    /// <summary>
    /// Class for extension method generated for .net classes
    /// Only Add Extension method if you are adding an extension method on .net Type system.
    /// </summary>
    public static partial class DotNetExtensions
    {
        /// <summary>
        /// Throws an Argument Null exception if the string is null or
        /// ArgumentException if the string is empty or whitespaces only
        /// </summary>
        /// <param name="inputStringToValidate"></param>
        public static void ThrowExIfIsNullOrWhiteSpace(this string inputStringToValidate, string nameOfProperty = "")
        {
            if (String.IsNullOrWhiteSpace(inputStringToValidate))
                throw new ArgumentNullException(nameOfProperty ?? inputStringToValidate,
                    "The input string is null or empty");
        }
    }
}
