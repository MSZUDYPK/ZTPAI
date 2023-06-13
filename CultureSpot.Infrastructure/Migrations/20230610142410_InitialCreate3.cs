using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CultureSpot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "ScheduleItems",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTime",
                table: "ScheduleItems",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "ScheduleItems",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ScheduleItems",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ScheduleItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ScheduleItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "ScheduleItems",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ScheduleItems",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");
        }
    }
}
