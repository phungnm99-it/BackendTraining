using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ModelDTO;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AccountDTO> CreateAccountAsync(AccountDTO account)
        {
            try
            {
                if (await _unitOfWork.Accounts.IsUsernameExistAsync(account.Username)) return null;
                Account _account = _mapper.Map<Account>(account);
                _account.Id = new int();
                _account.IsDeleted = false;
                Role _role = await _unitOfWork.Roles.GetRoleByRoleNameAsync(account.RoleName);
                _account.RoleId = _role.Id;
                _unitOfWork.Accounts.CreateAccount(_account);
                await _unitOfWork.SaveAsync();
                _account = await _unitOfWork.Accounts.GetAccountByUsernameAsync(account.Username);
                return _mapper.Map<AccountDTO>(_account);
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<bool> DeleteAccountAsync(int accountId)
        {
            if (await _unitOfWork.Accounts.GetAccountByIdAsync(accountId) == null) return false;
            var account = await _unitOfWork.Accounts.GetAccountByIdAsync(accountId);
            account.IsDeleted = true;
            _unitOfWork.Accounts.DeleteAccount(account);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<AccountDTO> GetAccountByIdAsync(int accountId)
        {
            var account = await _unitOfWork.Accounts.GetAccountByIdAsync(accountId);
            return _mapper.Map<AccountDTO>(account);
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAccountsAsync()
        {
            var list = await _unitOfWork.Accounts.GetAllAccountsAsync();
            return _mapper.Map<IEnumerable<AccountDTO>>(list);
        }

        public async Task<AccountDTO> UpdateAccountAsync(AccountDTO account)
        {
            if (await _unitOfWork.Accounts.GetAccountByIdAsync(account.Id) == null) return null;
            try
            {
                Account _account = await _unitOfWork.Accounts.GetAccountByIdAsync(account.Id);
                _account.Password = account.Password;
                Role _role = await _unitOfWork.Roles.GetRoleByRoleNameAsync(account.RoleName);
                _account.RoleId = _role.Id;
                _unitOfWork.Accounts.UpdateAccount(_account);
                await _unitOfWork.SaveAsync();
                return _mapper.Map<AccountDTO>(_account);
            }
            catch
            {
                return null;
            }
        }
    }
}
