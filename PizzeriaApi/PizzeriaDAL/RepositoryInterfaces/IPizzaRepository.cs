using PizzeriaDAL.Models;

namespace PizzeriaDAL.RepositoryInterfaces
{
    public interface IPizzaRepository
    {
        Task<IEnumerable<Pizza>> GetAll();

        public Pizza Get(int id);
    }
}
