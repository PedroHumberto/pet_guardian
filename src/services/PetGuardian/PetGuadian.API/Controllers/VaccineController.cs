using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Commands.VaccineCommands;

namespace PetGuadian.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VaccineController
    {
        private readonly IMediator _handler;

        public VaccineController(IMediator handler)
        {
            _handler = handler;
        }

        [HttpPost("add_vaccine")]
        public async Task<GenericCommandResult> AddVaccine([FromBody] CreateVaccineCommand command)
        {
            var result = (GenericCommandResult)await _handler.Send(command);

            return result;
        }
    }
}