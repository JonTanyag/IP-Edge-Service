using System;
using IPEdge.Core.Interface;
using IPEdge.Infrastructure.Mapper;
using IPEdge.Core.Models;
using IPEdge.Infrastructure.Queries;
using MediatR;

namespace IPEdge.Infrastructure.QueryHandlers
{
	public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeModel>>, IRequestHandler<SearchEmployeeQuery, List<EmployeeModel>>
	{
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;
        private readonly EmployeeToEmployeeModelMapper _mapper;

        public GetEmployeesQueryHandler(IEmployeeService employeeService, IRoleService roleService, EmployeeToEmployeeModelMapper mapper)
		{
            _employeeService = employeeService;
            _roleService = roleService;
            _mapper = mapper;
		}

        public async Task<List<EmployeeModel>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetEmployees(request.Page, request.PageSize);
            var result = _mapper.Map(employees);

            foreach (var item in result)
            {
                var role = _roleService.GetRoleById(item.RoleID);
                item.RoleName = role.RoleName;
            }
            return result;
        }

        public async Task<List<EmployeeModel>> Handle(SearchEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetEmployees(request.Page, request.PageSize);
            var mappedResult = _mapper.Map(employees);

            foreach (var item in mappedResult)
            {
                var role = _roleService.GetRoleById(item.RoleID);
                item.RoleName = role.RoleName;
            }

            var results = mappedResult.Where(x => x.FirstName.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase)
                                    || x.LastName.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase)
                                    || x.RoleName.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

            return results;
        }
    }
}

