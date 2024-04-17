using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Abstractions
{
    public interface IQuery<TResponse> : IRequest<ICommandResult>
    {
        
    }
}