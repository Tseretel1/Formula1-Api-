﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Api.Migrations
{
    /// <inheritdoc />
    public partial class DriverAgeNtionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Drivers");
        }
    }
}
