using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.Migrations
{
    public partial class Mig_FK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_Drivers_fk_DriverId",
                table: "Duties");

            migrationBuilder.RenameColumn(
                name: "fk_DriverId",
                table: "Duties",
                newName: "FK_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Duties_fk_DriverId",
                table: "Duties",
                newName: "IX_Duties_FK_DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_Drivers_FK_DriverId",
                table: "Duties",
                column: "FK_DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_Drivers_FK_DriverId",
                table: "Duties");

            migrationBuilder.RenameColumn(
                name: "FK_DriverId",
                table: "Duties",
                newName: "fk_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Duties_FK_DriverId",
                table: "Duties",
                newName: "IX_Duties_fk_DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_Drivers_fk_DriverId",
                table: "Duties",
                column: "fk_DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
