using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using PetGuadian.Application.Commands.PetsCommand;

namespace PetGuadian.Application.Commands.Contracts
{
    public class CustomContract<T> : Contract<T>
    {
        public CustomContract<T> CustomRequires()
        {
            return this;
        }
        public CustomContract<T> IsGenderValid(char gender, string message)
        {
            if (gender != 'M' && gender != 'F')
            {
                AddNotification(gender.ToString(), message);
            }

            return this;
        }

        public CustomContract<T> IsStringEmptyOrNull(string data, string message)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                AddNotification(data, message);
            }

            return this;
        }
    }
}