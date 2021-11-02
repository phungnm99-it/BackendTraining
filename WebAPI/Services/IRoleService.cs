using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ModelDTO;

namespace WebAPI.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO> GetlRoleByIdAsync(int roleId);
        Task<RoleDTO> CreateRoleAsync(string roleName);
        Task<RoleDTO> UpdateRoleAsync(RoleDTO role);
    }
}
