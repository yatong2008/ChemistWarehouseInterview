using PizzeriaDAL.Models;

namespace PizzeriaDAL.RepositoryInterfaces
{
    public interface IPizzaRepository
    {
        Task<List<Pizza>> GetAll();

        public Pizza Get(int id);

        public void Add(Pizza pizza);

        public void Remove(int id);
    }
}
