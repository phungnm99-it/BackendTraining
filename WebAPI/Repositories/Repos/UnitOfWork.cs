using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;
        public IRoleRepository Roles { get; private set; }
        public IAccountRepository Accounts { get; private set; }
        public UnitOfWork(SchoolContext context, IRoleRepository roles,
            IAccountRepository accounts)
        {
            _context = context;
            Roles = roles;
            Accounts = accounts;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
