using System;
using IPEdge.Core.Domain;
using IPEdge.Infrastructure.Commands;

namespace IPEdge.Infrastructure.Mapper
{
	public class AddEmployeeCommandToEmployeeMapper
	{
		public AddEmployeeCommandToEmployeeMapper()
		{
		}

		public Employee Map(AddEmployeeCommand source)
		{
			return new Employee
			{
				FirstName = source.FirstName,
				LastName = source.LastName,
				Extension = source.Extension,
				RoleID = source.RoleID
			};
		}

	}
}

