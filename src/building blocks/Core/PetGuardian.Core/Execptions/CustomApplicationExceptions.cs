using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardian.Core.Exceptions
{
    public class CustomApplicationExceptions : Exception
    {
        private const string DefaultErrorMessage = "Invalid Parameters";

        public CustomApplicationExceptions(string message = DefaultErrorMessage) : base(message) { }

        public static void ThrowIfNullOrWhiteSpace(string? item, string paramName, string message = DefaultErrorMessage)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new CustomApplicationExceptions($"{paramName} : {message}");
        }

        public static void ThrowIfAListOfObjectsIsNullOrEmpty(object? item, string paramName, string message = DefaultErrorMessage)
        {
            if (item is null)
                throw new CustomApplicationExceptions($"{paramName} : {message}");
        }

        public static void ThrowIfAListOfObjectsIsNullOrEmpty<T>(IEnumerable<T>? collection, string paramName, string message = DefaultErrorMessage)
        {
            if (collection == null || !collection.Any())
                throw new CustomApplicationExceptions($"{paramName} : {message}");
        }
        public static void ThrowIfResultIsNotSucceeded(bool succeeded, string resultErrorMessage, string errors){
            if(!succeeded)
            {
                throw new CustomApplicationExceptions($"{resultErrorMessage}: {errors}");
            }
        }

    }
}
