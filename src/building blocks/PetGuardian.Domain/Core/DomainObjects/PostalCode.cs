using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Core.DomainObjects
{
    public class PostalCode
    {
        public string Number { get; private set; }

        protected PostalCode() { }
        public PostalCode(string postalCode)
        {
            if (!IsValidPostalCode(postalCode)) throw new Exception("Invalid Format");
            Number = postalCode;
        }
        // Método para verificar se um código postal tem um formato válido
        public static bool IsValidPostalCode(string postalCode)
        {
            // Usando uma expressão regular para verificar o formato
            // Este exemplo assume que um código postal válido tem o formato "XXXXX-XXX" ou "XXXXX"
            string pattern = @"^\d{5}(-\d{3})?$";
            return Regex.IsMatch(postalCode, pattern);
        }
    }
}
