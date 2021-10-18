using EShop.Repository.Domain;
using EShop.Repository.Interfaces;
using EShop.Repository.Repositories;
using EShop.Service.Interfaces;
using EShop.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Services;
using System;

namespace EShop.Web
{
    public class Startup
    {
        private readonly IHostEnvironment _env;
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration, IHostEnvironment hostingEnvironment)
        {
            _env = hostingEnvironment;
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Scopes
            //Mapping
            services.AddScoped<MappingService, MappingService>();

            //Order
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            //Product
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //ShoppingCart
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            //UserInformationService
            services.AddScoped<IUserInformationService, UserInformationService>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();

            //User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            if (_env.IsDevelopment())
            {
                services.AddDbContext<EShopContext>(options => options
                .UseSqlServer(_config.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging(true));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<EShopContext>(options => options
                .UseSqlServer(_config.GetConnectionString("DefaultConnection") ?? _config.GetConnectionString("DefaultConnection")));
            }

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(2);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "User.Section";
            });

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}