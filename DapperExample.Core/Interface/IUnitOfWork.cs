using System;
using System.Collections.Generic;
using System.Text;

namespace DapperExample.Core.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
    }
}
