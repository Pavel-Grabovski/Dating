using System;
using Dating.Profile.QueryService.Domain.Enum;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dating.Profile.QueryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableUsersPreferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersPreferences",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Gender = table.Column<Gender>(type: "gender", nullable: false),
                    YearBirthFrom = table.Column<int>(type: "integer", nullable: false),
                    YearBirthTo = table.Column<int>(type: "integer", nullable: false),
                    SearchRadius = table.Column<int>(type: "integer", nullable: false),
                    HaveChildren = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPreferences", x => x.UserId);
                    table.CheckConstraint("CK_SearchRadius_Greater_Zero", "\"SearchRadius\" > 0");
                    table.ForeignKey(
                        name: "FK_UsersPreferences_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPreferences");
        }
    }
}
