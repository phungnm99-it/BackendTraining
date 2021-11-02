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
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Default()
        {
            return new ObjectResult(new { code = "200", message = "Hello!" });
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllRoles()
        {
            var list =  await _roleService.GetAllRolesAsync();
            return new ObjectResult(new { code = 200, data = list });
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddRole([FromForm]string roleName)
        {
            var result = await _roleService.CreateRoleAsync(roleName);
            if (result == null) return new ObjectResult(new { code = 401, message = "Rolename exists!" });
            return new ObjectResult(new { code = 200, data = result });
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateRole([FromForm] RoleDTO role)
        {
            var result = await _roleService.UpdateRoleAsync(role);
            if (result == null) return new ObjectResult(new { code = 401, message = "Id wrong or Rolename exists!" });
            return new ObjectResult(new { code = 200, data = result });
        }
    }
}
