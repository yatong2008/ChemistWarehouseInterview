using NSubstitute;
using PizzeriaBL.Services;
using PizzeriaDAL.Dtos;
using PizzeriaDAL.Models;
using PizzeriaDAL.RepositoryInterfaces;

public class PizzeriaServiceTests
{
    [Fact]
    public async Task GetAll_ReturnsPizzeriaDtos()
    {
        // Arrange
        var fakePizzerias = new List<Pizzeria>
        {
            new Pizzeria { Id = 1, Name = "Pizzeria1", ImageUrl = "url1" },
            new Pizzeria { Id = 2, Name = "Pizzeria2", ImageUrl = "url2" }
        };

        var fakeRepository = Substitute.For<IPizzeriaRepository>();
        fakeRepository.GetAll().Returns(Task.FromResult<IEnumerable<Pizzeria>>(fakePizzerias));

        var service = new PizzeriaService(fakeRepository);

        // Act
        var result = await service.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count()); // Assuming there are two pizzerias in the fake list
        Assert.Equal(fakePizzerias.First().Name, result.First().Name);
        Assert.Equal(fakePizzerias.Last().ImageUrl, result.Last().ImageUrl);
    }

    [Fact]
    public async Task Get_ValidId_ReturnsPizzeriaDto()
    {
        // Arrange
        var fakePizzeria = new Pizzeria { Id = 1, Name = "Pizzeria1", ImageUrl = "url1" };

        var fakeRepository = Substitute.For<IPizzeriaRepository>();
        fakeRepository.GetById(Arg.Any<int>()).Returns(Task.FromResult(fakePizzeria));

        var service = new PizzeriaService(fakeRepository);

        // Act
        var result = await service.Get(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fakePizzeria.Id, result.Id);
        Assert.Equal(fakePizzeria.Name, result.Name);
        Assert.Equal(fakePizzeria.ImageUrl, result.ImageUrl);
    }
}