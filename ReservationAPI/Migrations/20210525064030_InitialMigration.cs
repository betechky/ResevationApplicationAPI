using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Reservationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Reservations_Reservationid",
                        column: x => x.Reservationid,
                        principalTable: "Reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationMenuItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationMenuItems_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "id", "Name", "Price", "Reservationid" },
                values: new object[,]
                {
                    { 1, "Salad", 5.0, null },
                    { 2, "Salmon", 25.0, null },
                    { 3, "Mango shake", 5.0, null },
                    { 4, "Shawarma", 12.0, null },
                    { 5, "Burger steak", 7.0, null }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "id", "Date", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 25, 1, 40, 29, 544, DateTimeKind.Local).AddTicks(9355), "Enzo" },
                    { 2, new DateTime(2021, 5, 25, 1, 40, 29, 551, DateTimeKind.Local).AddTicks(4370), "Aaliyah" },
                    { 3, new DateTime(2021, 5, 25, 1, 40, 29, 551, DateTimeKind.Local).AddTicks(4436), "Joemarie" }
                });

            migrationBuilder.InsertData(
                table: "ReservationMenuItems",
                columns: new[] { "Id", "MenuItemId", "ReservationId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_Reservationid",
                table: "MenuItems",
                column: "Reservationid");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationMenuItems_MenuItemId",
                table: "ReservationMenuItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationMenuItems_ReservationId",
                table: "ReservationMenuItems",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationMenuItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
