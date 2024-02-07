using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordValidatorV1 _Validate = new PasswordValidatorV1();
            Console.WriteLine(_Validate.Validate("0))))aAjuhgjhgjhgfjhgjhg)))"));
        }
    }
}
