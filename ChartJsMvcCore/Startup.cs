using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChartJsMvcCore.Entity;
using System;

namespace ChartJsMvcCore
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
            services.AddControllersWithViews();
            services.AddMvc(x => x.EnableEndpointRouting = false);

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Conn"),
               sqlServerOptionsAction: sqlOptions => sqlOptions.EnableRetryOnFailure()),
               ServiceLifetime.Transient
           );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var ctx = serviceProvider.GetService<ApplicationDbContext>();
            SeedSampleData(ctx);


            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void SeedSampleData(ApplicationDbContext context)
        {

          //  var product = new List<TblProduct> {
          //  new TblProduct
          //  {
          //      ProductName = "Test 1",
          //      Qty=100,
          //      Price = 100.00m,
          //      ProductSun = "PRO123",
          //      WholeSalePrice = 80.00m,
          //      OnHandQty = 80,
          //      Status="In Stock"
          //  },

          //  new TblProduct
          //  {
          //      ProductName = "Test 2",
          //      Qty=80,
          //      Price = 120.00m,
          //      ProductSun = "PRO223",
          //      WholeSalePrice = 100.00m,
          //      OnHandQty = 70,
          //      Status="In Stock"
          //  },

          //  new TblProduct
          //  {
          //      ProductName = "Test 3",
          //      Qty=120,
          //      Price = 150.00m,
          //      ProductSun = "PRO789",
          //      WholeSalePrice = 80.00m,
          //      OnHandQty = 0,
          //      Status="Out Of Stock"
          //  },
          //   new TblProduct
          //  {
          //      ProductName = "Test 4",
          //      Qty=150,
          //      Price = 100.00m,
          //      ProductSun = "PRO456",
          //      WholeSalePrice = 80.00m,
          //      OnHandQty = 80,
          //      Status="In Stock"
          //   },
          //   new TblProduct
          //  {
          //      ProductName = "Test 5",
          //      Qty=80,
          //      Price = 180.00m,
          //      ProductSun = "PRO456",
          //      WholeSalePrice = 80.00m,
          //      OnHandQty = 50,
          //      Status="In Stock"
          //   },
          //      new TblProduct
          //      {
          //          ProductName = "Test 6",
          //          Qty = 82,
          //          Price = 185.00m,
          //          ProductSun = "XYZ125",
          //          WholeSalePrice = 80.00m,
          //          OnHandQty = 20,
          //          Status = "In Stock"
          //      },

          //  new TblProduct
          //  {
          //      ProductName = "Test 7",
          //      Qty = 50,
          //      Price = 10.00m,
          //      ProductSun = "PRO223",
          //      WholeSalePrice = 5.00m,
          //      OnHandQty = 2,
          //      Status = "In Stock"
          //  },

          //  new TblProduct
          //  {
          //      ProductName = "Test 8",
          //      Qty = 120,
          //      Price = 150.00m,
          //      ProductSun = "PRO779",
          //      WholeSalePrice = 80.00m,
          //      OnHandQty = 0,
          //      Status = "Out Of Stock"
          //  }
          //};

          //  context.AddRange(product);
          //  context.SaveChanges();

        }

    }
}
