using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TImeManagement.Migrations
{
    /// <inheritdoc />
    public partial class CreateFirstTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bidsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bidsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOnly = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    BidTypeId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecieverId = table.Column<int>(type: "int", nullable: false),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bids_bidsType_BidTypeId",
                        column: x => x.BidTypeId,
                        principalTable: "bidsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employers_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayEmployer",
                columns: table => new
                {
                    DaysId = table.Column<int>(type: "int", nullable: false),
                    EmployersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayEmployer", x => new { x.DaysId, x.EmployersId });
                    table.ForeignKey(
                        name: "FK_DayEmployer_days_DaysId",
                        column: x => x.DaysId,
                        principalTable: "days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayEmployer_employers_EmployersId",
                        column: x => x.EmployersId,
                        principalTable: "employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bids_BidTypeId",
                table: "bids",
                column: "BidTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEmployer_EmployersId",
                table: "DayEmployer",
                column: "EmployersId");

            migrationBuilder.CreateIndex(
                name: "IX_employers_RoleId",
                table: "employers",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bids");

            migrationBuilder.DropTable(
                name: "DayEmployer");

            migrationBuilder.DropTable(
                name: "bidsType");

            migrationBuilder.DropTable(
                name: "days");

            migrationBuilder.DropTable(
                name: "employers");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
