using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, ICommandResult> where TQuery : IQuery<TResponse>
    {
        
    }
}