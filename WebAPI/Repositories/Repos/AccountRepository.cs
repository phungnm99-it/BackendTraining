using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories.Repos
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(SchoolContext context) : base(context) { }
        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public void DeleteAccount(Account account)
        {
            Update(account);
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await FindByCondition(account => account.Id == accountId && account.IsDeleted == false)
                .Include(account => account.Role).FirstOrDefaultAsync();
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await FindByCondition(account => account.Username == username && account.IsDeleted == false)
                .Include(account => account.Role).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> GetAccountsByRoleIdAsync(int roleId)
        {
            return await FindByCondition(account => account.RoleId == roleId && account.IsDeleted == false)
                .Include(account => account.Role).ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await FindByCondition(account=>account.IsDeleted == false)
                .Include(account => account.Role).ToListAsync();
        }

        public async Task<bool> IsUsernameExistAsync(string username)
        {
            return await FindByCondition(account => account.Username == username && account.IsDeleted == false).AnyAsync();
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }
    }
}
