using System;
namespace IPEdge.Core.Domain
{
	public class Employee : BaseEntity
	{
		public Employee()
		{
		}

		public int EmployeeNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateJoined { get; set; }
		public int Extension { get; set; }
		public int RoleID { get; set; }
	}
}

