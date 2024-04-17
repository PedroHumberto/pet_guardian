using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Queries.AddressQueries
{
    public sealed record AddressResponse(
        Guid id,
        string street,
        string number, 
        string complement, 
        string neighborhood, 
        string city, 
        string state, 
        string postalCode);

}