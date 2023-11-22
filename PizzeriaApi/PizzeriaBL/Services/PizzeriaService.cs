using PizzeriaBL.ServiceInterfaces;
using PizzeriaDAL.Dtos;
using PizzeriaDAL.RepositoryInterfaces;

namespace PizzeriaBL.Services
{
    public class PizzeriaService : IPizzeriaService
    {
        private readonly IPizzeriaRepository _pizzeriaRepository;

        public PizzeriaService(IPizzeriaRepository pizzeriaService)
        {
            _pizzeriaRepository = pizzeriaService;
        }
        public async Task<IEnumerable<PizzeriaDto>> GetAll()
        {
            var pizzeriaDtos = await _pizzeriaRepository.GetAll();

            var results = pizzeriaDtos.Select(r => new PizzeriaDto
            {
                Id = r.Id,
                Name = r.Name
            });

            return results;
        }

        public async Task<PizzeriaDto> Get(int id)
        {
            var pizzeria = await _pizzeriaRepository.GetById(id);
            return new PizzeriaDto
            {
                Id = pizzeria.Id,
                Name = pizzeria.Name
            };
        }
    }
}
