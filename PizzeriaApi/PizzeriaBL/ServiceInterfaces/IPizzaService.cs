using PizzeriaDAL.Dtos;

namespace PizzeriaBL.ServiceInterfaces
{
	public interface IPizzaService
	{
		public IEnumerable<PizzaDto> GetMenu(int pizzeriaId);

		public PizzaDto GetById(int id);

		public PizzaDto GetPizzeriaAndPizzaId(int PizzeriaId, int id);

	}
}
