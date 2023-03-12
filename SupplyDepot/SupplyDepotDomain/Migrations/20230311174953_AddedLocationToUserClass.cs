using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyDepotDomain.Migrations
{
    /// <inheritdoc />
    public partial class AddedLocationToUserClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_LocationId",
                table: "User",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Location_LocationId",
                table: "User",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "location_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Location_LocationId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LocationId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "User");
        }
    }
}
