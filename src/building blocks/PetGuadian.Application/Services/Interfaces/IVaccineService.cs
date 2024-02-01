using PetGuadian.Application.Dto.VaccineDto;

namespace PetGuadian.Application.Services.Interfaces
{
    public interface IVaccineService
    {
        Task Create(CreateVaccineDto createDto);
        Task<IEnumerable<GetVaccineDto>> GetAllVaccinesByPetId(Guid petId);
        Task<GetVaccineDto> GetVaccineById(Guid vaccineId, Guid petId);
        Task Update(UpdateVaccineDto updateDto);
        Task Delete(Guid vaccineId, Guid petId);
    }
}