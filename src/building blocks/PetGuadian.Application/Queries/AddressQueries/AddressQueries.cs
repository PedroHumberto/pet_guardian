using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetGuardian.Domain.Models;

namespace PetGuadian.Application.Queries.AddressQueries
{
    public class AddressQueries
    {
        public static Expression<Func<Address, bool>> GetAddressById(Guid addressId)
        {

            return a => a.Id == addressId;
        }
    }
}