using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;

namespace WebUI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddDbContext<Context>(x => x.UseSqlServer("server=MSI\\SQLEXPRESS;database=dbTeknoroma;Trusted_Connection=True;TrustServerCertificate=true"));

			services.AddIdentity<AppUser, AppRole>(x =>
			{
				x.Password.RequireDigit = false;
				x.Password.RequireLowercase = false;
				x.Password.RequiredLength = 5;
				x.Password.RequireNonAlphanumeric = false;
				x.Password.RequireUppercase = false;

			}).AddEntityFrameworkStores<Context>();

			services.AddScoped<ICategoryDal, CategoryDal>();
			services.AddScoped<ICustomerDal, CustomerDal>();
			services.AddScoped<IOrderDetailDal, OrderDetailDal>();
			services.AddScoped<IOrderDal, OrderDal>();
			services.AddScoped<IProductDal, ProductDal>();
			services.AddScoped<ISubCategoryDal, SubCategoryDal>();
			services.AddScoped<ISupplierDal, SupplierDal>();
			services.AddScoped<IAppUserDal, AppUserDal>();
			services.AddScoped<IIssueDal, IssueDal>();
			services.AddScoped<IExpenseDal, ExpenseDal>();
			services.AddScoped<IEmployeePaymentDal, EmployeePaymentDal>();
			services.AddScoped<ISupplierExpenseDal, SupplierExpenseDal>();
			services.AddScoped<AppUserManager>();
			services.AddScoped<CategoryManager>();
			services.AddScoped<CustomerManager>();
			services.AddScoped<EmployeePaymentManager>();
			services.AddScoped<ExpenseManager>();
			services.AddScoped<IssueManager>();
			services.AddScoped<OrderDetailManager>();
			services.AddScoped<OrderManager>();
			services.AddScoped<ProductManager>();
			services.AddScoped<SubCategoryManager>();
			services.AddScoped<SupplierManager>();
			services.AddScoped<SupplierExpenseManager>();


		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseExceptionHandler("/StatusPage/Error");

			app.UseStatusCodePagesWithReExecute("/StatusPage/Status", "?code={0}");

			app.UseHsts();

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Login}/{action=Login}/{id?}");

			});

		}
	}
}
