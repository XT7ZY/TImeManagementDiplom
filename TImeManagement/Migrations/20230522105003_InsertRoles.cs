using Microsoft.EntityFrameworkCore.Migrations;
using TImeManagement.Models;

#nullable disable

namespace TImeManagement.Migrations
{
    /// <inheritdoc />
    public partial class InsertRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { nameof(Role.Name) },
                values: new object[,]
                {
                    {"employer"},
                    {"admin"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
