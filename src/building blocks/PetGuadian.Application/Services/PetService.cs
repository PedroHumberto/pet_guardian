using PetGuadian.Application.Dto;
using PetGuadian.Application.Interfaces;
using PetGuardian.Domain.Models.Interfaces;
using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void CreatePet(PetDto petDto)
        {
            var pet = new Pet(petDto.Id, petDto.PetName, petDto.Gender, petDto.Specie, petDto.BirthDate, petDto.Weight);
            _petRepository.CreatePet(pet, petDto.UserId);
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PetDto>> GetAllPetsByUserId(Guid userId)
        {
            var pets = await _petRepository.GetAllPetsByUserId(userId);
            var petDtoList = new List<PetDto>();

            foreach (var pet in pets)
            {
                pet.BrFormattedBirthDate(pet.BirthDate);
                var petAge = pet.GetPetAge(pet.BirthDate);

                var petDto = new PetDto(pet.Id, pet.PetName, pet.Gender, pet.Specie, pet.BirthDate, petAge, pet.Weight, pet.UserId);
                petDtoList.Add(petDto);
            }
            return petDtoList;
        }

        public async Task<PetDto> GetPetById(Guid Id)
        {
            var pet = await _petRepository.GetPetById(Id);

            var petAge = pet.GetPetAge(pet.BirthDate);
            var petDto = new PetDto(pet.Id, pet.PetName, pet.Gender, pet.Specie, pet.BirthDate, petAge, pet.Weight, pet.UserId);

            return petDto;
        }
    }
}
