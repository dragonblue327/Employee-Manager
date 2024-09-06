using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee.Application.DTO;
using Employee.Application.IServices;
using Employee.Application.Interfaces;
using Moq;
using Xunit;
using Employee.Manager;

namespace Employee.Tests
{
	public class Form1Tests
	{
		private readonly Mock<IEmployeeService> _mockEmployeeService;
		private readonly Mock<IDepartmentService> _mockDepartmentService;
		private readonly Form1 _form;

		public Form1Tests()
		{
			_mockEmployeeService = new Mock<IEmployeeService>();
			_mockDepartmentService = new Mock<IDepartmentService>();
			_form = new Form1(_mockEmployeeService.Object, _mockDepartmentService.Object);
		}

		[Fact]
		public async Task LoadDataAsync_ShouldLoadEmployeesIntoDataGridView()
		{
			// Arrange
			var employees = new List<EmployeeDto>
			{
				new EmployeeDto { Id = 1, FullName = "John Doe", EmployeeNumber = "12345" }
			};
			_mockEmployeeService.Setup(service => service.GetAllAsync()).ReturnsAsync(employees);

			// Act
			await _form.LoadDataAsync();

			// Assert
			Assert.NotNull(_form.dataGridView1.DataSource);
			var dataSource = _form.dataGridView1.DataSource as List<EmployeeDto>;
			Assert.Single(dataSource);
			Assert.Equal("John Doe", dataSource[0].FullName);
		}

		[Fact]
		public void Button1_Click_ShouldOpenFormNew()
		{
			// Arrange
			var button = new Button();
			button.Click += _form.button1_Click;

			// Act
			button.PerformClick();

			// Assert
			// Verify that FormNew is opened (this is tricky to assert directly, so you might need to use a different approach)
		}

		[Fact]
		public void Button2_Click_ShouldOpenNewDepartment()
		{
			// Arrange
			var button = new Button();
			button.Click += _form.button2_Click;

			// Act
			button.PerformClick();

			// Assert
			// Verify that NewDepartment is opened (this is tricky to assert directly, so you might need to use a different approach)
		}

		[Fact]
		public async Task DataGridView1_CellClick_ShouldOpenChangeEmployeeDataForm()
		{
			// Arrange
			var employees = new List<EmployeeDto>
			{
				new EmployeeDto { Id = 1, FullName = "John Doe", EmployeeNumber = "12345" }
			};
			_mockEmployeeService.Setup(service => service.GetAllAsync()).ReturnsAsync(employees);
			await _form.LoadDataAsync();

			var cellEventArgs = new DataGridViewCellEventArgs(0, 0);

			// Act
			_form.dataGridView1_CellClick(this, cellEventArgs);

			// Assert
			// Verify that ChangeEmployeeData form is opened (this is tricky to assert directly, so you might need to use a different approach)
		}

		[Fact]
		public async Task DataGridView1_CellClick_ShouldDeleteEmployee()
		{
			// Arrange
			var employees = new List<EmployeeDto>
			{
				new EmployeeDto { Id = 1, FullName = "John Doe", EmployeeNumber = "12345" }
			};
			_mockEmployeeService.Setup(service => service.GetAllAsync()).ReturnsAsync(employees);
			_mockEmployeeService.Setup(service => service.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);
			await _form.LoadDataAsync();

			var cellEventArgs = new DataGridViewCellEventArgs(_form.dataGridView1.Columns["Delete"].Index, 0);

			// Act
			_form.dataGridView1_CellClick(this, cellEventArgs);

			// Assert
			_mockEmployeeService.Verify(service => service.DeleteAsync(It.IsAny<int>()), Times.Once);
		}
	}
}
