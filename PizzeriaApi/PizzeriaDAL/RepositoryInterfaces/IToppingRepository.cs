using PizzeriaDAL.Models;

namespace PizzeriaDAL.RepositoryInterfaces
{
	public interface IToppingRepository
	{
		Task<IEnumerable<Topping>> GetAll();
        public Topping Get(int id);
	}
}
