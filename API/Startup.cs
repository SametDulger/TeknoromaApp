using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
