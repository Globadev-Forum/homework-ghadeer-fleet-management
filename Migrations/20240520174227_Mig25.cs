using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.Migrations
{
    public partial class Mig25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_Desc = table.Column<string>(nullable: false),
                    Vehicle_Plate_No = table.Column<string>(nullable: false),
                    Vehicle_Reg_Date = table.Column<DateTime>(nullable: false),
                    Vehicle_Exp_Reg_Date = table.Column<DateTime>(nullable: false),
                    Vehicle_Ins_PolicyNo = table.Column<string>(nullable: false),
                    DriverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverId",
                table: "Vehicles",
                column: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
