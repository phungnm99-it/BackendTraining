using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ModelDTO;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var list = await _accountService.GetAllAccountsAsync();
            return new ObjectResult(new { code = 200, data = list });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            return new ObjectResult(new { code = 200, data = account });
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddAccount([FromForm] AccountDTO accountDTO)
        {
            var result = await _accountService.CreateAccountAsync(accountDTO);
            if (result == null) return new ObjectResult(new { code = 401, message = "username exists!" });
            return new ObjectResult(new { code = 200, data = result });
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAccount([FromForm] AccountDTO account)
        {
            var result = await _accountService.UpdateAccountAsync(account);
            if (result == null) return new ObjectResult(new { code = 401, message = "Id wrong or username exists!" });
            return new ObjectResult(new { code = 200, data = result });
        }
    }
}
