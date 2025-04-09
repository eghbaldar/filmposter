using System.Text;

namespace FIlmposter.Utilities.Helpers
{
    public class PersianNumberHelper
    {
        private static readonly Dictionary<char, char> PersianToArabicNumericMap = new Dictionary<char, char>
    {
        {'0', '0'},
        {'1', '1'},
        {'2', '2'},
        {'3', '3'},
        {'4', '4'},
        {'5', '5'},
        {'6', '6'},
        {'7', '7'},
        {'8', '8'},
        {'9', '9'}
    };

        private static readonly Dictionary<char, char> ArabicToPersianNumericMap = new Dictionary<char, char>
    {
        {'0', '۰'},
        {'1', '۱'},
        {'2', '۲'},
        {'3', '۳'},
        {'4', '۴'},
        {'5', '۵'},
        {'6', '۶'},
        {'7', '۷'},
        {'8', '۸'},
        {'9', '۹'}
    };

        public static string ConvertToPersian(string input)
        {
            var sb = new StringBuilder();
            foreach (var c in input)
            {
                if (ArabicToPersianNumericMap.TryGetValue(c, out var persianChar))
                {
                    sb.Append(persianChar);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string ConvertToArabic(string input)
        {
            var sb = new StringBuilder();
            foreach (var c in input)
            {
                if (PersianToArabicNumericMap.TryGetValue(c, out var arabicChar))
                {
                    sb.Append(arabicChar);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
