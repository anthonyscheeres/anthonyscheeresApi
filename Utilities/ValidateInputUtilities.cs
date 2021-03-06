﻿using System.Text.RegularExpressions;

namespace AnthonyscheeresApi.Utilities
{
    /**
	 * @author Anthony Scheeres
	 */
     internal class ValidateInputUtilities
    {


        /**
	 * @author Anthony Scheeres
	 */
         internal static bool isNullOrEmty(string theStringToCheckIfItsNullorEmty)
        {
            return theStringToCheckIfItsNullorEmty.Length == 0;
        }

        /**
	 * @author Anthony Scheeres
	 */
         internal static bool isNumeric(string s)
        {
            return Regex.IsMatch(s, @"^\d+$");
        }

        /**
	 * @author Anthony Scheeres
	 */
         internal static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
