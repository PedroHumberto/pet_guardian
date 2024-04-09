using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PetGuardian.Domain.Abstractions;

namespace PetGuadian.Application.Abstractions.Commands
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {     
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }
    public interface IBaseCommand
    {
    }
}