using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignBureau.Infrastructure.Data.Migrations
{
    public partial class ImgUrlsAddedInSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ca75fd4-88e7-4942-a2dc-57c26f8e78d3", "AQAAAAEAACcQAAAAEHcbI3WUjQMsqtukucwKRHWITu7gY1zF3ot6MFjD1d/zIZ6WAY7uvbWV/KBuX515ew==", "f312c5a2-8b6a-4542-93d5-0e30506ec780" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9892ec11-0b7f-40f0-8bac-9c0379b53f5f", "AQAAAAEAACcQAAAAELr4IQzKMQqYH6yxDf2aIOrcMAjiGaGV7Ns/tjbmpM52CodFX2I1HbVYMguHjjlhXQ==", "972e4ad6-a38d-4e5d-b7ad-10267bafc9ba" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://localhost:7134/img/ONYX/ONYX-02.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://localhost:7134/img/ONYX/ONYX-03.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://localhost:7134/img/SEG/SEG-02.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://localhost:7134/img/SEG/SEG-03.jpg");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainImageUrl",
                value: "https://localhost:7134/img/ONYX/ONYX-01.jpg");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "MainImageUrl",
                value: "https://localhost:7134/img/SEG/SEG-01.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "");

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
    }
}
