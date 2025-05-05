using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Abstractions;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Queries.MedicineQueries
{
    public sealed record GetMedicineByIdQuerie (Guid MedicineId) : IQuery<ICommandResult>;
}