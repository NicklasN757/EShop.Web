using EShop.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EShop.Repository.Domain
{
    public class EShopContext : DbContext
    {
        public EShopContext() { }

        public EShopContext(DbContextOptions<EShopContext> optionsBuilder) : base(optionsBuilder) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EShopDb; Trusted_Connection = True; ")
        //    .EnableSensitiveDataLogging(true);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Product table
            //Keys And Relations
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

            //Property
            modelBuilder.Entity<Product>().Property(p => p.InStock).HasDefaultValue(true);

            //Data
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Assassin´s Creed Valhalla", Stock = 200, Price = 59.95, ImgUrl = "product_1.jpg", Description = "Become Eivor, a legendary Viking raider on a quest for glory. Explore England's Dark Ages as you raid your enemies, grow your settlement, and build your political power." },
                new Product { ProductId = 2, Name = "Anno 1800", Stock = 150, Price = 45.00, ImgUrl = "product_2.jpg", Description = "Experience one of the most exciting and fast-changing periods of all time. Discover new technologies, continents, and societies. Build a new world in your image! All the ingredients are gathered for a memorable Anno experience. Travel throughout the world during the Industrial Revolution to write your own story!" },
                new Product { ProductId = 3, Name = "Watch Dogs: Legion", Stock = 100, Price = 50.00, ImgUrl = "product_3.jpg", Description = "Build a resistance from virtually anyone you see as you hack, infiltrate, and fight to take back a near-future London that is facing its downfall." },
                new Product { ProductId = 4, Name = "Assassin´s Creed Rogue", Stock = 15, Price = 11.95, ImgUrl = "product_4.jpg", Description = "18th century, North America. Amidst the chaos and violence of the French and Indian War, Shay Patrick Cormac, a fearless young member of the Brotherhood of Assassin’s, undergoes a dark transformation that will forever shape the future of the American colonies." },
                new Product { ProductId = 5, Name = "Tom Clancy´s Rainbow Six Siege", Stock = 1050, Price = 24.95, ImgUrl = "product_5.jpg", Description = "Squad up and breach in to explosive 5v5 PVP action. Tom Clancy's Rainbow Six Siege features a huge roster of specialized operators, each with game-changing gadgets to help you lead your team to victory." }
                );
            #endregion

            #region PriceOffer
            //Keys And Relations
            modelBuilder.Entity<PriceOffer>().HasKey(po => po.ProductId);
            modelBuilder.Entity<PriceOffer>().HasOne(po => po.Product).WithOne(po => po.PriceOffer).HasForeignKey<PriceOffer>(po => po.ProductId).OnDelete(DeleteBehavior.Cascade);

            //Property
            modelBuilder.Entity<PriceOffer>().Property(po => po.DateStarted).HasDefaultValueSql("GetDate()");

            //Data
            modelBuilder.Entity<PriceOffer>().HasData(
                new PriceOffer { ProductId = 3, NewPrice = 24.55, OfferReason = "Alt for mange fejl", DateStarted = DateTime.Now, DateEnding = DateTime.Now.AddDays(365) }
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
            modelBuilder.Entity<ShoppingCart>().HasOne(sc => sc.User).WithMany(u => u.ShoppingCarts).HasForeignKey(sc => sc.FK_UserId).OnDelete(DeleteBehavior.SetNull);

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
            modelBuilder.Entity<UserInformation>().HasOne(ui => ui.User).WithOne(u => u.UserInformation).HasForeignKey<UserInformation>(ui => ui.UserId).OnDelete(DeleteBehavior.Cascade);

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
            modelBuilder.Entity<Order>().HasOne(o => o.ShoppingCart).WithOne(sc => sc.Order).HasForeignKey<Order>(O => O.FK_ShooppingCartId).OnDelete(DeleteBehavior.Cascade);

            //Property
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasDefaultValueSql("GetDate()");

            //Data
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, FK_ShooppingCartId = 1, FK_UserInformation = 1, OrderDate = DateTime.Now }
                );
            #endregion
        }
        #region Table Creations
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        #endregion
    }
}