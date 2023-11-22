using PizzeriaDAL.Models;

namespace PizzeriaDAL.RepositoryInterfaces
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> GetMenuItemsByPizzeriaId(int menuId);
    }
}
