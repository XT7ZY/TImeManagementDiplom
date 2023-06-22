using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TImeManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddBidsBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "bids",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "bids");
        }
    }
}
