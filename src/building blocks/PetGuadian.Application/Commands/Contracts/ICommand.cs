using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Commands.Contracts
{
    public interface ICommand
    {
        void Execute();
    }
}