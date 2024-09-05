using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entity
{
	public class Employe
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string EmployeeNumber { get; set; } = string.Empty;
		public string Position { get; set; } = string.Empty;
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public DateTime HireDate { get; set; }
		public DateTime? TerminationDate { get; set; }
		public RecordStatus RecordStatus { get; set; }
	}
}
