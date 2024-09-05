using Employee.Domain.Entity;

namespace Employee.Domain.Repository
{
	public interface IEmployeeRepository
	{
		Task<Employe> CreateAsync(Employe employee);
		Task SaveAsync(Employe employee);
		Task DeleteAsync(int id);
		Task<Employe> GetByIdAsync(int id);
		Task<IEnumerable<Employe>> GetAllAsync();

	}
}
