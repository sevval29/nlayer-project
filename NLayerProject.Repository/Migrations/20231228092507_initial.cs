using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerProject.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "TeamName", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 12, 28, 12, 25, 7, 460, DateTimeKind.Local).AddTicks(1257), "Development", null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "TeamName", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2023, 12, 28, 12, 25, 7, 460, DateTimeKind.Local).AddTicks(1268), "Marketing", null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "TeamName", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2023, 12, 28, 12, 25, 7, 460, DateTimeKind.Local).AddTicks(1269), "Sales", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "TeamId", "UpdatedDate", "UserName" },
                values: new object[] { 1, new DateTime(2023, 12, 28, 12, 25, 7, 460, DateTimeKind.Local).AddTicks(1737), "john@example.com", "password123", 1, null, "john_doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "TeamId", "UpdatedDate", "UserName" },
                values: new object[] { 2, new DateTime(2023, 12, 28, 12, 25, 7, 460, DateTimeKind.Local).AddTicks(1740), "jane@example.com", "password456", 2, null, "jane_doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "TeamId", "UpdatedDate", "UserName" },
                values: new object[] { 3, new DateTime(2023, 12, 28, 12, 25, 7, 460, DateTimeKind.Local).AddTicks(1741), "bob@example.com", "password789", 1, null, "bob_smith" });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "FirstName", "LastName", "NickName", "UserId" },
                values: new object[] { 1, "John", "Doe", "JD", 1 });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "FirstName", "LastName", "NickName", "UserId" },
                values: new object[] { 2, "Jane", "Doe", "Jane", 2 });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "FirstName", "LastName", "NickName", "UserId" },
                values: new object[] { 3, "Bob", "Smith", "Bob", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
