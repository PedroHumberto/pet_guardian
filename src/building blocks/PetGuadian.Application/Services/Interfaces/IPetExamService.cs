using PetGuadian.Application.Dto.PetExamDto;
using PetGuardian.Domain.Models;

namespace PetGuadian.Application.Services.Interfaces
{
    namespace PetGuadian.Application.Services.Interfaces
    {
        public interface IPetExamService
        {
            Task CreateExam(CreateExamDto examDto);
            Task<PetExam> GetExamById(Guid examId);
            Task<IEnumerable<PetExam>> GetAllExamsByPetId(Guid petId);
            Task UpdateExam(Guid examId, CreateExamDto examDto);
            Task DeleteExam(Guid examId);
        }
    }
}