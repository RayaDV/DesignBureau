﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignBureau.Infrastructure.Data.Migrations
{
    public partial class InitialMigrationWithApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "User First Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "User Last Name"),
                    FacebookPage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Facebook Page"),
                    LinkedInPage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User LinkedIn Page"),
                    SkypeProfile = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Skype Profile"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Project category");

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Discipline identifier"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Discipline name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                },
                comment: "Designer discipline");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Designer identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Designer phone number"),
                    DesignExperience = table.Column<int>(type: "int", nullable: false, comment: "Designer work experience in years"),
                    DesignerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Designer image URL"),
                    DisciplineId = table.Column<int>(type: "int", nullable: false, comment: "Discipline identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Designers_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Designer of a project");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Project identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Project title"),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Project country"),
                    Town = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Project town"),
                    MainImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Project main image URL"),
                    Architect = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Architect of the project"),
                    Phase = table.Column<int>(type: "int", nullable: false, comment: "Project phase"),
                    YearDesigned = table.Column<int>(type: "int", nullable: false, comment: "Project year of design"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Project description"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    DesignerId = table.Column<int>(type: "int", nullable: false, comment: "Designer identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Designers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "Designers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "A project to describe");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Image identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Project Image URL"),
                    ProjectId = table.Column<int>(type: "int", nullable: false, comment: "Project identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Project image");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookPage", "FirstName", "LastName", "LinkedInPage", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SkypeProfile", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2ebb7ac0-f9b8-4067-a775-97db2b221a0b", 0, "3c434882-dc92-4e41-8012-d40c6b194435", "dimitar@mail.com", false, "", "Dimitar", "Dimitrov", "", false, null, "DIMITAR@MAIL.COM", "DIMITAR@MAIL.COM", "AQAAAAEAACcQAAAAECmPY+UEBohLdL43xyefUy0fZ+BjLqaIwWlKwNrZojbQhYAfXllxdnzs4121dF8ShA==", null, false, "6714d114-8a12-439a-aad3-71f2d0acb0db", "", false, "dimitar@mail.com" },
                    { "2f08c4b6-7afe-4bba-beaa-36d800c03e44", 0, "e9e4c0e9-e72c-49b2-a405-f5c4e891f015", "raya@e.kroumov.com", false, "", "Raya", "Dimitrova", "", false, null, "RAYA@E.KROUMOV.COM", "RAYA@E.KROUMOV.COM", "AQAAAAEAACcQAAAAEPzOIpjm1W8Bb3j05IbFGOOqPrPoRok0I+Q46G7sGbggK6iGj25lJRZJZGEVDWeSqQ==", null, false, "107c9355-cb01-4519-b98e-c73b55c3764f", "", false, "raya@e.kroumov.com" }
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
                columns: new[] { "Id", "DesignExperience", "DesignerImageUrl", "DisciplineId", "PhoneNumber", "UserId" },
                values: new object[] { 1, 13, "https://localhost:7134/img/Designers/Raya.jpg", 2, "+359883494948", "2f08c4b6-7afe-4bba-beaa-36d800c03e44" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Architect", "CategoryId", "Country", "Description", "DesignerId", "MainImageUrl", "Phase", "Title", "Town", "YearDesigned" },
                values: new object[] { 1, "ProArch", 3, "Bulgaria", "Total Build Up Area: 12 236,60 m2. Structural design: monolithic reinforced concrete and steel structure. Post-tensioning of the RC plates above lvl.+14.500. At lvl.+11.000 the building is cantilevered over three X-shaped steel columns. 3-dimensional modelling of the structure with Revit Structure. 3D FEM Analysis model with Robot Structural Analysis. Workshop drawings of the steel structure.", 1, "https://localhost:7134/img/ONYX/ONYX-01.jpg", 2, "Multi-purpose building ONYX", "Sofia", 2019 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Architect", "CategoryId", "Country", "Description", "DesignerId", "MainImageUrl", "Phase", "Title", "Town", "YearDesigned" },
                values: new object[] { 2, "Ivo Petrov Architects", 5, "Bulgaria", "Total Build Up Area: 5 632 m2. Structural design: monolithic reinforced concrete and steel structure with post-tensioned concrete floors. BIM modeling, 3-dimensional modelling of the structure with Revit Structure. Advanced building simulation and analysis with Robot Structural Analysis. Workshop drawings of the steel structure. Тhis building is a participant in The National Contest „Building Of The Year 2019“ and has won a special award in the „Manufacturing and Logistics Buildings” category.", 1, "https://localhost:7134/img/SEG/SEG-01.jpg", 3, "Multi-purpose building SEG", "Krivina", 2018 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageUrl", "ProjectId" },
                values: new object[,]
                {
                    { 1, "https://localhost:7134/img/ONYX/ONYX-02.jpg", 1 },
                    { 2, "https://localhost:7134/img/ONYX/ONYX-03.jpg", 1 },
                    { 3, "https://localhost:7134/img/SEG/SEG-02.jpg", 2 },
                    { 4, "https://localhost:7134/img/SEG/SEG-03.jpg", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_DisciplineId",
                table: "Designers",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_UserId",
                table: "Designers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProjectId",
                table: "Images",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DesignerId",
                table: "Projects",
                column: "DesignerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Disciplines");
        }
    }
}