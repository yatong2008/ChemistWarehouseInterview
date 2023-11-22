using PizzeriaDAL.Dtos;

namespace PizzeriaBL.ServiceInterfaces
{
    public interface IPizzeriaService
    {
        Task<IEnumerable<PizzeriaDto>> GetAll();

        Task<PizzeriaDto> Get(int id);
    }
}
