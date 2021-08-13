using DapperExample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperExample.Core.Interface
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
