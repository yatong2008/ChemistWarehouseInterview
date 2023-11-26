using PizzeriaDAL.Models;
using PizzeriaDAL.RepositoryInterfaces;

namespace PizzeriaDAL.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IEnumerable<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza {
                Id = 1,
                Name = "Capricciosa",
                ToppingIds = new List<int> { 1, 5, 6, 4 }
            },
            new Pizza
            {
                Id = 2,
                Name = "Maxicana",
                ToppingIds = new List < int > { 1, 3, 2, 7 }
            },
            new Pizza
            {
                Id = 3,
                Name = "Margherita",
                ToppingIds = new List<int> { 1, 8, 11, 9 }
            },
            new Pizza
            {
                Id = 4,
                Name = "Vegetarian",
                ToppingIds = new List<int> { 1, 6, 2, 10, 4 }
            }
        };

        public Task<IEnumerable<Pizza>> GetAll()
        {
            return Task.FromResult(_pizzas);
        }

        public Pizza Get(int id)
        {
            return _pizzas.Single(p => p.Id == id);
        }
    }
}
