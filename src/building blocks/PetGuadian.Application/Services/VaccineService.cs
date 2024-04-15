using PetGuadian.Application.Dto.VaccineDto;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Services
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _repository;

        public VaccineService(IVaccineRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateVaccineDto createDto)
        {
            var vaccine = new Vaccine(
                createDto.name,
                createDto.vaccinatedAt,
                createDto.firstVaccin,
                createDto.petId,
                createDto.notes
                );

            await _repository.Create(vaccine);
        }

        public async Task Delete(Guid vaccineId, Guid petId)
        {
            await _repository.Delete(vaccineId, petId);
        }

        public async Task<IEnumerable<GetVaccineDto>> GetAllVaccinesByPetId(Guid petId)
        {
            var vaccines = await _repository.GetAllVaccinesByPetId(petId);
            return vaccines.Select(v =>
            {
                return new GetVaccineDto(
                    v.Id,
                    v.PetId,
                    v.Name,
                    v.VaccinatedAt,
                    v.FirstVaccin,
                    v.Notes
                );
            });
        }

        public async Task<GetVaccineDto> GetVaccineById(Guid vaccineId, Guid petId)
        {
            var vaccine = await _repository.GetVaccineById(vaccineId, petId);
            var getDto = new GetVaccineDto(
                vaccine.Id, 
                vaccine.PetId, 
                vaccine.Name, 
                vaccine.VaccinatedAt, 
                vaccine.FirstVaccin, 
                vaccine.Notes
            );
            return getDto;
        }

        public async Task Update(UpdateVaccineDto updateDto)
        {
            var vaccine = await _repository.GetVaccineById(updateDto.vaccineId, updateDto.petId);
            vaccine.SetName(updateDto.name);
            vaccine.SetNote(updateDto.notes);
            await _repository.Update(vaccine);
        }
    }
}