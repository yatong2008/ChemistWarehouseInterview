using PizzeriaDAL.Models;
using PizzeriaDAL.RepositoryInterfaces;

namespace PizzeriaDAL.Repositories
{
    public class PizzeriaRepository : IPizzeriaRepository
    {
        private readonly IEnumerable<Pizzeria> _pizzerias = new List<Pizzeria>
        {
            new Pizzeria
            {
                Id = 1,
                Name = "Preston",
                ImageUrl = "https://images.pexels.com/photos/2928068/pexels-photo-2928068.jpeg"
            },
            new Pizzeria
            {
                Id = 2,
                Name = "Southbank",
                ImageUrl = "https://images.pexels.com/photos/17734945/pexels-photo-17734945/free-photo-of-buenos-aires-street-at-night.jpeg"
            }
        };

        public Task<IEnumerable<Pizzeria>> GetAll()
        {
            return Task.FromResult(_pizzerias);
        }

        public Task<Pizzeria?> GetById(int id)
        {
            return Task.FromResult(_pizzerias.SingleOrDefault(r => r.Id == id));
        }
    }
}
