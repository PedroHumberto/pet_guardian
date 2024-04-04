using PetGuadian.Application.Dto.PetExamDto;
using PetGuadian.Application.Services.Interfaces.PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Pets;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Services
{
    public class PetExameService : IPetExamService
    {
        private readonly IPetExamRepository _repository;

        public PetExameService(IPetExamRepository repository)
        {
            _repository = repository;
        }


        public async Task CreateExam(CreateExamDto examDto)
        {
            var examMapping = new PetExam(
                examDto.PetId,
             examDto.ExamLink,
            examDto.ExamName,
            examDto.ExamDate
            );

            await _repository.CreateExam(examMapping);
        }

        public Task DeleteExam(Guid examId)
        {
            throw new NotImplementedException();
        }
                                    //GetPetExamsDto
        public async Task<IEnumerable<PetExam>> GetAllExamsByPetId(Guid petId)
        {
            var examList = await _repository.GetAllExamsByPetId(petId);
            return examList;
        }


        public Task<PetExam> GetExamById(Guid examId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExam(Guid examId, CreateExamDto examDto)
        {
            throw new NotImplementedException();
        }

    }
}