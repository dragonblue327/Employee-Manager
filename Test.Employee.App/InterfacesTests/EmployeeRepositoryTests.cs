using Employee.Domain.Entity;
using Employee.Domain.Repository;
using Moq;

namespace Employee.Tests.Repository
{
	public class EmployeeRepositoryTests
	{
		private readonly Mock<IEmployeeRepository> _mockRepo;
		private readonly Employe _testEmployee;

		public EmployeeRepositoryTests()
		{
			_mockRepo = new Mock<IEmployeeRepository>();
			_testEmployee = new Employe { Id = 1, FullName = "John Doe", EmployeeNumber = "12345" };
		}

		[Fact]
		public async Task CreateAsync_ShouldReturnCreatedEmployee()
		{
			// Arrange
			_mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Employe>())).ReturnsAsync(_testEmployee);

			// Act
			var result = await _mockRepo.Object.CreateAsync(_testEmployee);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(_testEmployee.Id, result.Id);
			Assert.Equal(_testEmployee.FullName, result.FullName);
		}

		[Fact]
		public async Task SaveAsync_ShouldCallSaveMethod()
		{
			// Arrange
			_mockRepo.Setup(repo => repo.SaveAsync(It.IsAny<Employe>())).Returns(Task.CompletedTask);

			// Act
			await _mockRepo.Object.SaveAsync(_testEmployee);

			// Assert
			_mockRepo.Verify(repo => repo.SaveAsync(_testEmployee), Times.Once);
		}

		[Fact]
		public async Task DeleteAsync_ShouldCallDeleteMethod()
		{
			// Arrange
			_mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

			// Act
			await _mockRepo.Object.DeleteAsync(_testEmployee.Id);

			// Assert
			_mockRepo.Verify(repo => repo.DeleteAsync(_testEmployee.Id), Times.Once);
		}

		[Fact]
		public async Task GetByIdAsync_ShouldReturnEmployee()
		{
			// Arrange
			_mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_testEmployee);

			// Act
			var result = await _mockRepo.Object.GetByIdAsync(_testEmployee.Id);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(_testEmployee.Id, result.Id);
			Assert.Equal(_testEmployee.FullName, result.FullName);
		}

		[Fact]
		public async Task GetAllAsync_ShouldReturnEmployees()
		{
			// Arrange
			var employees = new List<Employe> { _testEmployee };
			_mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

			// Act
			var result = await _mockRepo.Object.GetAllAsync();

			// Assert
			Assert.NotNull(result);
			Assert.Single(result);
			Assert.Equal(_testEmployee.Id, result.First().Id);
			Assert.Equal(_testEmployee.FullName, result.First().FullName);
		}
	}
}
