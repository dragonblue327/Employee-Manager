using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entity
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int? ParentDepartmentId { get; set; }
		public Department? ParentDepartment { get; set; }
		public int? ManagerId { get; set; }
		public Employe? Manager { get; set; }
		public RecordStatus? RecordStatus { get; set; }
		public ICollection<Employe> Employees { get; set; } = new List<Employe>();
	}
}
