using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dating.Profile.QueryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeUnknownInGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:gender", "unknown,man,woman")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .OldAnnotation("Npgsql:Enum:gender", "man,woman")
                .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Valid_Gender",
                table: "UserProfiles",
                sql: "\"Gender\" IN ('man', 'woman')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Valid_Gender",
                table: "UserProfiles");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:gender", "man,woman")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .OldAnnotation("Npgsql:Enum:gender", "unknown,man,woman")
                .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,");
        }
    }
}
