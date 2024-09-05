﻿

namespace Employee.Application.DTO
{
	public class EmployeeDto
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string EmployeeNumber { get; set; } = string.Empty;
		public string Position { get; set; } = string.Empty;
		public int DepartmentId { get; set; }
		public DepartmentDto Department { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public DateTime HireDate { get; set; }
		public DateTime? TerminationDate { get; set; }
		public RecordStatus RecordStatus { get; set; }
	}
}
