using PizzeriaDAL.Models;

namespace PizzeriaDAL.RepositoryInterfaces
{
    public interface IPizzeriaRepository
    {
        Task<IEnumerable<Pizzeria>> GetAll();

        Task<Pizzeria?> GetById(int id);
    }
}
