using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IRoleRepository Roles { get;}
        public IAccountRepository Accounts { get; }
        Task SaveAsync();
    }
}
