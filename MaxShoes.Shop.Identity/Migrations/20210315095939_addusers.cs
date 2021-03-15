using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaxShoes.Shop.Identity.Migrations
{
    public partial class addusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Contact_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_HouseNumber = table.Column<int>(type: "int", nullable: true),
                    Contact_ApartmentNumber = table.Column<int>(type: "int", nullable: true),
                    Contact_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsEmailConfirmed", "Password", "Role", "UserName", "Contact_ApartmentNumber", "Contact_City", "Contact_FirstName", "Contact_HouseNumber", "Contact_Id", "Contact_LastName", "Contact_PhoneNumber", "Contact_State", "Contact_Street", "Contact_ZipCode" },
                values: new object[] { "37846734-172e-4149-8cec-6f43d1eb3f60", "Employee1@test.pl", true, "$2a$11$SK0eDWBrnPV/CTU5Oa6bm.hPzoewvHXnCFqiWhNQunUvh93oRXPLC", "Employee", "Employee1", 23, "Czestochowa", "Piter", 45, "2c5e391a-b014-4b79-9102-7d80f554c5ce", "Blukacz", "666111222", "Polska", "Zielona", "42-200" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsEmailConfirmed", "Password", "Role", "UserName", "Contact_ApartmentNumber", "Contact_City", "Contact_FirstName", "Contact_HouseNumber", "Contact_Id", "Contact_LastName", "Contact_PhoneNumber", "Contact_State", "Contact_Street", "Contact_ZipCode" },
                values: new object[] { "37846734-172e-4149-8cec-6f43d1eb3f61", "Employee2@test.pl", true, "$2a$11$QwwGS16U8T5b4pgrRp75HO4O8MJGkNgJ9C3OtyORhVqr4ex4K7fCa", "Employee", "Employee2", 0, "Czestochowa", "Jan", 2, "781357eb-df6d-4548-ae34-4f544bad96d1", "Oko", "666111223", "Polska", "Liliowa", "42-202" });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
