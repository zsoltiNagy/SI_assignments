using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlayWithRegex
{
    public class Validator
    {
        public static Boolean ValidName(string name)
        {
            string englishLetters = "a-z";
            string nonenglishLetters = @"\u0000-\u007F";
            string caseInsensitiveFlag = "(?i)";
            return Regex.IsMatch(name, @"[" + englishLetters
                                                       + caseInsensitiveFlag
                                                       + nonenglishLetters + "]+$");
        }
        public static Boolean ValidEmail(string email)
        {
            return Regex.IsMatch(email, @"[\w.+-]+@[\w.]+\.[a-z]+");
        }
        public static Boolean ValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^(\([\d]{3}\) |[\d]{3}-)[\d]{3}-[\d]{4}$");
        }

        public static string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s-]?(\d{3})\-?(\d{4})$");
            return String.Format("({0}) {1}-{2}",
                m.Groups[1], m.Groups[2], m.Groups[3]);
        }
    }
}
