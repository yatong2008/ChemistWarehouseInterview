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
                Name = "Preston"
            },
            new Pizzeria
            {
                Id = 2,
                Name = "Southbank"
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
