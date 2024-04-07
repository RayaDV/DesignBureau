using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignBureau.Infrastructure.Data.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ebb7ac0-f9b8-4067-a775-97db2b221a0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f08c4b6-7afe-4bba-beaa-36d800c03e44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba102d51-e44b-4118-b42e-02791106adb9", "AQAAAAEAACcQAAAAEDNhBUNFUXMXC1bx09MXVdN8dsgzkCjRCT6v+I/szspw7sa8O+HWpdhNOSgdtxp7gg==", "7045be8f-495d-4ce4-9989-5f1738bde087" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookPage", "FirstName", "LastName", "LinkedInPage", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SkypeProfile", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "0d9ca48d-c27a-4e56-9962-a014d43f2827", "dimitar@mail.com", false, "", "Dimitar", "Dimitrov", "", false, null, "DIMITAR@MAIL.COM", "DIMITAR@MAIL.COM", "AQAAAAEAACcQAAAAEPbzFTBS2zloS7wfHEld4j+7AcmbH6KyXfC3fGZR4eZ15rxHPRcUHrdv2twFUGDWCA==", null, false, "fa6f06aa-daf9-4a7b-a3c3-c3116dba6c00", "", false, "dimitar@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookPage", "FirstName", "LastName", "LinkedInPage", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SkypeProfile", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e43ce836-997d-4927-ac59-74e8c41bbfd3", 0, "7491acbe-9ce9-4208-b4c3-42f893f9a282", "admin@mail.com", false, "", "The", "Admin", "", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEETG5odPlYEUh1JFe95ft3bzbLiGjiqBFTQNVg+3QuQhhwIqPIfTvRxbZUrR71MVNA==", null, false, "b925ffe3-3283-4cfe-9921-573366e19e86", "", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Designers",
                columns: new[] { "Id", "DesignExperience", "DesignerImageUrl", "DisciplineId", "PhoneNumber", "UserId" },
                values: new object[] { 2, 0, "https://localhost:7134/img/Designers/Admin.jpg", 1, "+359888888888", "e43ce836-997d-4927-ac59-74e8c41bbfd3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f08c4b6-7afe-4bba-beaa-36d800c03e44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9e4c0e9-e72c-49b2-a405-f5c4e891f015", "AQAAAAEAACcQAAAAEPzOIpjm1W8Bb3j05IbFGOOqPrPoRok0I+Q46G7sGbggK6iGj25lJRZJZGEVDWeSqQ==", "107c9355-cb01-4519-b98e-c73b55c3764f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookPage", "FirstName", "LastName", "LinkedInPage", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SkypeProfile", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2ebb7ac0-f9b8-4067-a775-97db2b221a0b", 0, "3c434882-dc92-4e41-8012-d40c6b194435", "dimitar@mail.com", false, "", "Dimitar", "Dimitrov", "", false, null, "DIMITAR@MAIL.COM", "DIMITAR@MAIL.COM", "AQAAAAEAACcQAAAAECmPY+UEBohLdL43xyefUy0fZ+BjLqaIwWlKwNrZojbQhYAfXllxdnzs4121dF8ShA==", null, false, "6714d114-8a12-439a-aad3-71f2d0acb0db", "", false, "dimitar@mail.com" });
        }
    }
}
