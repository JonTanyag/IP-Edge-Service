using System;
using IPEdge.Core.Models;
using MediatR;

namespace IPEdge.Infrastructure.Queries
{
	public class GetRolesQuery : IRequest<List<RoleModel>>
	{
        public GetRolesQuery()
        {
            Page = 1;
            PageSize = int.MaxValue;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

