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
using System.Text.RegularExpressions;

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
			if (ValidateForm())
			{
				SaveNewEmployee();
				var form2 = new Form1(_employeeService, _departmentService);
				form2.Show();
				this.Close();
			}
		}
		private bool ValidateForm()
		{
			bool isValid = true;

			if (string.IsNullOrWhiteSpace(FullName.Text))
			{
				MessageBox.Show("Полное имя не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}
			else if (FullName.Text.Length > 100)
			{
				MessageBox.Show("Полное имя не может быть длиннее 100 символов.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}

			else if(string.IsNullOrWhiteSpace(EmployeeNumber.Text))
			{
				MessageBox.Show("Номер сотрудника не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}
			else if (!Regex.IsMatch(EmployeeNumber.Text, @"^\d{5}$"))
			{
				MessageBox.Show("Номер сотрудника должен состоять из 5 цифр.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}

			else if(string.IsNullOrWhiteSpace(Position.Text))
			{
				MessageBox.Show("Должность не может быть пустой.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}
			else if (Position.Text.Length > 50)
			{
				MessageBox.Show("Должность не может быть длиннее 50 символов.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}
			else if(string.IsNullOrWhiteSpace(Email.Text))
			{
				MessageBox.Show("Электронная почта не может быть пустой.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}
			else if (!Regex.IsMatch(Email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
			{
				MessageBox.Show("Неверный адрес электронной почты.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}
			else if(string.IsNullOrWhiteSpace(Phone.Text))
			{
				MessageBox.Show("Номер телефона не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}
			else if (!Regex.IsMatch(Phone.Text, @"^\+?\d{10,15}$"))
			{
				MessageBox.Show("Неверный номер телефона.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}
			else if(HireDate.Value == null)
			{
				MessageBox.Show("Дата найма не может быть пустой.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				isValid = false;
			}

			return isValid;
		}


		private async void SaveNewEmployee()
		{
			
				var tempDepartment = GetSelectedDepartment();
				var employeeDto = new EmployeeDto
				{
					FullName = FullName.Text,
					EmployeeNumber = EmployeeNumber.Text,
					Position = Position.Text,
					Email = Email.Text,
					Phone = Phone.Text,
					HireDate = HireDate.Value
				};
				if (tempDepartment != null)
				{
					employeeDto.Departments.Add(tempDepartment);
				}
				await _employeeService.CreateAsync(employeeDto);
			
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

		public async void FormNew_Load(object sender, EventArgs e)
		{
			await LoadDepartmentAsync();
		}

		private async Task LoadDepartmentAsync()
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
