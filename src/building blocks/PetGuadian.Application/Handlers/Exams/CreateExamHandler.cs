using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.ExamCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetExamDto;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Exams
{
    public sealed class CreateExamHandler : IRequestHandler<CreateExamCommand, ICommandResult>
    {
        private readonly IPetExamRepository _repository;
        public async Task<ICommandResult> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if (!request.IsValid)
            {
                return new GenericCommandResult(false, "Invalid data", request.Notifications, HttpStatusCode.BadRequest);
            }

            var createExamDto = new PetExam(
                request.PetId,
                request.ExamLink,
                request.ExamName,
                request.ExamDate);

            await _repository.CreateExam(createExamDto);

            return new GenericCommandResult(true, "Exam created successfully", createExamDto, HttpStatusCode.Created);
        }
    }
}