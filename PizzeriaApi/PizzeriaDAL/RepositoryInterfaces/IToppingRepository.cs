using PizzeriaDAL.Models;

namespace PizzeriaDAL.RepositoryInterfaces
{
	public interface IToppingRepository
	{
		Task<List<Topping>> GetAll();
        public Topping Get(int id);
	}
}
