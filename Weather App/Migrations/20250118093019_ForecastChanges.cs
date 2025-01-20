using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather_App.Migrations
{
    /// <inheritdoc />
    public partial class ForecastChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forecast_City_CityId",
                table: "Forecast");

            migrationBuilder.DropIndex(
                name: "IX_Forecast_CityId",
                table: "Forecast");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "Forecast",
                newName: "Temp");

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "Forecast",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Min",
                table: "Forecast",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Forecast",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Forecast",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Max",
                table: "Forecast");

            migrationBuilder.DropColumn(
                name: "Min",
                table: "Forecast");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Forecast");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Forecast");

            migrationBuilder.RenameColumn(
                name: "Temp",
                table: "Forecast",
                newName: "Temperature");

            migrationBuilder.CreateIndex(
                name: "IX_Forecast_CityId",
                table: "Forecast",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forecast_City_CityId",
                table: "Forecast",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
