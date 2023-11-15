using PetGuadian.Application.Dto.PetDto;
using PetGuardian.Models.Models;
using PetGuardian.Domain.Repositories;
using PetGuadian.Application.Services.Interfaces;


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

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetPetDto>> GetAllPetsByUserId(Guid userId)
        {
            var pets = await _petRepository.GetAllPetsByUserId(userId);
            var petDtoList = new List<GetPetDto>();

            foreach (var pet in pets)
            {
                pet.BrFormattedBirthDate(pet.BirthDate);
                var petAge = pet.GetPetAge(pet.BirthDate);

                var petDto = new GetPetDto(pet.PetName, pet.Gender, pet.Specie, pet.BirthDate, petAge, pet.Weight, pet.UserId);
                petDtoList.Add(petDto);
            }
            return petDtoList;
        }

        public async Task<GetPetDto> GetPetById(Guid Id)
        {
            var pet = await _petRepository.GetPetById(Id);

            var petAge = pet.GetPetAge(pet.BirthDate);
            var petDto = new GetPetDto(pet.PetName, pet.Gender, pet.Specie, pet.BirthDate, petAge, pet.Weight, pet.UserId);

            return petDto;
        }
    }
}
