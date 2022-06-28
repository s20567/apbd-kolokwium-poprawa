using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolokwium.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Member_Organization_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organization",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Team_Organization_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organization",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => new { x.FileID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_File_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberID1 = table.Column<int>(type: "int", nullable: true),
                    TeamID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => new { x.MemberID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_Membership_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Membership_Member_MemberID1",
                        column: x => x.MemberID1,
                        principalTable: "Member",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Membership_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID");
                    table.ForeignKey(
                        name: "FK_Membership_Team_TeamID1",
                        column: x => x.TeamID1,
                        principalTable: "Team",
                        principalColumn: "TeamID");
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "OrganizationID", "Domain", "Name" },
                values: new object[] { 1, "Kolory", "Kolorowi" });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "OrganizationID", "Domain", "Name" },
                values: new object[] { 2, "Jednostki", "Jednostkowi" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberID", "Name", "Nickname", "OrganizationID", "Surname" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowal", 1, "Kowalski" },
                    { 2, "Jakub", null, 2, "Nowak" },
                    { 3, "Sławomir", "Skrót", 2, "XYZ" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamID", "Description", "Name", "OrganizationID" },
                values: new object[,]
                {
                    { 1, null, "Niebiescy", 1 },
                    { 2, null, "Zieloni", 1 },
                    { 3, "Ten zespół jest czerwony", "Czerwoni", 2 }
                });

            migrationBuilder.InsertData(
                table: "File",
                columns: new[] { "FileID", "TeamID", "Extension", "Name", "Size" },
                values: new object[,]
                {
                    { 1, 1, ".txt", "wynik", 3 },
                    { 2, 1, ".docx", "pismo", 10 },
                    { 3, 2, ".rar", "wniosek", 20 }
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "MemberID", "TeamID", "Date", "MemberID1", "TeamID1" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_TeamID",
                table: "File",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_OrganizationID",
                table: "Member",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_MemberID1",
                table: "Membership",
                column: "MemberID1");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_TeamID",
                table: "Membership",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_TeamID1",
                table: "Membership",
                column: "TeamID1");

            migrationBuilder.CreateIndex(
                name: "IX_Team_OrganizationID",
                table: "Team",
                column: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
