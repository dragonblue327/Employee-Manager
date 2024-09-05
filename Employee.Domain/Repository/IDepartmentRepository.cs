using Employee.Domain.Entity;

namespace Employee.Domain.Repository
{
	public interface IDepartmentRepository
	{
		Task<Department> CreateAsync(Department department);
		Task SaveAsync(Department department);
		Task DeleteAsync(int id);
		Task<Department> GetByIdAsync(int id);
		Task<IEnumerable<Department>> GetAllAsync();
	}
}
