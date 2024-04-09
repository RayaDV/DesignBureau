﻿// <auto-generated />
using System;
using DesignBureau.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesignBureau.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DesignBureauDbContext))]
    partial class DesignBureauDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FacebookPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("User Facebook Page");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("User First Name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("User Last Name");

                    b.Property<string>("LinkedInPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("User LinkedIn Page");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkypeProfile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("User Skype Profile");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2f08c4b6-7afe-4bba-beaa-36d800c03e44",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "59109ffc-9d1f-402b-8e8e-624cb3f679cb",
                            Email = "raya@e.kroumov.com",
                            EmailConfirmed = false,
                            FacebookPage = "",
                            FirstName = "Raya",
                            LastName = "Dimitrova",
                            LinkedInPage = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "RAYA@E.KROUMOV.COM",
                            NormalizedUserName = "RAYA@E.KROUMOV.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDHcIxOR2ZXaPLduIJVaClRyLbxx6t814YzUmZURT7jL0Y4TgYpg1cXLBWFclTlj9Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ec79ceb9-48f8-4934-af9d-679525461841",
                            SkypeProfile = "",
                            TwoFactorEnabled = false,
                            UserName = "raya@e.kroumov.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ccdb3ef1-0c18-445c-bb51-631620cb7f1d",
                            Email = "dimitar@gmail.com",
                            EmailConfirmed = false,
                            FacebookPage = "",
                            FirstName = "Dimitar",
                            LastName = "Dimitrov",
                            LinkedInPage = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "DIMITAR@GMAIL.COM",
                            NormalizedUserName = "DIMITAR@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECCnRA6QvdAXjofY9EkpoWlcu4CkH0q4tl3ORPdo07YmL1RprXVF4ojoddaF/zF4Bw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1233fe1f-27d7-4b69-94f2-75ce506e6c85",
                            SkypeProfile = "",
                            TwoFactorEnabled = false,
                            UserName = "dimitar@gmail.com"
                        },
                        new
                        {
                            Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6083ae63-45e8-43d8-bceb-9f5e34005046",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FacebookPage = "",
                            FirstName = "Master",
                            LastName = "Admin",
                            LinkedInPage = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKxNbg55JVJnV3wM2OwJLSuvQXMuNGSXPXqfe5PR9nO/yRQNODatVuBeZbriedh2tQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3a84dd83-fdc6-4965-a6d1-c3e0de1c9e8c",
                            SkypeProfile = "",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Project category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "International Projects"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Public Buildings"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Office And Residential Buildings"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Commercial Buildings"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Industrial Buildings"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Family Houses"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Reconstructions And Rebuildings"
                        });
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Designer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Designer identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DesignExperience")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("Designer work experience in years");

                    b.Property<string>("DesignerImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Designer image URL");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int")
                        .HasComment("Discipline identifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Designer phone number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User identifier");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("UserId");

                    b.ToTable("Designers");

                    b.HasComment("Designer of a project");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DesignExperience = 13,
                            DesignerImageUrl = "https://localhost:7134/img/Designers/Raya.jpg",
                            DisciplineId = 2,
                            PhoneNumber = "+359883494948",
                            UserId = "2f08c4b6-7afe-4bba-beaa-36d800c03e44"
                        });
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Discipline identifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Discipline name");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");

                    b.HasComment("Designer discipline");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Architecture"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Structure"
                        },
                        new
                        {
                            Id = 4,
                            Name = "WS&S"
                        },
                        new
                        {
                            Id = 5,
                            Name = "HVAC"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Geodesy"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Landscaping"
                        });
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Image identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Project Image URL");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasComment("Project identifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Images");

                    b.HasComment("Project image");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://localhost:7134/img/ONYX/ONYX-02.jpg",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://localhost:7134/img/ONYX/ONYX-03.jpg",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://localhost:7134/img/SEG/SEG-02.jpg",
                            ProjectId = 2
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://localhost:7134/img/SEG/SEG-03.jpg",
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Phase", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Phase identifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Phase name");

                    b.HasKey("Id");

                    b.ToTable("Phases");

                    b.HasComment("Project phase");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Design"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Construction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Use"
                        },
                        new
                        {
                            Id = 4,
                            Name = "End Of Service"
                        });
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Project identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Architect")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Architect of the project");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Project country");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Project description");

                    b.Property<int>("DesignerId")
                        .HasColumnType("int")
                        .HasComment("Designer identifier");

                    b.Property<string>("MainImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Project main image URL");

                    b.Property<int>("PhaseId")
                        .HasColumnType("int")
                        .HasComment("Phase identifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Project title");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Project town");

                    b.Property<int>("YearDesigned")
                        .HasColumnType("int")
                        .HasComment("Project year of design");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DesignerId");

                    b.HasIndex("PhaseId");

                    b.ToTable("Projects");

                    b.HasComment("A project to describe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Architect = "ProArch",
                            CategoryId = 3,
                            Country = "Bulgaria",
                            Description = "Total Build Up Area: 12 236,60 m2. Structural design: monolithic reinforced concrete and steel structure. Post-tensioning of the RC plates above lvl.+14.500. At lvl.+11.000 the building is cantilevered over three X-shaped steel columns. 3-dimensional modelling of the structure with Revit Structure. 3D FEM Analysis model with Robot Structural Analysis. Workshop drawings of the steel structure.",
                            DesignerId = 1,
                            MainImageUrl = "https://localhost:7134/img/ONYX/ONYX-01.jpg",
                            PhaseId = 2,
                            Title = "Multi-purpose building ONYX",
                            Town = "Sofia",
                            YearDesigned = 2019
                        },
                        new
                        {
                            Id = 2,
                            Architect = "Ivo Petrov Architects",
                            CategoryId = 5,
                            Country = "Bulgaria",
                            Description = "Total Build Up Area: 5 632 m2. Structural design: monolithic reinforced concrete and steel structure with post-tensioned concrete floors. BIM modeling, 3-dimensional modelling of the structure with Revit Structure. Advanced building simulation and analysis with Robot Structural Analysis. Workshop drawings of the steel structure. Тhis building is a participant in The National Contest „Building Of The Year 2019“ and has won a special award in the „Manufacturing and Logistics Buildings” category.",
                            DesignerId = 1,
                            MainImageUrl = "https://localhost:7134/img/SEG/SEG-01.jpg",
                            PhaseId = 3,
                            Title = "Multi-purpose building SEG",
                            Town = "Krivina",
                            YearDesigned = 2018
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 3,
                            ClaimType = "user:fullname",
                            ClaimValue = "Master Admin",
                            UserId = "e43ce836-997d-4927-ac59-74e8c41bbfd3"
                        },
                        new
                        {
                            Id = 1,
                            ClaimType = "user:fullname",
                            ClaimValue = "Raya Dimitrova",
                            UserId = "2f08c4b6-7afe-4bba-beaa-36d800c03e44"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "user:fullname",
                            ClaimValue = "Dimitar Dimitrov",
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Designer", b =>
                {
                    b.HasOne("DesignBureau.Infrastructure.Data.Models.Discipline", "Discipline")
                        .WithMany("Designers")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DesignBureau.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Image", b =>
                {
                    b.HasOne("DesignBureau.Infrastructure.Data.Models.Project", "Project")
                        .WithMany("Images")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Project", b =>
                {
                    b.HasOne("DesignBureau.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Projects")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DesignBureau.Infrastructure.Data.Models.Designer", "Designer")
                        .WithMany("Projects")
                        .HasForeignKey("DesignerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DesignBureau.Infrastructure.Data.Models.Phase", "Phase")
                        .WithMany("Projects")
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Designer");

                    b.Navigation("Phase");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DesignBureau.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DesignBureau.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignBureau.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DesignBureau.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Designer", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Discipline", b =>
                {
                    b.Navigation("Designers");
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Phase", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DesignBureau.Infrastructure.Data.Models.Project", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
