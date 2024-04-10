using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignBureau.Infrastructure.Data.Migrations
{
    public partial class ProjectDataConstantsModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Project description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Project description");

            migrationBuilder.AlterColumn<string>(
                name: "Architect",
                table: "Projects",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "Architect of the project",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldComment: "Architect of the project");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f08c4b6-7afe-4bba-beaa-36d800c03e44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bd8a573-1e7e-4283-b0e8-bcc1d7650c35", "AQAAAAEAACcQAAAAEJSv/huougFzG+yOurCDwy19ONUe/ditHEl3dxI6zz/XU6fRu0nnE1uIaa6hUR9lPw==", "86ca9e2a-ce81-4699-8ddb-8bbd41ee037d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6123dbfc-e20d-47d6-b14e-5eb2098b936c", "AQAAAAEAACcQAAAAEFvwhxHq/CnufY/cSMCwcq8k/8XHyiRlcl1TeJVfPhT7p/GTDLjGxABrWXStDeYyzg==", "a0e6653d-e04c-4278-90fb-79b76a7a988c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ab191b6-6d70-44c4-bcd3-a62b860007e5", "AQAAAAEAACcQAAAAEGrWeW8J3JUU5M/KZNng5VZKVPdpLmMFvwVVbkvbAs1Apcld7JtW/4blD8ZoRLL1qA==", "ce53a6d1-72f6-473d-b905-fe5e9133cac6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Project description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Project description");

            migrationBuilder.AlterColumn<string>(
                name: "Architect",
                table: "Projects",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                comment: "Architect of the project",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "Architect of the project");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f08c4b6-7afe-4bba-beaa-36d800c03e44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59109ffc-9d1f-402b-8e8e-624cb3f679cb", "AQAAAAEAACcQAAAAEDHcIxOR2ZXaPLduIJVaClRyLbxx6t814YzUmZURT7jL0Y4TgYpg1cXLBWFclTlj9Q==", "ec79ceb9-48f8-4934-af9d-679525461841" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccdb3ef1-0c18-445c-bb51-631620cb7f1d", "AQAAAAEAACcQAAAAECCnRA6QvdAXjofY9EkpoWlcu4CkH0q4tl3ORPdo07YmL1RprXVF4ojoddaF/zF4Bw==", "1233fe1f-27d7-4b69-94f2-75ce506e6c85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6083ae63-45e8-43d8-bceb-9f5e34005046", "AQAAAAEAACcQAAAAEKxNbg55JVJnV3wM2OwJLSuvQXMuNGSXPXqfe5PR9nO/yRQNODatVuBeZbriedh2tQ==", "3a84dd83-fdc6-4965-a6d1-c3e0de1c9e8c" });
        }
    }
}
