using Employee.Application.DTO;

namespace Employee.Application.Interfaces
{
	public interface IDepartmentService
	{
		Task<DepartmentDto> CreateAsync(DepartmentDto departmentDto);
		Task SaveAsync(DepartmentDto departmentDto);
		Task DeleteAsync(int id);
		Task<DepartmentDto> GetByIdAsync(int id);
		Task<IEnumerable<DepartmentDto>> GetAllAsync();
	}
}
