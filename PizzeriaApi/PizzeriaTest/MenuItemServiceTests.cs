using NSubstitute;
using PizzeriaBL.Services;
using PizzeriaDAL.Dtos;
using PizzeriaDAL.Models;
using PizzeriaDAL.RepositoryInterfaces;

public class MenuItemServiceTests
{
    [Fact]
    public async Task GetAllByPizzeriaId_ReturnsMenuItemDtos()
    {
        // Arrange
        var fakeMenuItems = new List<MenuItem>
    {
        new MenuItem { Id = 1, PizzeriaId = 1, PizzaId = 1, Price = 20 },
        new MenuItem { Id = 2, PizzeriaId = 1, PizzaId = 2, Price = 18 },
        // Add more fake menu items as needed
    };

        var fakePizzas = new List<Pizza>
    {
        new Pizza { Id = 1, Name = "Pizza1", ToppingIds = new List<int> { 1, 2 } },
        new Pizza { Id = 2, Name = "Pizza2", ToppingIds = new List<int> { 1, 2 } },
        // Add more fake pizzas as needed
    };

        var fakeToppings = new List<Topping>
    {
        new Topping { Id = 1, Name = "Topping1", Price = 2 },
        new Topping { Id = 2, Name = "Topping2", Price = 3 },
        // Add more fake toppings as needed
    };

        var menuItemRepository = Substitute.For<IMenuItemRepository>();
        menuItemRepository.GetMenuItemsByPizzeriaId(Arg.Any<int>()).Returns(Task.FromResult<IEnumerable<MenuItem>>(fakeMenuItems));

        var pizzaRepository = Substitute.For<IPizzaRepository>();
        pizzaRepository.GetAll().Returns(Task.FromResult<IEnumerable<Pizza>>(fakePizzas));

        var toppingRepository = Substitute.For<IToppingRepository>();
        toppingRepository.GetAll().Returns(Task.FromResult<IEnumerable<Topping>>(fakeToppings));

        var service = new MenuItemService(menuItemRepository, pizzaRepository, toppingRepository);

        // Act
        var result = await service.GetAllByPizzeriaId(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fakeMenuItems.Count, result.Count());

        Assert.All(result, menuItem =>
        {
            var expectedPizza = fakePizzas.SingleOrDefault(p => p.Id == menuItem.PizzaId);
            Assert.NotNull(expectedPizza); // Check if the pizza is found
            Assert.Equal(expectedPizza?.Name, menuItem.PizzaName);

            Assert.NotNull(expectedPizza?.ToppingIds);
            Assert.Equal(expectedPizza!.ToppingIds.Count, menuItem.Toppings.Count);

            // Assert for toppings
            Assert.All(menuItem.Toppings, topping =>
            {
                var expectedTopping = fakeToppings.SingleOrDefault(t => t.Id == topping.Id);
                Assert.NotNull(expectedTopping); // Check if the topping is found
                Assert.Equal(expectedTopping?.Name, topping.Name);
                Assert.Equal(expectedTopping?.Price, topping.Price);
            });
        });
    }
}
