using PizzeriaDAL.Repositories;

public class MenuItemRepositoryTests
{
    [Fact]
    public async Task GetMenuItemsByPizzeriaId_ReturnsMenuItems()
    {
        // Arrange
        var repository = new MenuItemRepository();
        var pizzeriaId = 1;

        // Act
        var result = await repository.GetMenuItemsByPizzeriaId(pizzeriaId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count()); // Assuming there are three menu items for pizzeriaId 1
        Assert.All(result, menuItem => Assert.Equal(pizzeriaId, menuItem.PizzeriaId));
    }

    [Fact]
    public async Task GetMenuItemsByPizzeriaId_EmptyResultForInvalidId()
    {
        // Arrange
        var repository = new MenuItemRepository();
        var invalidPizzeriaId = 999; // Assuming 999 is an invalid pizzeriaId

        // Act
        var result = await repository.GetMenuItemsByPizzeriaId(invalidPizzeriaId);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}