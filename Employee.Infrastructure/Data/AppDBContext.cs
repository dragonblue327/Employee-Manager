using Employee.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Data
{
	public class AppDBContext : DbContext
	{
		public DbSet<Department> Departments { get; set; }
		public DbSet<Employe> Employees { get; set; }
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Department>()
				.HasMany(d => d.Employees)
				.WithMany(e => e.Departments)
				.UsingEntity(j => j.ToTable("DepartmentEmployee"));

			modelBuilder.Entity<Department>()
				.HasOne(d => d.ParentDepartment)
				.WithMany()
				.HasForeignKey(d => d.ParentDepartmentId)
				.IsRequired(false) 
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Department>()
				.HasOne(d => d.Manager)
				.WithMany()
				.HasForeignKey(d => d.ManagerId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);
		}



	}
}
