using System;

namespace PasswordValidator
{
    /** Rules for valid password:
     *  1. Min length of 8 required
        2. Min of 1 capital letter required
        3. Min of 1 lowercase letter required
        4. Min of 1 non-alphanumeric character required
     */
    public class PasswordValidatorV1 : IPasswordValidator
    {
        public bool Validate(string password)
        {
            var passwordArray = password.ToCharArray();
            var allPassed = false;
            var lenCheck = false;
            var capCheck = false;
            var lowerCheck = false;
            var nonalphaCheck = false;

            foreach (var ch in password)
            {
                if(capCheck == false && Char.IsUpper(ch))
                {
                    capCheck = true;
                }
                else if (lowerCheck == false && Char.IsLower(ch))
                {
                    lowerCheck = true;
                }
                else if (nonalphaCheck == false && !Char.IsLetter(ch) && !Char.IsDigit(ch))
                {
                    nonalphaCheck = true;
                }
                
                if (password.Length > 7 && capCheck && lowerCheck && nonalphaCheck)
                {
                    lenCheck = true;
                    break;
                }
            }
            if (capCheck && lowerCheck && nonalphaCheck && lenCheck)
            {
                allPassed = true;
            }
            return allPassed;

        }
    }
}
