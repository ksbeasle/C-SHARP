using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM.utils
{
    public class Validations
    {
        public static bool isValidBankPin(string pin)
        {
            Regex rx = new Regex(@"^[\d]{4}$"); // 4 digit pin only
            if (rx.IsMatch(pin)) // -- hopefully this works even as a string???
            {
                return true;
            }
            return false;
        }

        public static bool isValidUsername(string username)
        {
            if (username.Trim().Length == 0)  return false;
            if (username.Trim().Length > 16) return false;
            Regex rx = new Regex(@"^[a-zA-Z0-9]+$"); // letters/numbers only
            if(rx.IsMatch(username))
            {
                return true;
            }
            return false;
        }
    }
}
