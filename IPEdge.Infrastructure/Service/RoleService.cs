using System;
using IPEdge.Core.Domain;
using IPEdge.Core.Interface;

namespace IPEdge.Infrastructure.Service
{
	public class RoleService : IRoleService
	{
        private readonly IRepository<Role> _repository;

		public RoleService(IRepository<Role> repository)
		{
            _repository = repository;
		}

        public Role GetRoleById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<IEnumerable<Role>> GetRoles(int page, int pageSize)
        {
            return await _repository.GetAll(page, pageSize);
        }
    }
}

