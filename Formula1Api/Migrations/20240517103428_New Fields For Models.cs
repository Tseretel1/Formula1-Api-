using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Api.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsForModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamPhoto",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Photos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverPhoto",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamPhoto",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "DriverPhoto",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Drivers");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
