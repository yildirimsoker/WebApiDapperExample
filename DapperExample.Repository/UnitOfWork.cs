using DapperExample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperExample.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository)
        {
            User = userRepository;
        }
        public IUserRepository User { get; }
    }
}
