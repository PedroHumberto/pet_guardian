using PetGuadian.Application.Dto.PetDto;
using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Services.Interfaces
{
    public interface IPetService
    {
        Task CreatePet(CreatePetDto pet);
        Task<IEnumerable<GetPetDto>> GetAllPetsByUserId(Guid userId);
        Task<GetPetDto> GetPetById(Guid Id);
        Task Delete(Guid Id);
    }
}
