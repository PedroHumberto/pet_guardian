using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.MedicineDto;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuardian.Tests.Services
{
    public class FakeMedicineService : IMedicineService
    {
        public async Task CreateMedicine(CreateMedicineDto createDto)
        {
        }

    }
}