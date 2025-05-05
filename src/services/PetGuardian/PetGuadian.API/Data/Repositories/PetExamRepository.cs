using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PetGuardian.Core.Exceptions;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Repositories;
using PetGuardian.Domain.Models;

namespace PetGuadian.API.Data.Repositories
{
    public class PetExamRepository : IPetExamRepository
    {
        private readonly AppContextDb _context;
        private readonly IMemoryCache _cache;

        public PetExamRepository(AppContextDb context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateExam(PetExam exam)
        {
            CustomApplicationExceptions.ThrowIfObjectIsNull(exam, "exam", "Object is Null");

            await _context.PetExams.AddAsync(exam);
            await _context.Commit();
        }

        public async Task<IEnumerable<PetExam>> GetAllExamsByPetId(Guid petId)
        {
            List<PetExam>? examsList = await _context
                .PetExams
                .AsNoTracking()
                .Where(e => e.PetId == petId)
                .OrderBy(ex => ex.ExamDate)
                .ToListAsync();
            return examsList;
        }

        public Task<PetExam> GetExamById(Guid examId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExam(Guid examId, PetExam examDto)
        {
            throw new NotImplementedException();
        }
        public Task DeleteExam(Guid examId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}