

using Employee.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Application.DTO
{
	public class EmployeeDto
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string EmployeeNumber { get; set; } = string.Empty;
		public string Position { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public DateTime? HireDate { get; set; } = DateTime.UtcNow;
		public DateTime? TerminationDate { get; set; }
		public RecordStatus RecordStatus { get; set; }
		public ICollection<DepartmentDto> Departments { get; set; } = new List<DepartmentDto>();
		[NotMapped]
		public string DepartmentNames => string.Join(",", Departments.Select(d => d.Name));
	}
}
