using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PetGuadian.Application.Abstractions.Commands;
using PetGuardian.Core.PetGuardianCore.Enums;

namespace PetGuadian.Application.Pets
{
    public record CreatePetCommand(
        Guid userId,
        string petName,
        char gender,
        AnimalSpecies species,
        DateTime birthDate,
        float? weight) : ICommand<Guid>;

}