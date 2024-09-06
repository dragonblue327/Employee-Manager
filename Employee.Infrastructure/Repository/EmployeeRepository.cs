using DocumentFormat.OpenXml.ExtendedProperties;
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
				var tempDepartments = employee.Departments.ToList();
				employee.Departments.Clear();

				foreach (var department in tempDepartments)
				{
					var existingDepartment = await _context.Departments.FindAsync(department.Id);
					if (existingDepartment != null)
					{
						_context.Entry(existingDepartment).State = EntityState.Unchanged;
						employee.Departments.Add(existingDepartment);
					}
				}

				_context.Employees.Add(employee);
				await _context.SaveChangesAsync();
				return employee;
			}
			catch (DbUpdateException dbException)
			{
				throw new Exception("A database error occurred while creating the employee record.", dbException);
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
				var existingEmployee = await _context.Employees.Include(e => e.Departments).FirstOrDefaultAsync(e => e.Id == employee.Id);
				if (existingEmployee == null)
				{
					 new Employe();
				}

				existingEmployee.FullName = employee.FullName;
				existingEmployee.EmployeeNumber = employee.EmployeeNumber;
				existingEmployee.Position = employee.Position;
				existingEmployee.Email = employee.Email;
				existingEmployee.Phone = employee.Phone;
				existingEmployee.HireDate = employee.HireDate;
				existingEmployee.TerminationDate = employee.TerminationDate;
				existingEmployee.RecordStatus = employee.RecordStatus;

				existingEmployee.Departments?.Clear();

				if (employee.Departments != null)
				{
					foreach (var department in employee.Departments)
					{
						var existingDepartment = await _context.Departments.FindAsync(department.Id);
						if (existingDepartment != null)
						{
							existingEmployee.Departments?.Add(existingDepartment);
							
						}
					}
				}

				_context.Update(existingEmployee);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{
				throw new Exception("An error occurred while updating the database.", ex);
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while updating the employee.", ex);
			}
		}

		public async Task DeleteAsync(int id)
		{
			try
			{
				
				var employee = await _context.Employees.FindAsync(id);
				if (employee != null)
				{
					var departments = await _context.Departments.Where(d => d.ManagerId == id).ToListAsync();
					foreach (var department in departments)
					{
						department.ManagerId = null;
					}
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
					.Include(e => e.Departments)
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
					.Include(e => e.Departments).AsNoTracking()
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
