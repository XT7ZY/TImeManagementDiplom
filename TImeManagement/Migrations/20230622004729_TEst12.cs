using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TImeManagement.Migrations
{
    /// <inheritdoc />
    public partial class TEst12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployerSenderId",
                table: "bids",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bids_EmployerSenderId",
                table: "bids",
                column: "EmployerSenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_bids_employers_EmployerSenderId",
                table: "bids",
                column: "EmployerSenderId",
                principalTable: "employers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bids_employers_EmployerSenderId",
                table: "bids");

            migrationBuilder.DropIndex(
                name: "IX_bids_EmployerSenderId",
                table: "bids");

            migrationBuilder.DropColumn(
                name: "EmployerSenderId",
                table: "bids");
        }
    }
}
