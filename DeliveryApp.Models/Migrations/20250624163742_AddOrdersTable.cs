using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenderCity = table.Column<string>(type: "TEXT", nullable: false),
                    SenderAddress = table.Column<string>(type: "TEXT", nullable: false),
                    ReceiverCity = table.Column<string>(type: "TEXT", nullable: false),
                    ReceiverAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CargoWeight = table.Column<double>(type: "REAL", nullable: false),
                    CargoPickupDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
