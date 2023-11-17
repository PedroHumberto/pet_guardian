using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.MedicineDto;

namespace PetGuadian.Application.Services.Interfaces
{
    public interface IMedicineService
    {
        Task CreateMedicine(CreateMedicineDto createDto);
        
    }
}