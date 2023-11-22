using Microsoft.AspNetCore.Mvc;
using PizzeriaBL.ServiceInterfaces;
using PizzeriaDAL.Dtos;

namespace Pizzeria.Api.Controllers
{
    [ApiController]
    [Route("api/pizzerias/{pizzeriaId}/[controller]")]
    public class MenuItemsController : Controller
    {
        private readonly IMenuItemService _service;

        public MenuItemsController(IMenuItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzeriaDto>>> GetAllMenuItemsByPizzeriaId(int pizzeriaId)
        {
            var menuItems = await _service.GetAllByPizzeriaId(pizzeriaId);
            return Ok(menuItems);
        }
    }
}
