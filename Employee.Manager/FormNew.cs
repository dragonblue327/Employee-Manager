using Employee.Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee.Application;
using Employee.Application.Services;
using Employee.Application.IServices;
using Employee.Application.Interfaces;
using Employee.Domain.Entity;

namespace Employee.Manager
{
	public partial class FormNew : Form
	{
		private readonly IEmployeeService _employeeService;
		private readonly IDepartmentService _departmentService;

		public FormNew(IEmployeeService employeeService, IDepartmentService departmentService)
		{
			InitializeComponent();
			_employeeService = employeeService;
			_departmentService = departmentService;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveNewEmployee();
			this.Close();
		}
		private async void SaveNewEmployee()
		{
			var tempDepartment =  GetSelectedDepartment();
			var employeeDto = new EmployeeDto
			{
				FullName = FullName.Text,
				EmployeeNumber = EmployeeNumber.Text,
				Position = Position.Text,
				Email = Email.Text,
				Phone = Phone.Text,
				HireDate = HireDate.Value,
				
			};
			if (tempDepartment != null)
			{
				employeeDto.Departments.Add(tempDepartment);
			}
			_employeeService.CreateAsync(employeeDto);
		}
		private DepartmentDto GetSelectedDepartment()
		{
			return comboBox1.SelectedItem as DepartmentDto;
		}
		private void CancelButton_Click(object sender, EventArgs e)
		{
			var form2 = new Form1(_employeeService, _departmentService);

			form2.Show();
			this.Close();
		}

		private void FormNew_Load(object sender, EventArgs e)
		{
			LoadDepartmentAsync();
		}

		private async void LoadDepartmentAsync()
		{
			try
			{
				var departments = await _departmentService.GetAllAsync();

				foreach (var department in departments)
				{
					comboBox1.Items.Add(department);
				}
				comboBox1.DisplayMember = "Name";
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}
		}
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
