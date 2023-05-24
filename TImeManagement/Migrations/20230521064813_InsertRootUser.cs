using Microsoft.EntityFrameworkCore.Migrations;
using TImeManagement.Data.Helpers;
using TImeManagement.Models;

#nullable disable

namespace TImeManagement.Migrations
{
    /// <inheritdoc />
    public partial class InsertRootUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { nameof(Role.Name) },
                values: new object[,]
                {
                    {"root"}
                });

            migrationBuilder.InsertData(
                table: "employers",
                columns: new[] {nameof(Employer.Name), nameof(Employer.LastName), nameof(Employer.SurName),
                                nameof(Employer.RoleId), nameof(Employer.UserLogin), nameof(Employer.HashPassword)},
                values: new object[,]{
                {"root", "root", "root", 1, "root", HashPasswordHelper.HashPassword(password: "123456")}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
