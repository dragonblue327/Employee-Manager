using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Domain.Entity;
using Employee.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentService(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		public async Task<DepartmentDto> CreateAsync(DepartmentDto departmentDto)
		{
			var department = new Department
			{
				Name = departmentDto.Name,
				ParentDepartmentId = departmentDto.ParentDepartmentId,
				ManagerId = departmentDto.ManagerId,
				Employees = departmentDto.Employees.Select(e => new Employe
				{
					Id = e.Id,
					FullName = e.FullName,
					EmployeeNumber = e.EmployeeNumber,
					Position = e.Position,
					DepartmentId = e.DepartmentId,
					Email = e.Email,
					Phone = e.Phone,
					HireDate = e.HireDate,
					TerminationDate = e.TerminationDate,
					RecordStatus = (Domain.Entity.RecordStatus)e.RecordStatus
				}).ToList()
			};

			var createdDepartment = await _departmentRepository.CreateAsync(department);

			return new DepartmentDto
			{
				Id = createdDepartment.Id,
				Name = createdDepartment.Name,
				ParentDepartmentId = createdDepartment.ParentDepartmentId,
				ManagerId = createdDepartment.ManagerId,
				Employees = createdDepartment.Employees.Select(e => new EmployeeDto
				{
					Id = e.Id,
					FullName = e.FullName,
					EmployeeNumber = e.EmployeeNumber,
					Position = e.Position,
					DepartmentId = e.DepartmentId,
					Email = e.Email,
					Phone = e.Phone,
					HireDate = e.HireDate,
					TerminationDate = e.TerminationDate,
					RecordStatus = (DTO.RecordStatus)e.RecordStatus
				}).ToList()
			};
		}

		public async Task SaveAsync(DepartmentDto departmentDto)
		{
			var department = new Department
			{
				Id = departmentDto.Id,
				Name = departmentDto.Name,
				ParentDepartmentId = departmentDto.ParentDepartmentId,
				ManagerId = departmentDto.ManagerId,
				Employees = departmentDto.Employees.Select(e => new Employe
				{
					Id = e.Id,
					FullName = e.FullName,
					EmployeeNumber = e.EmployeeNumber,
					Position = e.Position,
					DepartmentId = e.DepartmentId,
					Email = e.Email,
					Phone = e.Phone,
					HireDate = e.HireDate,
					TerminationDate = e.TerminationDate,
					RecordStatus = (Domain.Entity.RecordStatus)e.RecordStatus
				}).ToList()
			};

			await _departmentRepository.SaveAsync(department);
		}

		public async Task DeleteAsync(int id)
		{
			await _departmentRepository.DeleteAsync(id);
		}

		public async Task<DepartmentDto> GetByIdAsync(int id)
		{
			var department = await _departmentRepository.GetByIdAsync(id);

			return new DepartmentDto
			{
				Id = department.Id,
				Name = department.Name,
				ParentDepartmentId = department.ParentDepartmentId,
				ManagerId = department.ManagerId,
				Employees = department.Employees.Select(e => new EmployeeDto
				{
					Id = e.Id,
					FullName = e.FullName,
					EmployeeNumber = e.EmployeeNumber,
					Position = e.Position,
					DepartmentId = e.DepartmentId,
					Email = e.Email,
					Phone = e.Phone,
					HireDate = e.HireDate,
					TerminationDate = e.TerminationDate,
					RecordStatus = (DTO.RecordStatus)e.RecordStatus
				}).ToList()
			};
		}

		public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
		{
			var departments = await _departmentRepository.GetAllAsync();

			return departments.Select(department => new DepartmentDto
			{
				Id = department.Id,
				Name = department.Name,
				ParentDepartmentId = department.ParentDepartmentId,
				ManagerId = department.ManagerId,
				Employees = department.Employees.Select(e => new EmployeeDto
				{
					Id = e.Id,
					FullName = e.FullName,
					EmployeeNumber = e.EmployeeNumber,
					Position = e.Position,
					DepartmentId = e.DepartmentId,
					Email = e.Email,
					Phone = e.Phone,
					HireDate = e.HireDate,
					TerminationDate = e.TerminationDate,
					RecordStatus = (DTO.RecordStatus)e.RecordStatus
				}).ToList()
			}).ToList();
		}
	}

}
