using Flunt.Validations;

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