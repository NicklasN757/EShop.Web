using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FK_UserId = table.Column<int>(type: "int", nullable: false),
                    FK_Product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_FK_UserId",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    FK_ShooppingCartId = table.Column<int>(type: "int", nullable: false),
                    FK_UserInformation = table.Column<int>(type: "int", nullable: false),
                    UserInformationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_ShoppingCarts_FK_ShooppingCartId",
                        column: x => x.FK_ShooppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_UserInformations_UserInformationUserId",
                        column: x => x.UserInformationUserId,
                        principalTable: "UserInformations",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ImgUrl", "Name", "Price", "ShoppingCartId", "Stock" },
                values: new object[,]
                {
                    { 1, "Become Eivor, a legendary Viking raider on a quest for glory. Explore England's Dark Ages as you raid your enemies, grow your settlement, and build your political power.", "product_1.jpg", "Assassin´s Creed Valhalla", 59.950000000000003, null, 200 },
                    { 2, "Experience one of the most exciting and fast-changing periods of all time. Discover new technologies, continents, and societies. Build a new world in your image! All the ingredients are gathered for a memorable Anno experience. Travel throughout the world during the Industrial Revolution to write your own story!", "product_2.jpg", "Anno 1800", 45.0, null, 150 },
                    { 3, "Build a resistance from virtually anyone you see as you hack, infiltrate, and fight to take back a near-future London that is facing its downfall.", "product_3.jpg", "Watch Dogs: Legion", 50.0, null, 100 },
                    { 4, "18th century, North America. Amidst the chaos and violence of the French and Indian War, Shay Patrick Cormac, a fearless young member of the Brotherhood of Assassin’s, undergoes a dark transformation that will forever shape the future of the American colonies.", "product_4.jpg", "Assassin´s Creed Rogue", 11.949999999999999, null, 15 },
                    { 5, "Squad up and breach in to explosive 5v5 PVP action. Tom Clancy's Rainbow Six Siege features a huge roster of specialized operators, each with game-changing gadgets to help you lead your team to victory.", "product_5.jpg", "Tom Clancy´s Rainbow Six Siege", 24.949999999999999, null, 1050 }
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
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "FK_Product", "FK_UserId", "IsFinished", "TotalPrice" },
                values: new object[] { 1, 1, 1, true, 59.5 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "FK_Product", "FK_UserId", "TotalPrice" },
                values: new object[] { 2, 2, 1, 45.0 });

            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "UserId", "Adress", "City", "EMail", "FullName" },
                values: new object[,]
                {
                    { 1, "Nørre Havnegade 40", "Sønderborg", "1n2n3n4n5n@hotmail.dk", "Nicklas M Nielsen" },
                    { 2, "Carl Jacobsens Vej 25", "København", "CarlJacobsensVej@hotmail.com", "Sven Petersen" },
                    { 3, "Høffdingsvej 14", "København", "KildeSkolen@hotmail.com", "John Jørgensen" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "FK_ShooppingCartId", "FK_UserInformation", "OrderDate", "UserInformationUserId" },
                values: new object[] { 1, 1, 1, new DateTime(2021, 10, 14, 11, 13, 5, 400, DateTimeKind.Local).AddTicks(7325), null });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FK_ShooppingCartId",
                table: "Orders",
                column: "FK_ShooppingCartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserInformationUserId",
                table: "Orders",
                column: "UserInformationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartId",
                table: "Products",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_FK_UserId",
                table: "ShoppingCarts",
                column: "FK_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserInformations");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
