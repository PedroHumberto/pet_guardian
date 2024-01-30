using System.Net;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.ExamCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetExamDto;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services.Interfaces.PetGuadian.Application.Services.Interfaces;

namespace PetGuadian.Application.Handlers
{
    public class PetExamHandler : IHandler<CreateExamCommand>
    {

        private readonly IPetExamService _service;

        public PetExamHandler(IPetExamService service)
        {
            _service = service;
        }

        public async Task<ICommandResult> Handle(CreateExamCommand command)
        {
            command.Execute();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Invalid data", command.Notifications, HttpStatusCode.BadRequest);
            }

            var createExamDto = new CreateExamDto(
                command.PetId,
                command.ExamName,
                command.ExamLink,
                command.Observations,
                command.ExamDate);

            await _service.CreateExam(createExamDto);

            return new GenericCommandResult(true, "Exam created successfully", createExamDto, HttpStatusCode.Created);
        }

    }

}
