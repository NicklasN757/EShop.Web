using EShop.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EShop.Repository.Domain
{
    public class EShopContext : DbContext
    {
        public EShopContext() { }

        public EShopContext(DbContextOptions<EShopContext> optionsBuilder) : base(optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Order table
            //Keys And Relations
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.FK_UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(o => o.UserInformation).WithMany(ui => ui.Orders).HasForeignKey(o => o.FK_UserInformationId).OnDelete(DeleteBehavior.NoAction);

            //Property
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Order>().Property(o => o.TotalOrderPrice).HasDefaultValue(0.0);
            //Data
            #endregion

            #region OrderProduct table
            //Keys And Relations
            modelBuilder.Entity<OrderProduct>().HasKey(op => op.OrderProductId);
            modelBuilder.Entity<OrderProduct>().HasOne(op => op.Order).WithMany(o => o.OrderProducts).HasForeignKey(op => op.FK_Order).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderProduct>().HasOne(op => op.Product).WithMany(p => p.OrderProducts).HasForeignKey(op => op.FK_Product).OnDelete(DeleteBehavior.Cascade);

            //Property

            //Data
            #endregion

            #region PriceOffer
            //Keys And Relations
            modelBuilder.Entity<PriceOffer>().HasKey(po => po.ProductId);
            modelBuilder.Entity<PriceOffer>().HasOne(po => po.Product).WithOne(po => po.PriceOffer).HasForeignKey<PriceOffer>(po => po.ProductId).OnDelete(DeleteBehavior.Cascade);

            //Property
            modelBuilder.Entity<PriceOffer>().Property(po => po.DateStarted).HasDefaultValueSql("GetDate()");

            //Data
            modelBuilder.Entity<PriceOffer>().HasData(
                new PriceOffer { ProductId = 3, NewPrice = 24.55, OfferReason = "Too many bugs ingame", DateStarted = DateTime.Now, DateEnding = DateTime.Now.AddDays(365) }
                );
            #endregion

            #region Product table
            //Keys And Relations
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

            //Property
            modelBuilder.Entity<Product>().Property(p => p.InStock).HasDefaultValue(true);
            modelBuilder.Entity<Product>().Property(p => p.IsDeleted).HasDefaultValue(false);

            //Data
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Assassin´s Creed Valhalla", TotalStock = 200, Price = 59.95, ImgUrl = "product_1.jpg", Description = "Become Eivor, a legendary Viking raider on a quest for glory. Explore England's Dark Ages as you raid your enemies, grow your settlement, and build your political power." },
                new Product { ProductId = 2, Name = "Anno 1800", TotalStock = 150, Price = 45.00, ImgUrl = "product_2.jpg", Description = "Experience one of the most exciting and fast-changing periods of all time. Discover new technologies, continents, and societies. Build a new world in your image! All the ingredients are gathered for a memorable Anno experience. Travel throughout the world during the Industrial Revolution to write your own story!" },
                new Product { ProductId = 3, Name = "Watch Dogs: Legion", TotalStock = 100, Price = 50.00, ImgUrl = "product_3.jpg", Description = "Build a resistance from virtually anyone you see as you hack, infiltrate, and fight to take back a near-future London that is facing its downfall." },
                new Product { ProductId = 4, Name = "Assassin´s Creed Rogue", TotalStock = 15, Price = 11.95, ImgUrl = "product_4.jpg", Description = "18th century, North America. Amidst the chaos and violence of the French and Indian War, Shay Patrick Cormac, a fearless young member of the Brotherhood of Assassin’s, undergoes a dark transformation that will forever shape the future of the American colonies." },
                new Product { ProductId = 5, Name = "Tom Clancy´s Rainbow Six Siege", TotalStock = 1050, Price = 24.95, ImgUrl = "product_5.jpg", Description = "Squad up and breach in to explosive 5v5 PVP action. Tom Clancy's Rainbow Six Siege features a huge roster of specialized operators, each with game-changing gadgets to help you lead your team to victory." }
                );
            #endregion

            #region ProductTag table
            //Keys And Relations
            modelBuilder.Entity<ProductTag>().HasKey(pt => pt.ProductTagId);
            modelBuilder.Entity<ProductTag>().HasOne(pt => pt.Product).WithMany(pt => pt.ProductTags).HasForeignKey(pt => pt.FK_Product).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductTag>().HasOne(pt => pt.Tag).WithMany(pt => pt.ProductsTags).HasForeignKey(pt => pt.FK_Tag).OnDelete(DeleteBehavior.Cascade);

            //Property

            //Data
            modelBuilder.Entity<ProductTag>().HasData(
                new ProductTag { ProductTagId = 1, FK_Product = 1, FK_Tag = 2},
                new ProductTag { ProductTagId = 2, FK_Product = 2, FK_Tag = 9},
                new ProductTag { ProductTagId = 3, FK_Product = 2, FK_Tag = 10},
                new ProductTag { ProductTagId = 4, FK_Product = 3, FK_Tag = 10},
                new ProductTag { ProductTagId = 5, FK_Product = 4, FK_Tag = 2},
                new ProductTag { ProductTagId = 6, FK_Product = 5, FK_Tag = 1}
                );
            #endregion

            #region ShoppingCart table
            //Keys And Relations
            modelBuilder.Entity<ShoppingCart>().HasKey(sc => sc.ShoppingCartId);
            modelBuilder.Entity<ShoppingCart>().HasOne(sc => sc.User).WithOne(u => u.ShoppingCart).HasForeignKey<ShoppingCart>(sc => sc.ShoppingCartId).OnDelete(DeleteBehavior.Cascade);

            //Property
            modelBuilder.Entity<ShoppingCart>().Property(sc => sc.TotalPrice).HasDefaultValue(0.0);

            //Data
            modelBuilder.Entity<ShoppingCart>().HasData(
                new ShoppingCart { ShoppingCartId = 1 }, 
                new ShoppingCart { ShoppingCartId = 2 },
                new ShoppingCart { ShoppingCartId = 3 }
                );
            #endregion

            #region ShoppingCartProduct table
            //Keys And Relations
            modelBuilder.Entity<ShoppingCartProduct>().HasKey(scp => scp.ShoppingCartProductId);
            modelBuilder.Entity<ShoppingCartProduct>().HasOne(scp => scp.ShoppingCart).WithMany(sc => sc.ShoppingCartProducts).HasForeignKey(scp => scp.FK_ShoppingCart).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ShoppingCartProduct>().HasOne(scp => scp.Product).WithMany(p => p.ShoppingCartProducts).HasForeignKey(scp => scp.FK_Product).OnDelete(DeleteBehavior.Cascade);

            //Property

            //Data
            #endregion

            #region Tag table
            //Keys And Relations
            modelBuilder.Entity<Tag>().HasKey(t => t.TagId);

            //Property

            //Data
            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, TagName = "Action" },
                new Tag { TagId = 2, TagName = "Action-adventure" },
                new Tag { TagId = 3, TagName = "Adventure" },
                new Tag { TagId = 4, TagName = "Role-playing" },
                new Tag { TagId = 5, TagName = "Simulation" },
                new Tag { TagId = 6, TagName = "Strategy" },
                new Tag { TagId = 7, TagName = "Sports" },
                new Tag { TagId = 8, TagName = "MMO" },
                new Tag { TagId = 9, TagName = "Sandbox" },
                new Tag { TagId = 10, TagName = "Open world" }
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
                new User { UserId = 2, Username = "PinkMan42", Pin = 4242 },
                new User { UserId = 3, Username = "YoloSwagMC", Pin = 1234 }
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
        }
        #region Table Creations
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        #endregion
    }
}