using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ModelDTO;

namespace WebAPI.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAllAccountsAsync();
        Task<AccountDTO> GetAccountByIdAsync(int accountId);
        Task<AccountDTO> CreateAccountAsync(AccountDTO account);
        Task<AccountDTO> UpdateAccountAsync(AccountDTO account);
        Task<bool> DeleteAccountAsync(int accountId);
    }
}
