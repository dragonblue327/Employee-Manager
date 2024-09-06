using Employee.Application.DTO;

namespace Employee.Application.IServices
{
	public interface IEmployeeService
	{
		Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);
		Task SaveAsync(EmployeeDto employeeDto);
		Task DeleteAsync(int id);
		Task<EmployeeDto> GetByIdAsync(int id);
		Task<IEnumerable<EmployeeDto>> GetAllAsync();
		 void SaveDataFromExcelFileAsync(string filePath);
	}
}
