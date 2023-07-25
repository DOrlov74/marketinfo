using System.ComponentModel.DataAnnotations;

namespace MarketInfo.Model
{
  public class Company
  {
    public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
  }
}
