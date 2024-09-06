using Employee.Domain.Entity;
using Employee.Domain.Repository;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Employee.Infrastructure.Repository
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly AppDBContext _context;

		public DepartmentRepository(AppDBContext context)
		{
			_context = context;
		}

		public async Task<Department> CreateAsync(Department department)
		{
			try
			{
				var tempEmployees = department.Employees.ToList();
				department.Employees.Clear();

				foreach (var employee in tempEmployees)
				{
					var existingEmployee = await _context.Employees.FindAsync(employee.Id);
					if (existingEmployee != null)
					{
						existingEmployee.Departments.Add (department);
						department.Employees.Add(existingEmployee);
					}
				}

				_context.Departments.Add(department);
				await _context.SaveChangesAsync();
				return department;
			}
			catch (DbUpdateException dbException)
			{
				throw new Exception("A database error occurred while creating the department record.", dbException);
			}
			catch (Exception exception)
			{
				throw new Exception("An unexpected error occurred.", exception);
			}
		}



		public async Task SaveAsync(Department department)
		{
			try
			{
				_context.Entry(department).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{
				throw new Exception("An error occurred while saving the department.", ex);
			}
			catch (Exception ex)
			{
				throw new Exception("An unexpected error occurred.", ex);
			}
		}

		public async Task DeleteAsync(int id)
		{
			try
			{
				var department = await _context.Departments.FindAsync(id);
				if (department != null)
				{
					var childDepartments = _context.Departments.Where(d => d.ParentDepartmentId == id).ToList();
				
					 foreach (var child in childDepartments)
					 {
					     child.ParentDepartmentId = null; 
					 }

					_context.Departments.Remove(department);
					await _context.SaveChangesAsync();
				}
			}
			catch (DbUpdateException ex)
			{
				throw new Exception("An error occurred while deleting the department.", ex);
			}
			catch (Exception ex)
			{
				throw new Exception("An unexpected error occurred.", ex);
			}
		}


		public async Task<Department> GetByIdAsync(int id)
		{
			try
			{
				var department = _context.Departments
					.Include(d => d.ParentDepartment)
					.Include(d => d.Manager)
					.Include(d => d.Employees)
					.FirstOrDefaultAsync(d => d.Id == id);

				if (department == null)
				{
					throw new InvalidOperationException($"Department with ID {id} not found.");
				}

				return await department;
			}
			catch (DbUpdateException ex)
			{
				throw new Exception("An error occurred while retrieving the department.", ex);
			}
			catch (Exception ex)
			{
				throw new Exception("An unexpected error occurred.", ex);
			}
		}

		public async Task<IEnumerable<Department>> GetAllAsync()
		{
			try
			{
				return await _context.Departments.AsNoTracking()
					.Include(d => d.ParentDepartment).AsNoTracking()
					.Include(d => d.Manager).AsNoTracking()
					.Include(d => d.Employees).AsNoTracking()
					.ToListAsync();
			}
			catch (DbUpdateException ex)
			{
				throw new Exception("An error occurred while retrieving the departments.", ex);
			}
			catch (Exception ex)
			{
				throw new Exception("An unexpected error occurred.", ex);
			}
		}
	}

}
