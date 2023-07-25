using MarketInfo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.Design;

namespace MarketInfo.Data
{
  public static class SeedData
  {
    public static void AddCompanyData(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Company>().HasData
        (
          new Company
          {
            Id = 1,
            Name = "Super Mart of the West",
            City = "Bentonville",
            State = "Arkansas",
            Phone = "(800) 555-2797",
            Address = "702 SW 8th Street"
          },
          new Company
          {
            Id = 2,
            Name = "Electronocs Depot",
            City = "Altanta",
            State = "Georgia",
            Phone = "(800) 595-3232"
          },
          new Company
          {
            Id = 3,
            Name = "K&S Music",
            City = "Minneapolis",
            State = "Minnesota",
            Phone = "(612) 304-6073"
          },
          new Company
          {
            Id = 4,
            Name = "Tom's Club",
            City = "Issaquah",
            State = "Washington",
            Phone = "(800) 955-2292"
          },
          new Company
          {
            Id = 5,
            Name = "E-Mart",
            City = "Hoffman Estates",
            State = "Illinois",
            Phone = "(847) 286-2500"
          },
          new Company
          {
            Id = 6,
            Name = "Walters",
            City = "Deerfield",
            State = "Illinois",
            Phone = "(847) 940-2500"
          },
          new Company
          {
            Id = 7,
            Name = "StereoShack",
            City = "Fort Worth",
            State = "Texas",
            Phone = "(817) 820-0741"
          },
          new Company
          {
            Id = 8,
            Name = "Circuit Town",
            City = "Oak Brook",
            State = "Illinois",
            Phone = "(800) 955-2929"
          },
          new Company
          {
            Id = 9,
            Name = "Premier Buy",
            City = "Richfield",
            State = "Minnesota",
            Phone = "(612) 291-1000"
          },
          new Company
          {
            Id = 10,
            Name = "ElectrixMax",
            City = "Naperville",
            State = "Illinois",
            Phone = "(630) 438-7800"
          },
          new Company
          {
            Id = 11,
            Name = "Video Imporium",
            City = "Dallas",
            State = "Texas",
            Phone = "(214) 854-3000"
          },
          new Company
          {
            Id = 12,
            Name = "Screen Shop",
            City = "Mooresville",
            State = "North Carolina",
            Phone = "(800) 445-6937"
          }
        );
      modelBuilder.Entity<Employee>().HasData
        (
          new Employee
          {
            Id = 1,
            FirstName = "John",
            LastName = "Heart",
            Title = "Mr.",
            BirthDate = new DateTime(1964, 3, 16),
            Position = "CEO",
            CompanyId = 1
          },
          new Employee
          {
            Id = 2,
            FirstName = "Olivia",
            LastName = "Peyton",
            Title = "Mrs.",
            BirthDate = new DateTime(1975, 6, 8),
            Position = "Sales Manager",
            CompanyId = 1
          },
          new Employee
          {
            Id = 3,
            FirstName = "Robert",
            LastName = "Reagan",
            Title = "Mr.",
            BirthDate = new DateTime(1968, 8, 20),
            Position = "Sales Analyst",
            CompanyId = 1
          },
          new Employee
          {
            Id = 4,
            FirstName = "Cyntia",
            LastName = "Stanwick",
            Title = "Mrs.",
            BirthDate = new DateTime(1978, 9, 12),
            Position = "Sales Manager",
            CompanyId = 1
          }
        );
      modelBuilder.Entity<Order>().HasData
        (
          new Order
          {
            Id = 1,
            OrderDate = new DateTime(2013, 11, 12),
            StoreCity = "Las Vegas",
            InvoiceNumber = 35703,
            EmployeeId = 1,
            CompanyId = 1
          },
          new Order
          {
            Id = 2,
            OrderDate = new DateTime(2013, 11, 14),
            StoreCity = "Las Vegas",
            InvoiceNumber = 35711,
            EmployeeId = 2,
            CompanyId = 1
          },
          new Order
          {
            Id = 3,
            OrderDate = new DateTime(2013, 11, 18),
            StoreCity = "San Jose",
            InvoiceNumber = 35714,
            EmployeeId = 3,
            CompanyId = 1
          },
          new Order
          {
            Id = 4,
            OrderDate = new DateTime(2013, 11, 22),
            StoreCity = "Denver",
            InvoiceNumber = 35983,
            EmployeeId = 4,
            CompanyId = 1
          },
          new Order
          {
            Id = 5,
            OrderDate = new DateTime(2013, 11, 30),
            StoreCity = "Seatle",
            InvoiceNumber = 36987,
            EmployeeId = 3,
            CompanyId = 1
          },
          new Order
          {
            Id = 6,
            OrderDate = new DateTime(2013, 12, 01),
            StoreCity = "San Jose",
            InvoiceNumber = 38466,
            EmployeeId = 1,
            CompanyId = 1
          }
        );
    }
  }
}
