using System.Globalization;

namespace RPSLS_Avalonia.Services
{
    /// <summary>Extension class to more easily parse Integers.</summary>
    public static class Int32Helper
    {
        /// <summary>Utilizes int.TryParse to easily parse an Integer.</summary>
        /// <param name="text">Text to be parsed</param>
        /// <returns>Parsed integer</returns>
        public static int Parse(string text)
        {
            int.TryParse(text, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out int temp);
            return temp;
        }
    }
}