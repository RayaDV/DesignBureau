using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignBureau.Infrastructure.Data.Migrations
{
    public partial class InitialDataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "1ac53313-3975-4834-a312-cf368e218ffb", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEBCH29huv1aHr3lpIWOlcz56HkUQ5VT42LzM71Z90ba7Qv00G1fns6TvVt7PnSR0wQ==", null, false, "03253450-d781-4f21-88af-fc6550605a91", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "36b9866a-3bae-45b0-995e-2f6c4e3ec2d2", "designer@mail.com", false, false, null, "designer@mail.com", "designer@mail.com", "AQAAAAEAACcQAAAAEG3eSxITwsCCOubtKcEGo9A50th2cLE8ESwp6rn46JUMnlubO+nJlEb/lpzt/xaSNg==", null, false, "de494fe1-9483-4547-9cb2-a0a93feb151d", false, "designer@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "International Projects" },
                    { 2, "Public Buildings" },
                    { 3, "Office And Residential Buildings" },
                    { 4, "Commercial Buildings" },
                    { 5, "Industrial Buildings" },
                    { 6, "Family Houses" },
                    { 7, "Reconstructions And Rebuildings" }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Architecture" },
                    { 2, "Structure" },
                    { 4, "WS&S" },
                    { 5, "HVAC" },
                    { 6, "Geodesy" },
                    { 7, "Landscaping" }
                });

            migrationBuilder.InsertData(
                table: "Designers",
                columns: new[] { "Id", "DesignExperience", "DesignerImageUrl", "DisciplineId", "Email", "Name", "UserId" },
                values: new object[] { 1, 18, "", 1, "kristina.krumova@e.kroumov.com", "Dipl.Arch. Christina Kroumova", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Designers",
                columns: new[] { "Id", "DesignExperience", "DesignerImageUrl", "DisciplineId", "Email", "Name", "UserId" },
                values: new object[] { 2, 13, "", 2, "raya@e.kroumov.com", "Dipl.Eng. Raya Velichkova", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Architect", "CategoryId", "Country", "Description", "DesignerId", "MainImageUrl", "Phase", "Title", "Town", "YearDesigned" },
                values: new object[] { 1, "ProArch", 3, "Bulgaria", "Total Build Up Area: 12 236,60 m2. Structural design: monolithic reinforced concrete and steel structure. Post-tensioning of the RC plates above lvl.+14.500. At lvl.+11.000 the building is cantilevered over three X-shaped steel columns. 3-dimensional modelling of the structure with Revit Structure. 3D FEM Analysis model with Robot Structural Analysis. Workshop drawings of the steel structure.", 2, "", 2, "Multi-purpose building ONYX", "Sofia", 2019 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Architect", "CategoryId", "Country", "Description", "DesignerId", "MainImageUrl", "Phase", "Title", "Town", "YearDesigned" },
                values: new object[] { 2, "Ivo Petrov Architects", 5, "Bulgaria", "Total Build Up Area: 5 632 m2. Structural design: monolithic reinforced concrete and steel structure with post-tensioned concrete floors. BIM modeling, 3-dimensional modelling of the structure with Revit Structure. Advanced building simulation and analysis with Robot Structural Analysis. Workshop drawings of the steel structure. Тhis building is a participant in The National Contest „Building Of The Year 2019“ and has won a special award in the „Manufacturing and Logistics Buildings” category.", 2, "", 3, "Multi-purpose building SEG", "Krivina", 2018 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageUrl", "ProjectId" },
                values: new object[,]
                {
                    { 1, "", 1 },
                    { 2, "", 1 },
                    { 3, "", 2 },
                    { 4, "", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
