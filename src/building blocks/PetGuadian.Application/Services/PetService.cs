using PetGuadian.Application.Dto.PetDto;
using PetGuardian.Models.Models;
using PetGuardian.Domain.Repositories;
using PetGuadian.Application.Services.Interfaces;
using PetGuadian.Application.Dto.MedicineDto;
using PetGuardian.Core.Exceptions;


namespace PetGuadian.Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task CreatePet(CreatePetDto petDto)
        {
            var pet = new Pet(
                petDto.PetName,
                petDto.Gender,
                petDto.Specie,
                petDto.BirthDate,
                petDto.Weight);

            await _petRepository.CreatePet(pet, petDto.UserId);
        }

        public async Task DeletePet(Guid petId, Guid userId)
        {
            await _petRepository.DeletePet(petId, userId);
        }

        public async Task<IEnumerable<GetPetDto>> GetAllPetsByUserId(Guid userId)
        {
            var pets = await _petRepository.GetAllPetsByUserId(userId);

            return pets.Select(pet =>
            {
                pet.BrFormattedBirthDate(pet.BirthDate);
                var petAge = pet.GetPetAge(pet.BirthDate);

                var medicineDtos = pet.Medicines?.Select(medicine =>
                    new GetMedicineDto(medicine.RemedyName, medicine.Dosage, medicine.Observations, medicine.StartDate, medicine.EndDate)
                ) ?? Enumerable.Empty<GetMedicineDto>();

                return new GetPetDto(pet.Id, pet.PetName, pet.Gender, pet.Specie, pet.BirthDate, petAge, pet.Weight, medicineDtos.ToList());
            }).ToList();
        }

        public async Task<GetPetDto> GetPetById(Guid userId, Guid petId)
        {
            var pet = await _petRepository.GetPetById(userId, petId);

            CustomApplicationExceptions.ThrowIfObjectIsNull(pet, pet.PetName, "Pet Is Null");

            var medicineDtoList = pet.Medicines?.Select(medicine =>
                    new GetMedicineDto(medicine.RemedyName, medicine.Dosage, medicine.Observations, medicine.StartDate, medicine.EndDate)
                ) ?? Enumerable.Empty<GetMedicineDto>();

            var petAge = pet.GetPetAge(pet.BirthDate);
            var petDto = new GetPetDto(pet.Id, pet.PetName, pet.Gender, pet.Specie, pet.BirthDate, petAge, pet.Weight, medicineDtoList);

            return petDto;
        }

        public async Task Update(UpdatePetDto petDto)
        {
            Pet? pet = await _petRepository.GetPetById(petDto.userId, petDto.petId);
            pet.Update(petDto.PetName,
            petDto.Gender, 
            petDto.BirthDate, 
            petDto.Weight);

            await _petRepository.Update(pet);
        }
    }
}
