using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaxShoes.Shop.Identity.Migrations
{
    public partial class addusersfixnotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "37846734-172e-4149-8cec-6f43d1eb3f60",
                columns: new[] { "Password", "Contact_Id" },
                values: new object[] { "$2a$11$IzNufv5QLYjULiVc5QZ/IOOIqAliQcnlcaBUUWsCG2TcSIEqn02Y.", "886c5a83-e232-4b8a-8e29-dac66b6f9cef" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "37846734-172e-4149-8cec-6f43d1eb3f61",
                columns: new[] { "Password", "Contact_Id" },
                values: new object[] { "$2a$11$mY.v4l46HY3gesrHQJVxzuSAovZaihgAd4qUj/3yC5FrTvbYbjxp2", "c4b013ea-cf54-40ef-94a7-8d8e508031e6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "37846734-172e-4149-8cec-6f43d1eb3f60",
                columns: new[] { "Password", "Contact_Id" },
                values: new object[] { "$2a$11$SK0eDWBrnPV/CTU5Oa6bm.hPzoewvHXnCFqiWhNQunUvh93oRXPLC", "2c5e391a-b014-4b79-9102-7d80f554c5ce" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "37846734-172e-4149-8cec-6f43d1eb3f61",
                columns: new[] { "Password", "Contact_Id" },
                values: new object[] { "$2a$11$QwwGS16U8T5b4pgrRp75HO4O8MJGkNgJ9C3OtyORhVqr4ex4K7fCa", "781357eb-df6d-4548-ae34-4f544bad96d1" });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");
        }
    }
}
