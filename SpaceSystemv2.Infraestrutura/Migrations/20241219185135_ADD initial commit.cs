using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpaceSystemv2.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class ADDinitialcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AstronautRoles",
                columns: table => new
                {
                    ID_AstronautRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AstronautRole_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AstronautRoles", x => x.ID_AstronautRole);
                });

            migrationBuilder.CreateTable(
                name: "MissionTypes",
                columns: table => new
                {
                    ID_MissionType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MissionType_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionTypes", x => x.ID_MissionType);
                });

            migrationBuilder.CreateTable(
                name: "Rocket",
                columns: table => new
                {
                    ID_Rocket = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rocket_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rocket", x => x.ID_Rocket);
                });

            migrationBuilder.CreateTable(
                name: "SpaceStations",
                columns: table => new
                {
                    ID_SpaceStation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpaceStation_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CrewCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InaugurationDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceStations", x => x.ID_SpaceStation);
                });

            migrationBuilder.CreateTable(
                name: "SpaceTourismStations",
                columns: table => new
                {
                    ID_SpaceTourismStation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpaceTourismStation_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TouristCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TouristsPresent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceTourismStations", x => x.ID_SpaceTourismStation);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    ID_Mission = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mission_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_MissionType = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.ID_Mission);
                    table.ForeignKey(
                        name: "FK_Missions_MissionTypes_ID_MissionType",
                        column: x => x.ID_MissionType,
                        principalTable: "MissionTypes",
                        principalColumn: "ID_MissionType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Astronauts",
                columns: table => new
                {
                    ID_Astronaut = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Astronaut_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadyforLaunch = table.Column<bool>(type: "bit", nullable: false),
                    ID_AstronautRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_SpaceStation = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astronauts", x => x.ID_Astronaut);
                    table.ForeignKey(
                        name: "FK_Astronauts_AstronautRoles_ID_AstronautRole",
                        column: x => x.ID_AstronautRole,
                        principalTable: "AstronautRoles",
                        principalColumn: "ID_AstronautRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Astronauts_SpaceStations_ID_SpaceStation",
                        column: x => x.ID_SpaceStation,
                        principalTable: "SpaceStations",
                        principalColumn: "ID_SpaceStation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deploys",
                columns: table => new
                {
                    ID_Deploy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Rocket = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Mission = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Astronaut = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deploys", x => x.ID_Deploy);
                    table.ForeignKey(
                        name: "FK_Deploys_Astronauts_ID_Astronaut",
                        column: x => x.ID_Astronaut,
                        principalTable: "Astronauts",
                        principalColumn: "ID_Astronaut",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deploys_Missions_ID_Mission",
                        column: x => x.ID_Mission,
                        principalTable: "Missions",
                        principalColumn: "ID_Mission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deploys_Rocket_ID_Rocket",
                        column: x => x.ID_Rocket,
                        principalTable: "Rocket",
                        principalColumn: "ID_Rocket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AstronautRoles",
                columns: new[] { "ID_AstronautRole", "AstronautRole_Name" },
                values: new object[,]
                {
                    { new Guid("1e5fb4cd-c7fb-478a-97d1-b318b642e258"), "Commander" },
                    { new Guid("20651e3e-b208-47b8-bd4b-cbe45d1d726e"), "Pilot" },
                    { new Guid("a097c251-44cc-4992-98c4-2065e1036171"), "MissionSpecialist" },
                    { new Guid("c36a08b3-bf89-470c-b5da-8b4545555952"), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "SpaceStations",
                columns: new[] { "ID_SpaceStation", "CrewCapacity", "InaugurationDate", "SpaceStation_Name" },
                values: new object[] { new Guid("9fc58dd5-cc9c-4780-954c-92db908a4568"), "255", "11/12/2024", "ISS" });

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_ID_AstronautRole",
                table: "Astronauts",
                column: "ID_AstronautRole");

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_ID_SpaceStation",
                table: "Astronauts",
                column: "ID_SpaceStation");

            migrationBuilder.CreateIndex(
                name: "IX_Deploys_ID_Astronaut",
                table: "Deploys",
                column: "ID_Astronaut");

            migrationBuilder.CreateIndex(
                name: "IX_Deploys_ID_Mission",
                table: "Deploys",
                column: "ID_Mission");

            migrationBuilder.CreateIndex(
                name: "IX_Deploys_ID_Rocket",
                table: "Deploys",
                column: "ID_Rocket");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_ID_MissionType",
                table: "Missions",
                column: "ID_MissionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deploys");

            migrationBuilder.DropTable(
                name: "SpaceTourismStations");

            migrationBuilder.DropTable(
                name: "Astronauts");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Rocket");

            migrationBuilder.DropTable(
                name: "AstronautRoles");

            migrationBuilder.DropTable(
                name: "SpaceStations");

            migrationBuilder.DropTable(
                name: "MissionTypes");
        }
    }
}
