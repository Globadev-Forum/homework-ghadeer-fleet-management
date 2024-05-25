using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.Migrations
{
    public partial class Mig_FKNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_Drivers_FK_DriverId",
                table: "Duties");

            migrationBuilder.DropIndex(
                name: "IX_Duties_FK_DriverId",
                table: "Duties");

            migrationBuilder.DropColumn(
                name: "FK_DriverId",
                table: "Duties");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Duties",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_DriverId",
                table: "Duties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Duties_FK_DriverId",
                table: "Duties",
                column: "FK_DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_Drivers_FK_DriverId",
                table: "Duties",
                column: "FK_DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
