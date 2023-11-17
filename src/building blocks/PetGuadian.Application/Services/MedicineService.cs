using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.MedicineDto;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateMedicine(CreateMedicineDto createDto)
        {
            var medicine = new Medicine(createDto.RemedyName, createDto.Dosage, createDto.Observations, createDto.StartDate, createDto.EndDate);
            await _repository.CreatMedicine(medicine);
        }
    }
}