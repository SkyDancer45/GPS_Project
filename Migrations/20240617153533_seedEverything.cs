using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GPS.Api.Migrations
{
    /// <inheritdoc />
    public partial class seedEverything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleNum", "Latitude", "Longitude", "Make", "Model", "OwnerId", "Year" },
                values: new object[,]
                {
                    { 1, 0.0001, 1.0000000000000001E-05, "make1", "model1", "ownerId1", 2021 },
                    { 2, 0.00020000000000000001, 2.0000000000000002E-05, "make2", "model2", "ownerId2", 2022 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleNum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleNum",
                keyValue: 2);
        }
    }
}
