using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Application.IServices;

namespace Employee.Manager
{
	public partial class ChangeEmployeeData : Form
	{
		private readonly IEmployeeService _employeeService;
		private readonly IDepartmentService _departmentService;
		private readonly int _employee;
		public ChangeEmployeeData(IEmployeeService employeeService, IDepartmentService departmentService, int id)
		{
			InitializeComponent();
			_employeeService = employeeService;
			_departmentService = departmentService;
			_employee = id;
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
		private DepartmentDto GetSelectedDepartment()
		{
			return comboBox1.SelectedItem as DepartmentDto;
		}


		private async void ChangeEmployeeData_Load(object sender, EventArgs e)
		{
			fitEmployee();
		}
		private async void GetEmployeeDepartments()
		{
			var employee = await GetEmployee();

		}
		private async Task<EmployeeDto> GetEmployee()
		{
			var employee = await _employeeService.GetByIdAsync(_employee);
			return employee;
		}
		private async void fitEmployee()
		{
			var employee = await GetEmployee();
			if (employee != null)
			{
				FullName.Text = employee.FullName;
				Phone.Text = employee.Phone;
				EmployeeNumber.Text = employee.EmployeeNumber;
				Email.Text = employee.Email;
				Position.Text = employee.Position;
				comboBox2.Items.Add(RecordStatus.Closed);
				comboBox2.Items.Add(RecordStatus.Active);
				comboBox2.SelectedItem = employee.RecordStatus;
				if (employee.Departments != null)
				{
					foreach (var department in employee.Departments)
					selectedDepartment.Text += department.Name + "\n";
				}
				else
				{
					selectedDepartment.Text = "No Departments";
				}
			}
			LoadDepartmentAsync();

		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveChanges();
			this.Close();
		}
		private RecordStatus GetSelectedStatus()
		{
			try
			{
				return (RecordStatus)comboBox2.SelectedItem;
			}
			catch (InvalidCastException)
			{
				return RecordStatus.Active; 
			}
		}
		private async void SaveChanges()
		{
			var department = GetSelectedDepartment();
			var employee = new EmployeeDto();
			employee.Id = _employee;
			employee.FullName = FullName.Text;
			employee.Phone = Phone.Text;
			employee.EmployeeNumber = EmployeeNumber.Text;
			employee.Email = Email.Text;
			employee.Position = Position.Text;
			employee.RecordStatus = GetSelectedStatus();
			if (employee.RecordStatus.Equals(RecordStatus.Closed)) {
				employee.TerminationDate = DateTime.UtcNow;
			}
			if (department != null)
			{
				employee.Departments.Add(department);
			}
			else
			{
				employee.Departments.Clear();
			}
			await _employeeService.SaveAsync(employee);
			

		} 
	}
}
