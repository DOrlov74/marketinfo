using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketInfo.Model
{
  public class Employee
  {
    public long Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    public string? Title { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Position { get; set; }
    [ForeignKey("Company")]
    public long CompanyId { get; set; }
  }
}
