using Microsoft.AspNetCore.Mvc;
using PizzeriaBL.ServiceInterfaces;
using PizzeriaDAL.Dtos;

namespace Pizzeria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzeriasController : Controller
    {
        private readonly IPizzeriaService _pizzeriaService;

        public PizzeriasController(IPizzeriaService pizzeriaService)
        {
            _pizzeriaService = pizzeriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzeriaDto>>> GetAll()
        {

            IEnumerable<PizzeriaDto> pizzerias = await _pizzeriaService.GetAll();
            return Ok(pizzerias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PizzeriaDto>>> Get(int id)
        {
            var pizzeria = await _pizzeriaService.Get(id);
            return Ok(pizzeria);
        }
    }
}
