using PizzeriaDAL.Repositories;

namespace PizzeriaTest;

public class PizzeriaRepositoryTests
{
    [Fact]
    public async Task GetAll_ReturnsAllPizzerias()
    {
        // Arrange
        var repository = new PizzeriaRepository();

        // Act
        var result = await repository.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count()); // Assuming there are two pizzerias in the list
    }

    [Fact]
    public async Task GetById_ValidId_ReturnsPizzeria()
    {
        // Arrange
        var repository = new PizzeriaRepository();
        var expectedId = 1;

        // Act
        var result = await repository.GetById(expectedId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedId, result?.Id);
    }

    [Fact]
    public async Task GetById_InvalidId_ReturnsNull()
    {
        // Arrange
        var repository = new PizzeriaRepository();
        var invalidId = 999; // Assuming 999 is an invalid ID

        // Act
        var result = await repository.GetById(invalidId);

        // Assert
        Assert.Null(result);
    }
}