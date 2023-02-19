using System;
using IPEdge.Core.Models;
using MediatR;

namespace IPEdge.Infrastructure.Queries
{
	public class SearchEmployeeQuery : IRequest<List<EmployeeModel>>
	{
		public SearchEmployeeQuery(string searchTerm)
		{
			SearchTerm = searchTerm;
			Page = 1;
			PageSize = int.MaxValue;
		}

		public string SearchTerm { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

