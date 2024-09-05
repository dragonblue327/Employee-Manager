

namespace Employee.Application.DTO
{
	public class DepartmentDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int? ParentDepartmentId { get; set; }
		public int? ManagerId { get; set; }
		public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
	}
}
