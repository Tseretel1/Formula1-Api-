using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Api.Migrations
{
    /// <inheritdoc />
    public partial class f1Teamcandtheircars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamCar",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamCar",
                table: "Teams");
        }
    }
}
