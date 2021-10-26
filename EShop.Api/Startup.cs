using EShop.Repository.Domain;
using EShop.Repository.Interfaces;
using EShop.Repository.Repositories;
using EShop.Service.Interfaces;
using EShop.Service.Services;
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
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Api
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

            services.AddControllers().AddXmlSerializerFormatters();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EShop.Api", Version = "v1" });
            });

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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EShop.Api v1"));
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
