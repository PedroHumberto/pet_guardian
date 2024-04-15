using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;

namespace PetGuardian.Domain.Repositories
{
    public interface IPetExamRepository : IRepository<PetExam>
    {
            Task CreateExam(PetExam exam);
            Task<PetExam> GetExamById(Guid examId);
            Task<IEnumerable<PetExam>> GetAllExamsByPetId(Guid petId);
            Task UpdateExam(Guid examId, PetExam examDto);
            Task DeleteExam(Guid examId);
    }
}