namespace PizzeriaDAL.Dtos
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<int> Toppings { get; set; }
    }
}
