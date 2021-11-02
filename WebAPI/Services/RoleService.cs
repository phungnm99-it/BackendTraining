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
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RoleDTO> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName)) return null;
            if (await _unitOfWork.Roles.IsRoleNameExist(roleName)) return null;
            _unitOfWork.Roles.CreateRole(new Role { RoleName = roleName });
            await _unitOfWork.SaveAsync();
            var role = await _unitOfWork.Roles.GetRoleByRoleNameAsync(roleName);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var list = await _unitOfWork.Roles.GetAllRolesAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(list);
        }

        public async Task<RoleDTO> GetlRoleByIdAsync(int roleId)
        {
            var role = await _unitOfWork.Roles.GetRoleByIdAsync(roleId);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<RoleDTO> UpdateRoleAsync(RoleDTO role)
        {
            if (await _unitOfWork.Roles.IsRoleNameExist(role.RoleName)) return null;
            Role _role = await _unitOfWork.Roles.GetRoleByIdAsync(role.Id);
            _role.RoleName = role.RoleName;
            _unitOfWork.Roles.UpdateRole(_role);
            await _unitOfWork.SaveAsync();
            return role;
        }
    }
}
