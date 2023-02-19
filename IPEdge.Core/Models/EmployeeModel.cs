using System;
namespace IPEdge.Core.Models
{
	public class EmployeeModel
	{
		public EmployeeModel()
		{
		}

        public int Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateJoined { get; set; }
        public int Extension { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}

