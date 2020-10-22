using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfileBook
{
    public static class Validation
    {
        public static bool MatchesRequirements(string value)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");

            return hasNumber.IsMatch(value) && hasUpperChar.IsMatch(value) && hasLowerChar.IsMatch(value);
        }
        public static bool StartsWithNumber(string value)
        {
            var startsWithNumber = new Regex(@"^\d");

            return startsWithNumber.IsMatch(value);
        }
        public static bool PasswordsMatch(string password, string confirm)
        {
            if (confirm == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
