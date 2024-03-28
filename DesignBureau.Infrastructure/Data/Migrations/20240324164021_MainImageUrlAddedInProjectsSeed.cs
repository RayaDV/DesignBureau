using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignBureau.Infrastructure.Data.Migrations
{
    public partial class MainImageUrlAddedInProjectsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40288494-322f-487a-b743-c6f037ae8ac3", "AQAAAAEAACcQAAAAEM7XBxkSCe1bUJVQhszkdzZumnrxbbVSvIPoRwJQasZ4UrUP/fHGcrA5qYJ21afU0A==", "81dbe973-cb9c-48ee-9217-563061777ddf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fe0d8ce-8941-46bc-973a-26f40fa49544", "AQAAAAEAACcQAAAAECRKa/FAdbtscTQHoPjd8pwFPtvtuWHZNvlx8CkmY2Pj51VWPHqH+LlEJiMkkN4Hfg==", "badce8c5-53a2-450a-923a-ae7b8a6bde12" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainImageUrl",
                value: "~/img/ONYX/ONYX-01.jpg");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "MainImageUrl",
                value: "~/img/SEG/SEG-01.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ac53313-3975-4834-a312-cf368e218ffb", "AQAAAAEAACcQAAAAEBCH29huv1aHr3lpIWOlcz56HkUQ5VT42LzM71Z90ba7Qv00G1fns6TvVt7PnSR0wQ==", "03253450-d781-4f21-88af-fc6550605a91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36b9866a-3bae-45b0-995e-2f6c4e3ec2d2", "AQAAAAEAACcQAAAAEG3eSxITwsCCOubtKcEGo9A50th2cLE8ESwp6rn46JUMnlubO+nJlEb/lpzt/xaSNg==", "de494fe1-9483-4547-9cb2-a0a93feb151d" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "MainImageUrl",
                value: "");
        }
    }
}
