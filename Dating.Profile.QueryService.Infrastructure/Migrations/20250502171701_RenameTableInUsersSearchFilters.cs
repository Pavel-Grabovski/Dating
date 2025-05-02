using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dating.Profile.QueryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableInUsersSearchFilters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "UsersPreferences", newName: "UsersSearchFilters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "UsersSearchFilters", newName: "UsersPreferences");
        }
    }
}
