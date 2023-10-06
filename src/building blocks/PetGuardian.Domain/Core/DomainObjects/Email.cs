using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Core.DomainObjects
{
    public class Email
    {
        public const int EmailMaxLen = 254;
        public const int EmailMinLen = 5;
        public string EmailAddress { get; private set; }

        public Email() { }

        public Email(string emailAddress) 
        {
            // CRIAR UMA EXCEPTION DEPOIS
            if (!EmailValidation(emailAddress)) throw new Exception("Invalid Email");
            EmailAddress = emailAddress;
        }
        public static bool EmailValidation(string emailAddress)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(emailAddress);
        }
        
    }
}