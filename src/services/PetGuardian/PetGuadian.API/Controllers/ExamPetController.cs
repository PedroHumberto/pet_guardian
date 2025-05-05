using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.ExamCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Handlers;

namespace PetGuadian.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExamPetController
    {
        private readonly IMediator _handler;

        public ExamPetController(IMediator handler)
        {
            _handler = handler;
        }

        [HttpPost("add_exam")]
        public async Task<ICommandResult> CreateExam([FromBody]CreateExamCommand command)
        {
            var result = (GenericCommandResult) await _handler.Send(command);

            return result;
        }

    }
}