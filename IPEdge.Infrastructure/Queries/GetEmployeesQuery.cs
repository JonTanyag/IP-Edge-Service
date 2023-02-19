using System;
using IPEdge.Core.Models;
using MediatR;

namespace IPEdge.Infrastructure.Queries
{
	public class GetEmployeesQuery : IRequest<List<EmployeeModel>>
    {
        public GetEmployeesQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

