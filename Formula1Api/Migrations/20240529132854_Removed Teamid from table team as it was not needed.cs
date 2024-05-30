using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Api.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTeamidfromtableteamasitwasnotneeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
