using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.MedicineCommands;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly MedicineHandler _handler;
        private readonly IMedicineService _service;

        public MedicineController(MedicineHandler handler, IMedicineService service)
        {
            _handler = handler;
            _service = service;
        }

        [HttpPost("crate_medicine")]
        public async Task<ICommandResult> CreateMedicine([FromBody]CreateMedicineCommand command)
        {
            var result = (GenericCommandResult) await _handler.Handle(command);

            return result;
        }
    }
}