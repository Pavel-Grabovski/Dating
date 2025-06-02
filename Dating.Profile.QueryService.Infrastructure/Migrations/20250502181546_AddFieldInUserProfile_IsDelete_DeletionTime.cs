using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dating.Profile.QueryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldInUserProfile_IsDelete_DeletionTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "UserProfiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "UserProfiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "UserProfiles");
        }
    }
}
