using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResidentialComplex.DataAccessLayer.Migrations
{
    public partial class ResidentialComplex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfHouse = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    DateOfPurchase = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNumber = table.Column<int>(nullable: false),
                    Area = table.Column<float>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false),
                    HouseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flats_Houses_HouseID",
                        column: x => x.HouseID,
                        principalTable: "Houses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flats_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousingDepartaments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pay = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FlatID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingDepartaments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HousingDepartaments_Flats_FlatID",
                        column: x => x.FlatID,
                        principalTable: "Flats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name", "PhoneNumber", "DateOfPurchase" },
                values: new object[,]
                {
                    { 1, "AleksSkritskii", 12345, "19/07/2019 10:00" },
                    { 2, "LizaSimpson", 267891, "03/08/2016 12:00" },
                    { 3, "MaksBelii", 891903, "30/10/2020 13:00" },
                    { 4, "KyryloShchupii", 696969, "06/09/2016 20:00" },
                    { 5, "MariaTkach", 642781, "12/02/2017 12:00" },
                    { 6, "VitaliiKlimchenko", 327891, "23/11/2018 15:00" }
                });

            migrationBuilder.InsertData(
                table: "House",
                columns: new[] { "Id", "NumberOfHouse", "Address" },
                values: new object[,]
                {
                    {1, 1, "Soborna2" },
                    {2, 2, "Soborna2a"},
                    {3, 3, "Soborna3" },
                    {4, 4, "Soborna4" }
                });

            migrationBuilder.InsertData(
                table: "Flats",
                columns: new[] { "Id", "ApartmentNumber", "Area", "HouseId", "OwnerId" },
                values: new object[,]
                {
                    {1, 1, 67.5, 1, 1 },
                    {2, 3, 59.7, 1, 2 },
                    {3, 49, 90.7, 2, 3 },
                    {4, 69, 69.6, 2, 4 },
                    {5, 115, 76.3, 3, 5 },
                    {6, 121, 81.2, 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_HouseID",
                table: "Flats",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_OwnerID",
                table: "Flats",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_HousingDepartaments_FlatID",
                table: "HousingDepartaments",
                column: "FlatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HousingDepartaments");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
