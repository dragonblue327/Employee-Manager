using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Moq;

namespace Employee.Tests.Service
{
	public class DepartmentServiceTests
	{
		private readonly Mock<IDepartmentService> _mockService;
		private readonly DepartmentDto _testDepartmentDto;

		public DepartmentServiceTests()
		{
			_mockService = new Mock<IDepartmentService>();
			_testDepartmentDto = new DepartmentDto { Id = 1, Name = "HR" };
		}

		[Fact]
		public async Task CreateAsync_ShouldReturnCreatedDepartmentDto()
		{
			// Arrange
			_mockService.Setup(service => service.CreateAsync(It.IsAny<DepartmentDto>())).ReturnsAsync(_testDepartmentDto);

			// Act
			var result = await _mockService.Object.CreateAsync(_testDepartmentDto);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(_testDepartmentDto.Id, result.Id);
			Assert.Equal(_testDepartmentDto.Name, result.Name);
		}

		[Fact]
		public async Task SaveAsync_ShouldCallSaveMethod()
		{
			// Arrange
			_mockService.Setup(service => service.SaveAsync(It.IsAny<DepartmentDto>())).Returns(Task.CompletedTask);

			// Act
			await _mockService.Object.SaveAsync(_testDepartmentDto);

			// Assert
			_mockService.Verify(service => service.SaveAsync(_testDepartmentDto), Times.Once);
		}

		[Fact]
		public async Task DeleteAsync_ShouldCallDeleteMethod()
		{
			// Arrange
			_mockService.Setup(service => service.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

			// Act
			await _mockService.Object.DeleteAsync(_testDepartmentDto.Id);

			// Assert
			_mockService.Verify(service => service.DeleteAsync(_testDepartmentDto.Id), Times.Once);
		}

		[Fact]
		public async Task GetByIdAsync_ShouldReturnDepartmentDto()
		{
			// Arrange
			_mockService.Setup(service => service.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_testDepartmentDto);

			// Act
			var result = await _mockService.Object.GetByIdAsync(_testDepartmentDto.Id);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(_testDepartmentDto.Id, result.Id);
			Assert.Equal(_testDepartmentDto.Name, result.Name);
		}

		[Fact]
		public async Task GetAllAsync_ShouldReturnDepartmentDtos()
		{
			// Arrange
			var departmentDtos = new List<DepartmentDto> { _testDepartmentDto };
			_mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(departmentDtos);

			// Act
			var result = await _mockService.Object.GetAllAsync();

			// Assert
			Assert.NotNull(result);
			Assert.Single(result);
			Assert.Equal(_testDepartmentDto.Id, result.First().Id);
			Assert.Equal(_testDepartmentDto.Name, result.First().Name);
		}
	}
}
