using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace New.Migrations
{
    public partial class option : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zdjęcie1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zdjęcie2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zdjęcie3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specyfikacjat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktywacja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Razem = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Element_koszyka",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraId = table.Column<int>(type: "int", nullable: false),
                    ilość = table.Column<int>(type: "int", nullable: false),
                    Razem = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element_koszyka", x => x.ElementId);
                    table.ForeignKey(
                        name: "FK_Element_koszyka_Gra_GraId",
                        column: x => x.GraId,
                        principalTable: "Gra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NowyKomentarz",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ocena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treść = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NowyKomentarz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NowyKomentarz_Gra_GraId",
                        column: x => x.GraId,
                        principalTable: "Gra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraId = table.Column<int>(type: "int", nullable: false),
                    ilość = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Gra_GraId",
                        column: x => x.GraId,
                        principalTable: "Gra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Element_koszyka_GraId",
                table: "Element_koszyka",
                column: "GraId");

            migrationBuilder.CreateIndex(
                name: "IX_NowyKomentarz_GraId",
                table: "NowyKomentarz",
                column: "GraId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_GraId",
                table: "OrderDetails",
                column: "GraId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Element_koszyka");

            migrationBuilder.DropTable(
                name: "NowyKomentarz");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Gra");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
