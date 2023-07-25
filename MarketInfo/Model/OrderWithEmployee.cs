using System.ComponentModel.DataAnnotations.Schema;

namespace MarketInfo.Model
{
  public class OrderWithEmployee
  {
    public int Id { get; set; }
    public long InvoiceNumber { get; set; }
    public long CompanyId { get; set; }
    public string? EmployeeFirstName { get; set; }
    public string? EmployeeLastName { get; set; }
  }
}
