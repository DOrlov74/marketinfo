using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketInfo.Data;
using MarketInfo.Model;
using System.ComponentModel.Design;

namespace MarketInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CompanyContext _context;

        public OrdersController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Orders/5
        [HttpGet("{companyId}", Name = "GetOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(long companyId)
        {
          var companyOrders = await _context.Orders.Where(o => o.CompanyId == companyId).ToListAsync();
          if (companyOrders.Count == 0)
          {
              return NotFound();
          }
          return companyOrders;
        }

        // GET: api/Orders/5/5
        [HttpGet("{companyId}/{id}", Name = "GetOrder")]
        public async Task<ActionResult<Order>> GetOrder(long companyId, long id)
        {
            var companyOrders = await _context.Orders.Where(o => o.CompanyId == companyId).ToListAsync();
            if (companyOrders.Count == 0)
            {
              return NotFound();
            }
            var order = companyOrders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // GET: api/Orders/5/witheployees
        [HttpGet("{companyId}/withemployees", Name = "GetOrdersWithEmployees")]
    public async Task<ActionResult<IEnumerable<OrderWithEmployee>>> GetOrdersWithEmployees(long companyId)
    {
      var companyOrders = await _context.Orders.Where(o => o.CompanyId == companyId).ToListAsync();
      var companyEmployees = await _context.Employees.Where(e => e.CompanyId == companyId).ToListAsync();
      if (companyOrders.Count == 0)
      {
        return NotFound();
      }
      List<OrderWithEmployee> joint_data = companyOrders.Join(companyEmployees,
            o => o.EmployeeId,
            e => e.Id,
            (o, e) => new OrderWithEmployee
            {
              Id = o.Id,
              InvoiceNumber = o.InvoiceNumber,
              CompanyId = o.CompanyId,
              EmployeeFirstName = e.FirstName, 
              EmployeeLastName = e.LastName
            }).ToList();
      return joint_data;
    }

  }
}
