﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Core.Data
{
    public interface IRepository<T> : IDisposable 
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
