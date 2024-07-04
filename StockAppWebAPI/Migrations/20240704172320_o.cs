using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class o : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quotes",
                columns: table => new
                {
                    quote_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stock_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    percent_change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    volume = table.Column<int>(type: "int", nullable: false),
                    time_stamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotes", x => x.quote_id);
                    table.ForeignKey(
                        name: "FK_quotes_stocks_stock_id",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quotes_stock_id",
                table: "quotes",
                column: "stock_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quotes");
        }
    }
}
