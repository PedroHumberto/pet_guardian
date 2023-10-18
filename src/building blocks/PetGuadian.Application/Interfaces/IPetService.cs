using PetGuadian.Application.Dto;
using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Interfaces
{
    public interface IPetService
    {
        void CreatePet(PetDto pet);
        Task<IEnumerable<PetDto>> GetAllPetsByUserId(Guid userId);
        Task<PetDto> GetPetById(Guid Id);
        Task Delete(Guid Id);
    }
}
