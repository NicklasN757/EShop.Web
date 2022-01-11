using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TotalStock = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "PriceOffers",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    NewPrice = table.Column<double>(type: "float", nullable: false),
                    OfferReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    DateEnding = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceOffers", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_PriceOffers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    ProductTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Product = table.Column<int>(type: "int", nullable: false),
                    FK_Tag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => x.ProductTagId);
                    table.ForeignKey(
                        name: "FK_ProductTag_Products_FK_Product",
                        column: x => x.FK_Product,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_Tags_FK_Tag",
                        column: x => x.FK_Tag,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserInformations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartProducts",
                columns: table => new
                {
                    ShoppingCartProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ShoppingCart = table.Column<int>(type: "int", nullable: false),
                    FK_Product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartProducts", x => x.ShoppingCartProductId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_Products_FK_Product",
                        column: x => x.FK_Product,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_ShoppingCarts_FK_ShoppingCart",
                        column: x => x.FK_ShoppingCart,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    TotalOrderPrice = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    FK_UserInformationId = table.Column<int>(type: "int", nullable: false),
                    FK_UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_UserInformations_FK_UserInformationId",
                        column: x => x.FK_UserInformationId,
                        principalTable: "UserInformations",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Orders_Users_FK_UserId",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Order = table.Column<int>(type: "int", nullable: false),
                    FK_Product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_FK_Order",
                        column: x => x.FK_Order,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_FK_Product",
                        column: x => x.FK_Product,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ImgUrl", "Name", "Price", "TotalStock" },
                values: new object[,]
                {
                    { 1, "Become Eivor, a legendary Viking raider on a quest for glory. Explore England's Dark Ages as you raid your enemies, grow your settlement, and build your political power.", "product_1.jpg", "Assassin´s Creed Valhalla", 59.950000000000003, 200 },
                    { 2, "Experience one of the most exciting and fast-changing periods of all time. Discover new technologies, continents, and societies. Build a new world in your image! All the ingredients are gathered for a memorable Anno experience. Travel throughout the world during the Industrial Revolution to write your own story!", "product_2.jpg", "Anno 1800", 45.0, 150 },
                    { 3, "Build a resistance from virtually anyone you see as you hack, infiltrate, and fight to take back a near-future London that is facing its downfall.", "product_3.jpg", "Watch Dogs: Legion", 50.0, 100 },
                    { 4, "18th century, North America. Amidst the chaos and violence of the French and Indian War, Shay Patrick Cormac, a fearless young member of the Brotherhood of Assassin’s, undergoes a dark transformation that will forever shape the future of the American colonies.", "product_4.jpg", "Assassin´s Creed Rogue", 11.949999999999999, 15 },
                    { 5, "Squad up and breach in to explosive 5v5 PVP action. Tom Clancy's Rainbow Six Siege features a huge roster of specialized operators, each with game-changing gadgets to help you lead your team to victory.", "product_5.jpg", "Tom Clancy´s Rainbow Six Siege", 24.949999999999999, 1050 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Action-adventure" },
                    { 3, "Adventure" },
                    { 4, "Role-playing" },
                    { 5, "Simulation" },
                    { 6, "Strategy" },
                    { 7, "Sports" },
                    { 8, "MMO" },
                    { 9, "Sandbox" },
                    { 10, "Open world" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsAdmin", "Pin", "Username" },
                values: new object[] { 1, true, 7571, "NicklasN757" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Pin", "Username" },
                values: new object[,]
                {
                    { 2, 4242, "PinkMan42" },
                    { 3, 1234, "YoloSwagMC" }
                });

            migrationBuilder.InsertData(
                table: "PriceOffers",
                columns: new[] { "ProductId", "DateEnding", "DateStarted", "NewPrice", "OfferReason" },
                values: new object[] { 3, new DateTime(2023, 1, 11, 8, 44, 3, 897, DateTimeKind.Local).AddTicks(3006), new DateTime(2022, 1, 11, 8, 44, 3, 897, DateTimeKind.Local).AddTicks(2967), 24.550000000000001, "Too many bugs ingame" });

            migrationBuilder.InsertData(
                table: "ProductTag",
                columns: new[] { "ProductTagId", "FK_Product", "FK_Tag" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 9 },
                    { 3, 2, 10 },
                    { 4, 3, 10 },
                    { 5, 4, 2 },
                    { 6, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                column: "ShoppingCartId",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "UserId", "Adress", "City", "EMail", "FullName" },
                values: new object[,]
                {
                    { 1, "Nørre Havnegade 40", "Sønderborg", "1n2n3n4n5n@hotmail.dk", "Nicklas M Nielsen" },
                    { 2, "Carl Jacobsens Vej 25", "København", "CarlJacobsensVej@hotmail.com", "Sven Petersen" },
                    { 3, "Høffdingsvej 14", "København", "KildeSkolen@hotmail.com", "John Jørgensen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_FK_Order",
                table: "OrderProducts",
                column: "FK_Order");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_FK_Product",
                table: "OrderProducts",
                column: "FK_Product");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FK_UserId",
                table: "Orders",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FK_UserInformationId",
                table: "Orders",
                column: "FK_UserInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_FK_Product",
                table: "ProductTag",
                column: "FK_Product");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_FK_Tag",
                table: "ProductTag",
                column: "FK_Tag");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_FK_Product",
                table: "ShoppingCartProducts",
                column: "FK_Product");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_FK_ShoppingCart",
                table: "ShoppingCartProducts",
                column: "FK_ShoppingCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "PriceOffers");

            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.DropTable(
                name: "ShoppingCartProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "UserInformations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
