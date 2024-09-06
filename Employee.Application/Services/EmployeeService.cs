using ClosedXML.Excel;
using Employee.Application.DTO;
using Employee.Application.IServices;
using Employee.Domain.Entity;
using Employee.Domain.Repository;

namespace Employee.Application.Services { 
public class EmployeeService : IEmployeeService
{
	private readonly IEmployeeRepository _employeeRepository;

	public EmployeeService(IEmployeeRepository employeeRepository)
	{
		_employeeRepository = employeeRepository;
	}

	public async Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto)
	{
			var tempDepartment = employeeDto.Departments;
		var employee = new Employe
		{
			FullName = employeeDto.FullName,
			EmployeeNumber = employeeDto.EmployeeNumber,
			Position = employeeDto.Position,
			Email = employeeDto.Email,
			Phone = employeeDto.Phone,
			HireDate = employeeDto.HireDate,
			TerminationDate = employeeDto.TerminationDate,
			RecordStatus = (Domain.Entity.RecordStatus)employeeDto.RecordStatus,
		};
			if (tempDepartment != null) {
				foreach (var item in tempDepartment) {
					var tempDepart = new Department
					{
						Id = item.Id
					};
					employee.Departments.Add(tempDepart);
					}
			}
		var createdEmployee = await _employeeRepository.CreateAsync(employee);

		return new EmployeeDto
		{
			Id = createdEmployee.Id,
			FullName = createdEmployee.FullName,
			EmployeeNumber = createdEmployee.EmployeeNumber,
			Position = createdEmployee.Position,
			Email = createdEmployee.Email,
			Phone = createdEmployee.Phone,
			HireDate = createdEmployee.HireDate,
			TerminationDate = createdEmployee.TerminationDate,
			RecordStatus = (DTO.RecordStatus)createdEmployee.RecordStatus
		};
	}

	public async Task SaveAsync(EmployeeDto employeeDto)
	{
		var employee = new Employe
		{
			Id = employeeDto.Id,
			FullName = employeeDto.FullName,
			EmployeeNumber = employeeDto.EmployeeNumber,
			Position = employeeDto.Position,
			Email = employeeDto.Email,
			Phone = employeeDto.Phone,
			HireDate = employeeDto.HireDate,
			TerminationDate = employeeDto.TerminationDate,
			RecordStatus = (Domain.Entity.RecordStatus)employeeDto.RecordStatus
		};
			foreach (var department in employeeDto.Departments) {
				var tempDepartment = new Department
				{
					Id = department.Id
				};
				employee.Departments.Add(tempDepartment);
			}

		await _employeeRepository.SaveAsync(employee);
	}

	public async Task DeleteAsync(int id)
	{
		await _employeeRepository.DeleteAsync(id);
	}

	public async Task<EmployeeDto> GetByIdAsync(int id)
	{
		var employee = await _employeeRepository.GetByIdAsync(id);

		return new EmployeeDto
		{
			Id = employee.Id,
			FullName = employee.FullName,
			EmployeeNumber = employee.EmployeeNumber,
			Position = employee.Position,
			Email = employee.Email,
			Phone = employee.Phone,
			HireDate = employee.HireDate,
			TerminationDate = employee.TerminationDate,
			Departments = employee.Departments.Select(d => new DepartmentDto
			{
				Name = d.Name,

			}).ToList(),
			RecordStatus = (DTO.RecordStatus)employee.RecordStatus
		};
	}

	public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
	{
		var employees = await _employeeRepository.GetAllAsync();

			return employees.Select(employee => new EmployeeDto
			{
				Id = employee.Id,
				FullName = employee.FullName,
				EmployeeNumber = employee.EmployeeNumber,
				Position = employee.Position,
				Email = employee.Email,
				Phone = employee.Phone,
				HireDate = employee.HireDate,
				TerminationDate = employee.TerminationDate,
				RecordStatus = (DTO.RecordStatus)employee.RecordStatus,
				Departments = employee.Departments.Select(d => new DepartmentDto
				{
					Name = d.Name,
					
				}).ToList()

			}).ToList();
		
	}

		public async void SaveDataFromExcelFileAsync(string filePath)
		{
			var employees = ReadExcelFile(filePath);

			foreach (var employee in employees) {
				await CreateAsync(employee);
			}
		}

		private List<EmployeeDto> ReadExcelFile(string filePath)
		{
			var employees = new List<EmployeeDto>();

			using (var workbook = new XLWorkbook(filePath))
			{
				var worksheet = workbook.Worksheet(1);
				var rowCount = worksheet.RowsUsed().Count();
				var colCount = worksheet.ColumnsUsed().Count();

				var columnIndices = new Dictionary<string, int>();
				for (int col = 1; col <= colCount; col++)
				{
					var header = worksheet.Cell(1, col).GetString().Trim();
					columnIndices[header] = col;
					Console.WriteLine($"Header: '{header}', Column: {col}");
				}

				for (int row = 2; row <= rowCount; row++)
				{
					var employee = new EmployeeDto
					{
						FullName = GetCellValue(worksheet, row, columnIndices, "ФИО"),
						EmployeeNumber = GetCellValue(worksheet, row, columnIndices, "Таб.№"),
						Position = GetCellValue(worksheet, row, columnIndices, "Должность"),
						Email = GetCellValue(worksheet, row, columnIndices, "Email"),
						Phone = GetCellValue(worksheet, row, columnIndices, "Телефон"),
						HireDate = ParseDate(worksheet, row, columnIndices, "Дата приема"),
						TerminationDate = ParseDate(worksheet, row, columnIndices, "Дата увольнения"),
						Departments = new List<DepartmentDto>
				{
					new DepartmentDto { Name = GetCellValue(worksheet, row, columnIndices, "Подразделение") }
				}
					};
					employees.Add(employee);
				}
			}

			return employees;
		}

		private string GetCellValue(IXLWorksheet worksheet, int row, Dictionary<string, int> columnIndices, string columnName)
		{
			if (columnIndices.TryGetValue(columnName, out int colIndex))
			{
				return worksheet.Cell(row, colIndex).GetString();
			}
			else
			{
				Console.WriteLine($"Column '{columnName}' not found.");
				return string.Empty;
			}
		}

		private DateTime? ParseDate(IXLWorksheet worksheet, int row, Dictionary<string, int> columnIndices, string columnName)
		{
			var cellValue = GetCellValue(worksheet, row, columnIndices, columnName);
			return DateTime.TryParse(cellValue, out DateTime date) ? date : (DateTime?)null;
		}
	}

}
