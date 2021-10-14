﻿// <auto-generated />
using System;
using EShop.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EShop.Repository.Migrations
{
    [DbContext(typeof(EShopContext))]
    partial class EShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EShop.Repository.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FK_ShooppingCartId")
                        .HasColumnType("int");

                    b.Property<int>("FK_UserInformation")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int?>("UserInformationUserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("FK_ShooppingCartId")
                        .IsUnique();

                    b.HasIndex("UserInformationUserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            FK_ShooppingCartId = 1,
                            FK_UserInformation = 1,
                            OrderDate = new DateTime(2021, 10, 14, 11, 13, 5, 400, DateTimeKind.Local).AddTicks(7325)
                        });
                });

            modelBuilder.Entity("EShop.Repository.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "Become Eivor, a legendary Viking raider on a quest for glory. Explore England's Dark Ages as you raid your enemies, grow your settlement, and build your political power.",
                            ImgUrl = "product_1.jpg",
                            InStock = false,
                            Name = "Assassin´s Creed Valhalla",
                            Price = 59.950000000000003,
                            Stock = 200
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Experience one of the most exciting and fast-changing periods of all time. Discover new technologies, continents, and societies. Build a new world in your image! All the ingredients are gathered for a memorable Anno experience. Travel throughout the world during the Industrial Revolution to write your own story!",
                            ImgUrl = "product_2.jpg",
                            InStock = false,
                            Name = "Anno 1800",
                            Price = 45.0,
                            Stock = 150
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Build a resistance from virtually anyone you see as you hack, infiltrate, and fight to take back a near-future London that is facing its downfall.",
                            ImgUrl = "product_3.jpg",
                            InStock = false,
                            Name = "Watch Dogs: Legion",
                            Price = 50.0,
                            Stock = 100
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "18th century, North America. Amidst the chaos and violence of the French and Indian War, Shay Patrick Cormac, a fearless young member of the Brotherhood of Assassin’s, undergoes a dark transformation that will forever shape the future of the American colonies.",
                            ImgUrl = "product_4.jpg",
                            InStock = false,
                            Name = "Assassin´s Creed Rogue",
                            Price = 11.949999999999999,
                            Stock = 15
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "Squad up and breach in to explosive 5v5 PVP action. Tom Clancy's Rainbow Six Siege features a huge roster of specialized operators, each with game-changing gadgets to help you lead your team to victory.",
                            ImgUrl = "product_5.jpg",
                            InStock = false,
                            Name = "Tom Clancy´s Rainbow Six Siege",
                            Price = 24.949999999999999,
                            Stock = 1050
                        });
                });

            modelBuilder.Entity("EShop.Repository.Entities.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FK_Product")
                        .HasColumnType("int");

                    b.Property<int>("FK_UserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinished")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("FK_UserId");

                    b.ToTable("ShoppingCarts");

                    b.HasData(
                        new
                        {
                            ShoppingCartId = 1,
                            FK_Product = 1,
                            FK_UserId = 1,
                            IsFinished = true,
                            TotalPrice = 59.5
                        },
                        new
                        {
                            ShoppingCartId = 2,
                            FK_Product = 2,
                            FK_UserId = 1,
                            IsFinished = false,
                            TotalPrice = 45.0
                        });
                });

            modelBuilder.Entity("EShop.Repository.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            IsAdmin = true,
                            Pin = 7571,
                            Username = "NicklasN757"
                        },
                        new
                        {
                            UserId = 2,
                            IsAdmin = false,
                            Pin = 4242,
                            Username = "PinkMan42"
                        },
                        new
                        {
                            UserId = 3,
                            IsAdmin = false,
                            Pin = 1234,
                            Username = "YoloSwagMC"
                        });
                });

            modelBuilder.Entity("EShop.Repository.Entities.UserInformation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserInformations");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Adress = "Nørre Havnegade 40",
                            City = "Sønderborg",
                            EMail = "1n2n3n4n5n@hotmail.dk",
                            FullName = "Nicklas M Nielsen"
                        },
                        new
                        {
                            UserId = 2,
                            Adress = "Carl Jacobsens Vej 25",
                            City = "København",
                            EMail = "CarlJacobsensVej@hotmail.com",
                            FullName = "Sven Petersen"
                        },
                        new
                        {
                            UserId = 3,
                            Adress = "Høffdingsvej 14",
                            City = "København",
                            EMail = "KildeSkolen@hotmail.com",
                            FullName = "John Jørgensen"
                        });
                });

            modelBuilder.Entity("EShop.Repository.Entities.Order", b =>
                {
                    b.HasOne("EShop.Repository.Entities.ShoppingCart", "ShoppingCart")
                        .WithOne("Order")
                        .HasForeignKey("EShop.Repository.Entities.Order", "FK_ShooppingCartId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("EShop.Repository.Entities.UserInformation", "UserInformation")
                        .WithMany("Orders")
                        .HasForeignKey("UserInformationUserId");

                    b.Navigation("ShoppingCart");

                    b.Navigation("UserInformation");
                });

            modelBuilder.Entity("EShop.Repository.Entities.Product", b =>
                {
                    b.HasOne("EShop.Repository.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany("Products")
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("EShop.Repository.Entities.ShoppingCart", b =>
                {
                    b.HasOne("EShop.Repository.Entities.User", "User")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("FK_UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EShop.Repository.Entities.UserInformation", b =>
                {
                    b.HasOne("EShop.Repository.Entities.User", "User")
                        .WithOne("UserInformation")
                        .HasForeignKey("EShop.Repository.Entities.UserInformation", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EShop.Repository.Entities.ShoppingCart", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("EShop.Repository.Entities.User", b =>
                {
                    b.Navigation("ShoppingCarts");

                    b.Navigation("UserInformation");
                });

            modelBuilder.Entity("EShop.Repository.Entities.UserInformation", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
