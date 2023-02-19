using System;
using IPEdge.Core.Domain;
using IPEdge.Core.Models;

namespace IPEdge.Infrastructure.Mapper
{
	public class RolesToRoleModelMapper
	{
		public RolesToRoleModelMapper()
		{
		}

		public List<RoleModel> Map(List<Role> source)
		{
			List<RoleModel> result = new List<RoleModel>();

			foreach (var item in source)
			{
				var role = new RoleModel
				{
					Id = item.Id,
					RoleName = item.RoleName
				};
				result.Add(role);
			}
			return result;
		}
	}
}

