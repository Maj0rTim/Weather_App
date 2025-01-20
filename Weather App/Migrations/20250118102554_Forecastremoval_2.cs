using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather_App.Migrations
{
    /// <inheritdoc />
    public partial class Forecastremoval_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Forecast",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Forecast");
        }
    }
}
