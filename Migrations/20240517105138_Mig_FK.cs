using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.Migrations
{
    public partial class Mig_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_Drivers_DriverId",
                table: "Duties");

            migrationBuilder.DropIndex(
                name: "IX_Duties_DriverId",
                table: "Duties");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Duties");

            migrationBuilder.AddColumn<int>(
                name: "fk_DriverId",
                table: "Duties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Duties_fk_DriverId",
                table: "Duties",
                column: "fk_DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_Drivers_fk_DriverId",
                table: "Duties",
                column: "fk_DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_Drivers_fk_DriverId",
                table: "Duties");

            migrationBuilder.DropIndex(
                name: "IX_Duties_fk_DriverId",
                table: "Duties");

            migrationBuilder.DropColumn(
                name: "fk_DriverId",
                table: "Duties");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Duties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Duties_DriverId",
                table: "Duties",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_Drivers_DriverId",
                table: "Duties",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
