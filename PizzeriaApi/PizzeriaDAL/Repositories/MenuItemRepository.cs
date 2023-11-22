using PizzeriaDAL.Models;
using PizzeriaDAL.RepositoryInterfaces;

namespace PizzeriaDAL.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly List<MenuItem> _allMenuItems = new List<MenuItem>
        {
            new MenuItem
            {
                Id = 1,
                PizzeriaId = 1,
                PizzaId = 1,
                Price = 20
            },
            new MenuItem
            {
                Id = 2,
                PizzeriaId = 1,
                PizzaId = 2,
                Price = 18
            },
            new MenuItem
            {
                Id = 3,
                PizzeriaId = 1,
                PizzaId = 3,
                Price = 22
            },
            new MenuItem
            {
                Id = 4,
                PizzeriaId = 2,
                PizzaId = 1,
                Price = 25,
            },
            new MenuItem
            {
                Id = 5,
                PizzeriaId = 2,
                PizzaId = 4,
                Price = 17
            }
        };

        public Task<IEnumerable<MenuItem>> GetMenuItemsByPizzeriaId(int pizzeriaId)
        {
            return Task.FromResult(_allMenuItems.Where(p => p.PizzeriaId == pizzeriaId));
        }
    }
}
