namespace PizzeriaDAL.Models;
public class Pizza
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<int> ToppingIds { get; set; }
}
