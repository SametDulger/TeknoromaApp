using DataAccessLayer.Mapping;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Context : IdentityDbContext<AppUser, AppRole, Guid>
    {
        
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
       

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<EmployeePayment> EmployeePayments { get; set; }
        public DbSet<SupplierExpense> SupplierExpenses { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductOrderMap());

            base.OnModelCreating(builder);
        }


    }
}
