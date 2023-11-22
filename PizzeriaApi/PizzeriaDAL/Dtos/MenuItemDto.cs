namespace PizzeriaDAL.Dtos;
public class MenuItemDto
{
    public int Id { get; set; }
    public int PizzeriaId { get; set; }
    public int PizzaId { get; set; }
    public decimal Price { get; set; }
    public string PizzaName { get; set; }
    public List<ToppingDto> Toppings { get; set; }
}
