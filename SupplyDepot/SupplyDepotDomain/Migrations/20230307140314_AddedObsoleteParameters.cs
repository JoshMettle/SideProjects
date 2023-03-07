using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyDepotDomain.Migrations
{
    /// <inheritdoc />
    public partial class AddedObsoleteParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Obsolete",
                table: "Vendor",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Obsolete",
                table: "User",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Obsolete",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Obsolete",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Obsolete",
                table: "Location",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obsolete",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Obsolete",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Obsolete",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Obsolete",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Obsolete",
                table: "Location");
        }
    }
}
