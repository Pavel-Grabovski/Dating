using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dating.Profile.QueryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixType_UserSearchFilters_HaveChildren_Null : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HaveChildren",
                table: "UsersSearchFilters",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HaveChildren",
                table: "UsersSearchFilters",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }
    }
}
