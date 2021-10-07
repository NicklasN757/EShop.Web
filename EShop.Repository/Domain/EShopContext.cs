using EShop.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Domain
{
    public class EShopContext : DbContext
    {
        public EShopContext() { }

        public EShopContext(DbContextOptions<EShopContext> optionsBuilder) : base(optionsBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EShopDb; Trusted_Connection = True; ")
            .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Product table
            //Keys And Relations
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

            //Property
            modelBuilder.Entity<Product>().Property(p => p.InStock).HasDefaultValue(true);

            //Data
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Assassin´s Creed Valhalla", Stock = 200, Price = 59.95 },
                new Product { ProductId = 2, Name = "Anno 1800", Stock = 150, Price = 45.00 },
                new Product { ProductId = 3, Name = "Watch Dogs: Legion", Stock = 100, Price = 50.00 },
                new Product { ProductId = 4, Name = "Assassin´s Creed Rogue", Stock = 15, Price = 11.95},
                new Product { ProductId = 5, Name = "Tom Clancy´s Rainbow Six Siege", Stock = 1050, Price = 24.95}
                );
            #endregion

            #region User table
            //Keys And Relations
            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            //Property
            modelBuilder.Entity<User>().Property(u => u.IsAdmin).HasDefaultValue(false);

            //Data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "NicklasN757", Pin = 7571, IsAdmin = true },
                new User { UserId = 2, Username = "PinkMan42", Pin = 4242},
                new User { UserId = 3, Username = "YoloSwagMC", Pin = 1234}
                );
            #endregion

            #region ShoppingCart table
            //Keys And Relations
            modelBuilder.Entity<ShoppingCart>().HasKey(sc => sc.ShoppingCartId);
            modelBuilder.Entity<ShoppingCart>().HasMany(sc => sc.Products).WithOne(p => p.ShoppingCart);
            modelBuilder.Entity<ShoppingCart>().HasOne(sc => sc.User).WithMany(u => u.ShoppingCarts).HasForeignKey(sc => sc.FK_UserId).OnDelete(DeleteBehavior.ClientSetNull);

            //Property
            modelBuilder.Entity<ShoppingCart>().Property(sc => sc.IsFinished).HasDefaultValue(false);

            //Data
            modelBuilder.Entity<ShoppingCart>().HasData(
                new ShoppingCart { ShoppingCartId = 1, FK_Product = 1, FK_UserId = 1, TotalPrice = 59.50, IsFinished = true }, 
                new ShoppingCart { ShoppingCartId = 2, FK_Product = 2, FK_UserId = 1, TotalPrice = 45.00 }
                );
            #endregion

            #region UserInformation table
            //Keys And Relations
            modelBuilder.Entity<UserInformation>().HasKey(ui => ui.UserId);
            modelBuilder.Entity<UserInformation>().HasOne(ui => ui.User).WithOne(u => u.UserInformation).HasForeignKey<UserInformation>(ui => ui.UserId).OnDelete(DeleteBehavior.ClientCascade);

            //Property

            //Data
            modelBuilder.Entity<UserInformation>().HasData(
                new UserInformation { UserId = 1, FullName = "Nicklas M Nielsen", City = "Sønderborg", Adress = "Nørre Havnegade 40", EMail = "1n2n3n4n5n@hotmail.dk" },
                new UserInformation { UserId = 2, FullName = "Sven Petersen", City = "København", Adress = "Carl Jacobsens Vej 25", EMail = "CarlJacobsensVej@hotmail.com" },
                new UserInformation { UserId = 3, FullName = "John Jørgensen", City = "København", Adress = "Høffdingsvej 14", EMail = "KildeSkolen@hotmail.com" }
                );
            #endregion

            #region Order table
            //Keys And Relations
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>().HasOne(o => o.ShoppingCart).WithOne(sc => sc.Order).HasForeignKey<Order>(O => O.FK_ShooppingCartId).OnDelete(DeleteBehavior.ClientCascade);

            //Property
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasDefaultValueSql("GetDate()");

            //Data
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, FK_ShooppingCartId = 1, FK_UserInformation = 1, OrderDate = DateTime.Now }
                );
            #endregion
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
    }
}