using PizzeriaDAL.Dtos;

namespace PizzeriaBL.ServiceInterfaces
{
	public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDto>> GetAllByPizzeriaId(int pizzeriaId);
	}
}
