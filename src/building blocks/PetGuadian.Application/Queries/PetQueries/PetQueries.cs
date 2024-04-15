using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.PetDto;
using PetGuardian.Domain.Models;

namespace PetGuadian.Application.Queries.PetQueries
{
    public class PetQueries
    {
        public static Expression<Func<Pet, bool>> GetAllPetsByUserIdQuery(Guid userId)
        {
            return pet => pet.UserId == userId;
        }
        public static Expression<Func<Pet, bool>> GetPetByIdQuery(Guid userId, Guid petId)
        {
            return p => p.Id == petId && p.UserId == userId;
        }
    }
}