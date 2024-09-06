using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Application.IServices;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Employee.Manager
{
	public partial class NewDepartment : Form
	{
		private readonly IEmployeeService _employeeService;
		private readonly IDepartmentService _departmentService;
		public NewDepartment(IEmployeeService employeeService, IDepartmentService departmentService)
		{
			InitializeComponent();
			_employeeService = employeeService;
			_departmentService = departmentService;
		}

		private List<EmployeeDto> GetSelectedUsers()
		{
			var selectedEmployeeDto = new List<EmployeeDto>();

			foreach (EmployeeDto employeeDto in checkedListBox1.CheckedItems)
			{
				selectedEmployeeDto.Add(employeeDto);
			}

			return selectedEmployeeDto;
		}
		private async Task CreateDepartmentAsync()
		{
			try
			{
				if (ValidateInputs())
				{

					var departmentDto = new DepartmentDto();

					departmentDto.Name = DepartmentName.Text;
					departmentDto.ManagerId = GetSelectedUser()?.Id ?? 0;
					departmentDto.Employees = GetSelectedUsers();
					departmentDto.ParentDepartmentId = GetSelectedDepartment()?.Id ?? null;


					var createdDepartment = await _departmentService.CreateAsync(departmentDto);

					MessageBox.Show($"Подразделения: {createdDepartment.Name} создана.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"выбрате руководителя: {ex.Message}");
			}
		}
		private async void SaveButton_Click(object sender, EventArgs e)
		{
			
			 await CreateDepartmentAsync();
		}
		private EmployeeDto GetSelectedUser()
		{
			
				return comboBox2.SelectedItem as EmployeeDto;
			
		}
		private bool ValidateInputs()
		{
			if (comboBox2.SelectedIndex == -1)
			{
				MessageBox.Show("выбрате руководителя.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (string.IsNullOrWhiteSpace(DepartmentName.Text))
			{
				MessageBox.Show("Название Подразделения не может быть пустым.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		
		private DepartmentDto GetSelectedDepartment()
		{
			return comboBox1.SelectedItem as DepartmentDto;
		}
		private async void LoadDepartmentAsync()
		{
			try
			{
				comboBox1.Items.Clear();

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
		private async void LoadEmployeeAsync()
		{
			try
			{
				checkedListBox1.Items.Clear();
				var employees = await _employeeService.GetAllAsync();

				foreach (var employee in employees)
				{
					comboBox2.Items.Add(employee);
					checkedListBox1.Items.Add(employee, false); 
				}
				checkedListBox1.DisplayMember = "FullName";
				comboBox2.DisplayMember = "FullName";
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}
		}

		private void NewDepartment_Load(object sender, EventArgs e)
		{

			LoadEmployeeAsync();

		}

		private void IsChild_CheckedChanged(object sender, EventArgs e)
		{

			if (IsChild.Checked)
			{
				LoadDepartmentAsync();
				comboBox1.Visible = true;
			}
			else comboBox1.Visible = false;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
