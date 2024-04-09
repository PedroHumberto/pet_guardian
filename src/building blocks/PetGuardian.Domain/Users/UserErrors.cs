using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Domain.Abstractions;

namespace PetGuardian.Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound = new("User.NotFound", "The user with the specified identifier was not found");
        public static Error Overlap = new("User.Overlap", "The current user is overlapping with an existing one");
        public static Error NotReserverd = new("User.NotReserverd", "The user is not pending");
        public static Error NotConfirmed = new("User.NotConfirmed", "The user is not confirmed");
    }
}