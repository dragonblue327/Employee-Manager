using System.Collections.Generic;
using System.Threading.Tasks;
using Employee.Application.DTO;
using Employee.Application.IServices;
using Moq;
using Xunit;

namespace Employee.Tests.Service
{
	public class EmployeeServiceTests
	{
		private readonly Mock<IEmployeeService> _mockService;
		private readonly EmployeeDto _testEmployeeDto;

		public EmployeeServiceTests()
		{
			_mockService = new Mock<IEmployeeService>();
			_testEmployeeDto = new EmployeeDto { Id = 1, FullName = "John Doe", EmployeeNumber = "12345" };
		}

		[Fact]
		public async Task CreateAsync_ShouldReturnCreatedEmployeeDto()
		{
			// Arrange
			_mockService.Setup(service => service.CreateAsync(It.IsAny<EmployeeDto>())).ReturnsAsync(_testEmployeeDto);

			// Act
			var result = await _mockService.Object.CreateAsync(_testEmployeeDto);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(_testEmployeeDto.Id, result.Id);
			Assert.Equal(_testEmployeeDto.FullName, result.FullName);
		}

		[Fact]
		public async Task SaveAsync_ShouldCallSaveMethod()
		{
			// Arrange
			_mockService.Setup(service => service.SaveAsync(It.IsAny<EmployeeDto>())).Returns(Task.CompletedTask);

			// Act
			await _mockService.Object.SaveAsync(_testEmployeeDto);

			// Assert
			_mockService.Verify(service => service.SaveAsync(_testEmployeeDto), Times.Once);
		}

		[Fact]
		public async Task DeleteAsync_ShouldCallDeleteMethod()
		{
			// Arrange
			_mockService.Setup(service => service.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

			// Act
			await _mockService.Object.DeleteAsync(_testEmployeeDto.Id);

			// Assert
			_mockService.Verify(service => service.DeleteAsync(_testEmployeeDto.Id), Times.Once);
		}

		[Fact]
		public async Task GetByIdAsync_ShouldReturnEmployeeDto()
		{
			// Arrange
			_mockService.Setup(service => service.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_testEmployeeDto);

			// Act
			var result = await _mockService.Object.GetByIdAsync(_testEmployeeDto.Id);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(_testEmployeeDto.Id, result.Id);
			Assert.Equal(_testEmployeeDto.FullName, result.FullName);
		}

		[Fact]
		public async Task GetAllAsync_ShouldReturnEmployeeDtos()
		{
			// Arrange
			var employeeDtos = new List<EmployeeDto> { _testEmployeeDto };
			_mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(employeeDtos);

			// Act
			var result = await _mockService.Object.GetAllAsync();

			// Assert
			Assert.NotNull(result);
			Assert.Single(result);
			Assert.Equal(_testEmployeeDto.Id, result.First().Id);
			Assert.Equal(_testEmployeeDto.FullName, result.First().FullName);
		}

		[Fact]
		public void SaveDataFromExcelFileAsync_ShouldCallSaveDataMethod()
		{
			// Arrange
			var filePath = "test.xlsx";
			_mockService.Setup(service => service.SaveDataFromExcelFileAsync(It.IsAny<string>()));

			// Act
			_mockService.Object.SaveDataFromExcelFileAsync(filePath);

			// Assert
			_mockService.Verify(service => service.SaveDataFromExcelFileAsync(filePath), Times.Once);
		}
	}
}
