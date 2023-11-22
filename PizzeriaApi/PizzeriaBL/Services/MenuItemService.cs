using PizzeriaBL.ServiceInterfaces;
using PizzeriaDAL.Dtos;
using PizzeriaDAL.RepositoryInterfaces;

namespace PizzeriaBL.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IToppingRepository _toppingRepository;
        public MenuItemService(IMenuItemRepository repository, IPizzaRepository pizzaRepository, IToppingRepository toppingRepository)
        {
            _repository = repository;
            _pizzaRepository = pizzaRepository;
            _toppingRepository = toppingRepository;
        }

        public async Task<IEnumerable<MenuItemDto>> GetAllByPizzeriaId(int pizzeriaId)
        {
            var menuItems = await _repository.GetMenuItemsByPizzeriaId(pizzeriaId);

            var pizzas = await _pizzaRepository.GetAll();

            var toppings = await _toppingRepository.GetAll();

            var results = menuItems.Select(x => new MenuItemDto
            {
                Id = x.Id,
                PizzaId = x.PizzaId,
                PizzeriaId = x.PizzeriaId,
                Price = x.Price,
                PizzaName = pizzas.Single(p => p.Id == x.PizzaId).Name, //todo: Better way is retrieving from EF ORM/Include(Linq)
                Toppings = pizzas.Single(p => p.Id == x.PizzaId).ToppingIds.Select(id => new ToppingDto()
                {
                    Id = id,
                    Name = toppings.Single(t => t.Id == id).Name,
                    Price = toppings.Single(t => t.Id == id).Price
                }).ToList()
            });

            return results;
        }
    }
}
