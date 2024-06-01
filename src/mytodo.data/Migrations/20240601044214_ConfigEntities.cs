using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mytodo.data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Task");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataVencimento",
                table: "Task",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVencimento",
                table: "Task");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Task",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
