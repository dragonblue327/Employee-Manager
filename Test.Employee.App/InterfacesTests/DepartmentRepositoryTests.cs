using Employee.Domain.Entity;
using Employee.Domain.Repository;
using Moq;

namespace Employee.Tests.Repository
{
    public class DepartmentRepositoryTests
    {
        private readonly Mock<IDepartmentRepository> _mockRepo;
        private readonly Department _testDepartment;

        public DepartmentRepositoryTests()
        {
            _mockRepo = new Mock<IDepartmentRepository>();
            _testDepartment = new Department { Id = 1, Name = "HR" };
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedDepartment()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Department>())).ReturnsAsync(_testDepartment);

            // Act
            var result = await _mockRepo.Object.CreateAsync(_testDepartment);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_testDepartment.Id, result.Id);
            Assert.Equal(_testDepartment.Name, result.Name);
        }

        [Fact]
        public async Task SaveAsync_ShouldCallSaveMethod()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.SaveAsync(It.IsAny<Department>())).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.SaveAsync(_testDepartment);

            // Assert
            _mockRepo.Verify(repo => repo.SaveAsync(_testDepartment), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallDeleteMethod()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Act
            await _mockRepo.Object.DeleteAsync(_testDepartment.Id);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAsync(_testDepartment.Id), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnDepartment()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_testDepartment);

            // Act
            var result = await _mockRepo.Object.GetByIdAsync(_testDepartment.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_testDepartment.Id, result.Id);
            Assert.Equal(_testDepartment.Name, result.Name);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnDepartments()
        {
            // Arrange
            var departments = new List<Department> { _testDepartment };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(departments);

            // Act
            var result = await _mockRepo.Object.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(_testDepartment.Id, result.First().Id);
            Assert.Equal(_testDepartment.Name, result.First().Name);
        }
    }
}
