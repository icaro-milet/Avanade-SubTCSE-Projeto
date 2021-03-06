using AutoMapper;
using Avanade.SubTCSE.Projeto.Application.Dtos.EmployeeRole;
using Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Services.EmployeeRole
{
    public class EmployeeRoleAppService : IEmployeeRoleAppService
    {
        private readonly IMapper _mapper;

        private readonly IEmployeeRoleService _employeeRoleService;

        public EmployeeRoleAppService(IMapper mapper, IEmployeeRoleService employeeRoleService)
        {
            _mapper = mapper;
            _employeeRoleService = employeeRoleService;
        }

        public async Task<EmployeeRoleDto> AddEmployeeRoleAsync(EmployeeRoleDto employeeRoleDto)
        {
            //mapear
            var itemDomain = _mapper.Map<EmployeeRoleDto, Domain.Aggregates.EmployeeRole.Entities.EmployeeRole>(employeeRoleDto);

            //chamar metodo
            var item = await _employeeRoleService.AddEmployeeRoleAsync(itemDomain);

            //mapear
            var itemDto = _mapper.Map<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, EmployeeRoleDto>(item);

            //devolver
            return itemDto;
        }

        public async Task<List<EmployeeRoleDto>> FindAllEmployeeRoleAsync()
        {
            var item = await _employeeRoleService.GetAllAsync();

            return _mapper.Map<List<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole>, List<EmployeeRoleDto>>(item);
        }

        public async Task<EmployeeRoleDto> GetById(string id)
        {
            var item = await _employeeRoleService.GetById(id);

            return _mapper.Map<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, EmployeeRoleDto>(item);
        }

        public void DeleteById(string id)
        {
            _employeeRoleService.DeleteById(id);
        }
    }
}