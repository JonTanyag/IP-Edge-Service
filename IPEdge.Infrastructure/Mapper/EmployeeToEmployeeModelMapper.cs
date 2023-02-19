using System;
using IPEdge.Core.Domain;
using IPEdge.Infrastructure.Commands;
using IPEdge.Core.Models;
using IPEdge.Infrastructure.Queries;

namespace IPEdge.Infrastructure.Mapper
{
	public class EmployeeToEmployeeModelMapper
	{
		public EmployeeToEmployeeModelMapper()
		{
		}

		public List<EmployeeModel> Map(List<Employee> source)
		{
			List<EmployeeModel> result = new List<EmployeeModel>();
			foreach (var item in source)
			{
                var employee =  new EmployeeModel
                {
                    Id = item.Id,
                    EmployeeNumber = item.EmployeeNumber,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    DateJoined = item.DateJoined,
                    Extension = item.Extension,
                    RoleID = item.RoleID
                };
				result.Add(employee);
            }

			return result;
		}

	}
}

