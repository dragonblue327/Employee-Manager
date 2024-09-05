using Employee.Domain.Entity;
using Employee.Domain.Repository;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly AppDBContext _context;

		public EmployeeRepository(AppDBContext context)
		{
			_context = context;
		}

		public async Task<Employe> CreateAsync(Employe employee)
		{
			try
			{
				_context.Employees.Add(employee);
				await _context.SaveChangesAsync();
				return employee;
			}
			catch (DbUpdateException DBException)
			{
				throw new Exception("An db error while creating the employee record.", DBException);
			}
			catch (Exception exception)
			{
				throw new Exception("An unexpected error occurred.", exception);
			}
		}

		public async Task SaveAsync(Employe employee)
		{
			try
			{
				_context.Entry(employee).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException DBException)
			{
				throw new Exception("An db error while saving the employee record.", DBException);
			}
			catch (Exception exception)
			{
				throw new Exception("An unexpected error occurred.", exception);
			}
		}

		public async Task DeleteAsync(int id)
		{
			try
			{
				var employee = await _context.Employees.FindAsync(id);
				if (employee != null)
				{
					_context.Employees.Remove(employee);
					await _context.SaveChangesAsync();
				}
			}
			catch (DbUpdateException DBException)
			{
				throw new Exception("An db error while deleting the employee record.", DBException);
			}
			catch (Exception exception)
			{
				throw new Exception("An unexpected error occurred.", exception);
			}
		}

		public async Task<Employe?> GetByIdAsync(int id)
		{
			try
			{
				var employee = await _context.Employees
					.Include(e => e.Department)
					.FirstOrDefaultAsync(e => e.Id == id);

				if (employee == null)
				{
					throw new InvalidOperationException($"Employee with ID {id} not found.");
				}

				return employee;
			}
			catch (DbUpdateException DBException)
			{
				throw new Exception("An db error while getting the employee record.", DBException);
			}
			catch (Exception exception)
			{
				throw new Exception("An error while getting the employee record.", exception);
			}
		}

		public async Task<IEnumerable<Employe>> GetAllAsync()
		{
			try
			{
				return await _context.Employees
					.Include(e => e.Department)
					.ToListAsync();
			}
			catch (DbUpdateException DBException)
			{
				throw new Exception("An db error while getting all employee's records.", DBException);
			}
			catch (Exception exception)
			{
				throw new Exception("An error while getting all employee's records.", exception);
			}
		}
	}

}
