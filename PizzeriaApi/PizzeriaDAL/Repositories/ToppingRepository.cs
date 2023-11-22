using PizzeriaDAL.Models;
using PizzeriaDAL.RepositoryInterfaces;

namespace PizzeriaDAL.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly List<Topping> _toppings = new List<Topping>
        {
            new Topping
            {
                Id = 1,
                Name = "Cheese",
                Price = 1
            },
            new Topping
            {
                Id = 2,
                Name = "Capsicum",
                Price = 1
            },
            new Topping
            {
                Id = 3,
                Name = "Salami",
                Price = 1
            },
            new Topping
            {
                Id = 4,
                Name = "Olives",
                Price = 1
            },
            new Topping
            {
                Id = 5,
                Name = "Ham",
                Price = 0
            },
            new Topping
            {
                Id = 6,
                Name = "Mushroom",
                Price = 0
            },
            new Topping
            {
                Id = 7,
                Name = "Chilli",
                Price = 0
            },
            new Topping
            {
                Id = 8,
                Name = "Spinach",
                Price = 0
            },
            new Topping
            {
                Id = 9,
                Name = "Cherry Tomatoes",
                Price = 0
            },
            new Topping
            {
                Id = 10,
                Name = "Onion",
                Price = 0
            },
            new Topping
            {
                Id = 11,
                Name = "Ricotta",
                Price = 0
            }
        };

        public Task<List<Topping>> GetAll()
        {
            return Task.FromResult(_toppings);
        }

        public Topping Get(int id)
        {
            return _toppings.Single(t => t.Id == id);
        }
    }
}
