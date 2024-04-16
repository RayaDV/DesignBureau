using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignBureau.Infrastructure.Data.Migrations
{
    public partial class CommentAndRateEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Phases_PhaseId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Comment identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Comment content"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the comment is send"),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Author identifier"),
                    ProjectId = table.Column<int>(type: "int", nullable: false, comment: "Project identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Comment of a project");

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Rate identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPositive = table.Column<bool>(type: "bit", nullable: false, comment: "Identifier if the rate is positive"),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Author identifier"),
                    ProjectId = table.Column<int>(type: "int", nullable: false, comment: "Project identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Rate of a project");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f08c4b6-7afe-4bba-beaa-36d800c03e44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fa7dc29-15bd-4ea9-b476-f06b5ebbc1a3", "AQAAAAEAACcQAAAAEGZV6RQvGP2QQKYtR99+BFP6LSNP3ZkntcO9mCVWf3lBLqliO43fc1IpRJP8ieGrtQ==", "e71ee5ad-363b-46ea-98fa-37101eb61b27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29680d6a-73d2-40f4-bd6f-544e4056e6c9", "AQAAAAEAACcQAAAAEANvBUlYQYp5+hE/aTuQh3VCzvpN3cPcHdgOT90Wt+mq/8c7fFfOl2wlJGBFBxxMzw==", "fd9419c6-f6a0-4a2f-95f0-345148d25f77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ecb4056-df63-4e1a-b617-a79fe484a04b", "AQAAAAEAACcQAAAAENfFgSQL7sn9IM9dYkYRU90dTuFoTpTBNSL/qP4ROac012HkRbktU6C/4kL9B1GE2Q==", "0a156c88-c8eb-46ac-817f-8c31bb3f9d16" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "ProjectId" },
                values: new object[,]
                {
                    { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "This is a very difficult project!", new DateTime(2024, 4, 16, 11, 0, 49, 941, DateTimeKind.Utc).AddTicks(4576), 1 },
                    { 2, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Pipe System made wonderful construction following the workshops. Great job!", new DateTime(2024, 3, 16, 11, 0, 49, 941, DateTimeKind.Utc).AddTicks(4580), 2 }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "AuthorId", "IsPositive", "ProjectId" },
                values: new object[,]
                {
                    { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", true, 1 },
                    { 2, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", true, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProjectId",
                table: "Comments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_AuthorId",
                table: "Rates",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ProjectId",
                table: "Rates",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Phases_PhaseId",
                table: "Projects",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Phases_PhaseId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Rates");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Phases_PhaseId",
                table: "Projects",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
