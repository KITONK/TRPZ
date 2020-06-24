using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Implementation.Migrations
{
    public partial class ResidentialComplex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfHouse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTypes", x => x.Id);
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
                name: "Houses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    NumberOfHouse = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Houses_HouseTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "HouseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNumber = table.Column<int>(nullable: false),
                    Area = table.Column<float>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    HouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flats_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flats_Owners_OwnerId",
                        column: x => x.OwnerId,
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
                    FlatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingDepartaments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HousingDepartaments_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HouseTypes",
                columns: new[] { "Id", "NumberOfHouse" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "ID", "DateOfPurchase", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), "Aleks Skritskii", "12345" },
                    { 2, new DateTime(2016, 8, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "LizaSimpson", "267891" },
                    { 3, new DateTime(2020, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), "MaksBelii", "891903" },
                    { 4, new DateTime(2016, 9, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), "KyryloShchupii", "696969" },
                    { 5, new DateTime(2017, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "MariaTkach", "642781" },
                    { 6, new DateTime(2018, 11, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), "VitaliiKlimchenko", "327891" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "ID", "Address", "NumberOfHouse", "TypeId" },
                values: new object[,]
                {
                    { 1, "Soborna 2", 0, 1 },
                    { 2, "Soborna 2a", 0, 2 },
                    { 3, "Soborna 3", 0, 3 },
                    { 4, "Soborna 4", 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Flats",
                columns: new[] { "ID", "ApartmentNumber", "Area", "HouseId", "OwnerId" },
                values: new object[,]
                {
                    { 1, 1, 67.5f, 1, 1 },
                    { 2, 3, 59.7f, 1, 2 },
                    { 3, 49, 90.7f, 2, 3 },
                    { 4, 69, 69.6f, 2, 4 },
                    { 5, 115, 76.3f, 3, 5 },
                    { 6, 121, 81.2f, 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_HouseId",
                table: "Flats",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_OwnerId",
                table: "Flats",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_TypeId",
                table: "Houses",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HousingDepartaments_FlatId",
                table: "HousingDepartaments",
                column: "FlatId");
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

            migrationBuilder.DropTable(
                name: "HouseTypes");
        }
    }
}
