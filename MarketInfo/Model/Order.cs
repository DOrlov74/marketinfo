using System.ComponentModel.DataAnnotations.Schema;

namespace MarketInfo.Model
{
  public class Order
  {
    public int Id { get; set; }
    public DateTime? OrderDate { get; set; } = DateTime.UtcNow;
    public string? StoreCity { get; set; }
    public long InvoiceNumber { get; set; }
    [ForeignKey("Company")]
    public long CompanyId { get; set; }
    [ForeignKey("Employer")]
    public long EmployeeId { get; set; }
  }
}
