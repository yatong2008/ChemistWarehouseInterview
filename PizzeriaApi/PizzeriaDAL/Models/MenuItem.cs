namespace PizzeriaDAL.Models;
public class MenuItem
{
    public int Id { get; set; }

    public int PizzeriaId { get; set; }

    public int PizzaId { get; set; }
    public decimal Price { get; set; }
}
