using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Context:DbContext
    {
       public DbSet<Admin>Admins { get; set; }
       public DbSet<Billing>Billings { get; set; }
       public DbSet<BillingDetail>BillingDetails { get; set; }
       public DbSet<Category>Categories { get; set; }
       public DbSet<Current>Currents { get; set; }
       public DbSet<Department>Departments { get; set; }
       public DbSet<Employee>Employees { get; set; }
       public DbSet<Expenses>Expenses { get; set; }
       public DbSet<Product>Products { get; set; }
       public DbSet<Transaction>Transactions { get; set; }
       public DbSet<Detail>Details { get; set; }
        public DbSet<ToDo>ToDos { get; set; }
    }
}