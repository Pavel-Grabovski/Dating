using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dating.Profile.QueryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPostGis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:gender", "man,woman")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .OldAnnotation("Npgsql:Enum:gender", "man,woman");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:gender", "man,woman")
                .OldAnnotation("Npgsql:Enum:gender", "man,woman")
                .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,");
        }
    }
}
