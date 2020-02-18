using System;
using System.Globalization;
using System.IO;
namespace MYOB.PayslipGenerator.Utilities
{
    /// <summary>
    /// Common extensions
    /// </summary>
    public static class Extensions
    {
        private static readonly int firstMonthInYear = 4;

        /// <summary>
        /// Converts a float to decimal
        /// </summary>
        /// <param name="value">float value to be converted</param>
        /// <returns>a decimal value</returns>

        public static decimal ToDecimal(this float value)
        {
            var result = 0.0M;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Converts a string to decimal
        /// </summary>
        /// <param name="value">string value to be converted</param>
        /// <returns>a decimal value</returns>
        public static decimal ToDecimal(this string value)
        {
            var result = 0.0M;
            decimal.TryParse(value, out result);
            return result;
        }

        /// <summary>
        /// Converts a decimal to float
        /// </summary>
        /// <param name="value">decimal value to be converted</param>
        /// <returns>a float value</returns>
        public static float ToFloat(this decimal value)
        {
            var result = 0.0F;
            float.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Converts a string to Datetime
        /// </summary>
        /// <param name="value">string value to be converted</param>
        /// <returns>a datetime value</returns>
        public static DateTime ToDate(this string value)
        {
            var result = DateTime.MinValue;
            DateTime.TryParse(value, out result);
            return result;
        }

        /// <summary>
        /// Get Tax year from date
        /// </summary>
        /// <param name="date">date value</param>
        /// <returns>tax year value</returns>
        public static int GetTaxYear(this DateTime date)
        {
            return date.Month < firstMonthInYear ? date.Year + 1 : date.Year;

        }

        /// <summary>
        /// Get month name from month
        /// </summary>
        /// <param name="month">month value</param>
        /// <returns>name of the month</returns>
        public static string GetMonthName(this int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }

        /// <summary>
        /// Get short month name from month
        /// </summary>
        /// <param name="month">month value</param>
        /// <returns>name of the month</returns>
        public static string GetShortMonthName(this int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
        }

        /// <summary>
        /// Returns a padded string, with zero padded to left
        /// </summary>
        /// <param name="digit">number to be padded with zero</param>
        /// <param name="padCount">number of zeros to be padded</param>
        /// <returns></returns>
        public static string GetPaddedString(this int digit, int padCount)
        {
            return digit.ToString().PadLeft(padCount, Constants.PadZero);
        }

        /// <summary>
        /// Returns a rounded value
        /// </summary>
        /// <param name="value">value to be rounded</param>
        /// <returns>decimal value after rounding</returns>
        public static decimal Round(this decimal value)
        {
            return Math.Round(value);
        }

        /// <summary>
        /// Converts a decimal to its percentage
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <returns>converted value in decimal</returns>
        public static decimal ToPercentage(this decimal value)
        {
            return value * 0.01M;
        }

        /// <summary>
        /// Gets full file path
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>file path</returns>
        public static string GetFilePath(this string fileName)
        {
            return Path.Combine(Path.GetDirectoryName(fileName), fileName);
        }

        /// <summary>
        /// Rename the file if the file path exists
        /// </summary>
        /// <param name="filePath">file name</param>
        /// <returns>new file name</returns>
        public static string RenameIfFileExists(this string filePath)
        {
            int count = 1;

            string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string path = Path.GetDirectoryName(filePath);
            string newFullPath = filePath;

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
            }
            return newFullPath;
        }

        /// <summary>
        /// Returns numbers of days in month
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>numbers of days in month</returns>
        public static int DaysInMonth(this DateTime value)
        {
            return value == null || value == DateTime.MinValue ? 0 : DateTime.DaysInMonth(value.Year, value.Month);
        }

        /// <summary>
        /// Returns a float value
        /// </summary>
        /// <param name="value">interger value to be converted</param>
        /// <returns>float value</returns>
        public static float ToFloat(this int value)
        {
            var result = 0.0F;
            float.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Returns a decimal value
        /// </summary>
        /// <param name="value">interger value to be converted</param>
        /// <returns>decimal value</returns>
        public static decimal ToDecimal(this int value)
        {
            var result = 0.0M;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }
    }
}
