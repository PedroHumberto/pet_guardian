using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.MedicineCommands;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Handlers.Contracts;


namespace PetGuadian.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMediator _handler;
        

        public MedicineController(IMediator handler)
        {
            _handler = handler;
        }

        [HttpPost("crate_medicine")]
        public async Task<ICommandResult> CreateMedicine([FromBody]CreateMedicineCommand command)
        {
            var result = (GenericCommandResult) await _handler.Send(command);

            return result;
        }
    }
}