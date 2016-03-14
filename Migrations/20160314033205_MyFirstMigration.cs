using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace planesPuller.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "planeInfo",
                columns: table => new
                {
                    planeInfoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    aircraftId = table.Column<string>(nullable: true),
                    alert = table.Column<bool>(nullable: false),
                    altitude = table.Column<int>(nullable: true),
                    callSign = table.Column<string>(nullable: true),
                    emergency = table.Column<bool>(nullable: false),
                    flightId = table.Column<string>(nullable: true),
                    generatedDate = table.Column<string>(nullable: true),
                    generatedTime = table.Column<string>(nullable: true),
                    groundSpeed = table.Column<int>(nullable: true),
                    hexIdent = table.Column<string>(nullable: true),
                    isOnGround = table.Column<bool>(nullable: false),
                    lat = table.Column<float>(nullable: true),
                    loggedDate = table.Column<string>(nullable: true),
                    loggedTime = table.Column<string>(nullable: true),
                    lon = table.Column<float>(nullable: true),
                    messageType = table.Column<int>(nullable: false),
                    sessionId = table.Column<string>(nullable: true),
                    spi = table.Column<bool>(nullable: false),
                    squawk = table.Column<string>(nullable: true),
                    track = table.Column<int>(nullable: true),
                    transmissiontype = table.Column<int>(nullable: false),
                    verticalRate = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planeInfo", x => x.planeInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("planeInfo");
        }
    }
}
