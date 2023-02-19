using System;
using IPEdge.Core.Interface;
using IPEdge.Core.Models;
using IPEdge.Infrastructure.Mapper;
using IPEdge.Infrastructure.Queries;
using MediatR;

namespace IPEdge.Infrastructure.QueryHandlers
{
	public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleModel>>
	{
        private readonly IRoleService _roleService;
        private readonly RolesToRoleModelMapper _mapper;

		public GetRolesQueryHandler(IRoleService roleService, RolesToRoleModelMapper mapper)
		{
            _roleService = roleService;
            _mapper = mapper;
		}

        public async Task<List<RoleModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetRoles(request.Page, request.PageSize);
            return _mapper.Map(result.ToList());
        }
    }
}

