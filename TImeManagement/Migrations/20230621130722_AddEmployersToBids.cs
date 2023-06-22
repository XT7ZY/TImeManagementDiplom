using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TImeManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployersToBids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bids_bidsType_BidTypeId",
                table: "bids");

            migrationBuilder.AddColumn<int>(
                name: "BidId",
                table: "employers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecieverId",
                table: "bids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BidTypeId",
                table: "bids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_employers_BidId",
                table: "employers",
                column: "BidId");

            migrationBuilder.AddForeignKey(
                name: "FK_bids_bidsType_BidTypeId",
                table: "bids",
                column: "BidTypeId",
                principalTable: "bidsType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employers_bids_BidId",
                table: "employers",
                column: "BidId",
                principalTable: "bids",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bids_bidsType_BidTypeId",
                table: "bids");

            migrationBuilder.DropForeignKey(
                name: "FK_employers_bids_BidId",
                table: "employers");

            migrationBuilder.DropIndex(
                name: "IX_employers_BidId",
                table: "employers");

            migrationBuilder.DropColumn(
                name: "BidId",
                table: "employers");

            migrationBuilder.AlterColumn<int>(
                name: "RecieverId",
                table: "bids",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BidTypeId",
                table: "bids",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_bidsType_BidTypeId",
                table: "bids",
                column: "BidTypeId",
                principalTable: "bidsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
