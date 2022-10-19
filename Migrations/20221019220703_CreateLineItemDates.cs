using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuoteEditorBlazor.Migrations
{
    public partial class CreateLineItemDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "line_item_dates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    quote_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_line_item_dates", x => x.id);
                    table.ForeignKey(
                        name: "fk_line_item_dates_quotes_quote_id",
                        column: x => x.quote_id,
                        principalTable: "quotes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_line_item_dates_date",
                table: "line_item_dates",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "ix_line_item_dates_date_quote_id",
                table: "line_item_dates",
                columns: new[] { "date", "quote_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_line_item_dates_quote_id",
                table: "line_item_dates",
                column: "quote_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "line_item_dates");
        }
    }
}
