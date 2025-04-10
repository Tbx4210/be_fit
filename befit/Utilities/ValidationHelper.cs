using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace befit.Utilities
{
    public static class ValidationHelper
    {
        // Email Validation
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Uses .NET's built-in MailAddress class to validate email format
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email; // True if email is valid
            }
            catch
            {
                return false; // Invalid email format
            }
        }

        // Password Validation (min 6 chars)
        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }
    }
}
