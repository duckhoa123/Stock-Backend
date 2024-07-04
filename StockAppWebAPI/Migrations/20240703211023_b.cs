using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "user",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    stock_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    market_cap = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    sector = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    industry = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    sector_en = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    industry_en = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    stock_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rank = table.Column<int>(type: "int", nullable: false),
                    rank_source = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.stock_id);
                });

            migrationBuilder.CreateTable(
                name: "watchlists",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    stock_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlists", x => new { x.user_id, x.stock_id });
                    table.ForeignKey(
                        name: "FK_watchlists_stocks_stock_id",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_watchlists_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_watchlists_stock_id",
                table: "watchlists",
                column: "stock_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "watchlists");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "user",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
