using System;
using IPEdge.Core.Domain;

namespace IPEdge.Core.Interface
{
	public interface IRoleService
	{
		Task<IEnumerable<Role>> GetRoles(int page, int pageSize);
		Role GetRoleById(int id);
	}
}

