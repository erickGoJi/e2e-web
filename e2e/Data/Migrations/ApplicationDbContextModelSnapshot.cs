﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using e2e.Data;

#nullable disable

namespace e2e.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("e2e.Data.ApplicationUser", b =>
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

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFirstAttempt")
                        .HasColumnType("bit");

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
                });

            modelBuilder.Entity("e2e.Model.Area", b =>
                {
                    b.Property<Guid>("AreaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AreaID");

                    b.Property<string>("AreaDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AreaId")
                        .HasName("PK__Areas__70B82028B6F45229");

                    b.HasIndex(new[] { "AreaName" }, "UQ__Areas__8EB6AF57CB0732C7")
                        .IsUnique();

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("e2e.Model.Campaign", b =>
                {
                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CampaignID");

                    b.Property<Guid>("CampaignTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CampaignTypeID");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("ProductServiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductServiceID");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StatusID");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("CampaignId")
                        .HasName("PK__Campaign__3F5E8D7944FFED52");

                    b.HasIndex("CampaignTypeId");

                    b.HasIndex("ProductServiceId");

                    b.HasIndex("StatusId");

                    b.ToTable("Campaigns", t =>
                        {
                            t.HasTrigger("TRG_UpdateTimestamp_On_Campaigns");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("e2e.Model.CampaignStatus", b =>
                {
                    b.Property<Guid>("CampaignStatusId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CampaignStatusID");

                    b.Property<string>("CampaignStatusDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CampaignStatusName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CampaignStatusId")
                        .HasName("PK__Campaign__165A0AB352BAC524");

                    b.ToTable("CampaignStatuses");
                });

            modelBuilder.Entity("e2e.Model.CampaignType", b =>
                {
                    b.Property<Guid>("CampaignTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CampaignTypeID");

                    b.Property<string>("CampaignTypeDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CampaignTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CampaignTypeId")
                        .HasName("PK__Campaign__68FE2790011D084F");

                    b.ToTable("CampaignTypes");
                });

            modelBuilder.Entity("e2e.Model.MasterDocument", b =>
                {
                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CampaignID");

                    b.Property<string>("DocumentStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CampaignId")
                        .HasName("PK__MasterDo__3F5E8D79CDA3F592");

                    b.ToTable("MasterDocument", (string)null);
                });

            modelBuilder.Entity("e2e.Model.ParticipantDetail", b =>
                {
                    b.Property<Guid>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CampaignID");

                    b.Property<string>("FieldType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FieldValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ParticipantSectionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TitleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DetailId")
                        .HasName("PK__Particip__135C316D9A2DF9D8");

                    b.HasIndex("CampaignId");

                    b.ToTable("ParticipantDetails");
                });

            modelBuilder.Entity("e2e.Model.ProductsService", b =>
                {
                    b.Property<Guid>("ProductServiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductServiceID");

                    b.Property<string>("ProductServiceDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProductServiceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ProductServiceId")
                        .HasName("PK__Products__A4EAC406D795E2E3");

                    b.ToTable("ProductsServices");
                });

            modelBuilder.Entity("e2e.Model.Profile", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProfileID");

                    b.Property<string>("ProfileDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProfileId")
                        .HasName("PK__Profiles__290C8884B2E42582");

                    b.HasIndex(new[] { "ProfileName" }, "UQ__Profiles__A8A4D470F56649AE")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("e2e.Model.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID");

                    b.Property<Guid?>("AreaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AreaID");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("FailedAttemps")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<DateTime?>("LastPasswordUpdated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProfileID");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CCACD3D55106");

                    b.HasIndex(new[] { "EmployeeNumber" }, "UQ__Users__8D663598E3C4AFE5")
                        .IsUnique();

                    b.ToTable("User", t =>
                        {
                            t.HasTrigger("TRG_UpdateTimestamp");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
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
                    b.HasOne("e2e.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("e2e.Data.ApplicationUser", null)
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

                    b.HasOne("e2e.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("e2e.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("e2e.Model.Campaign", b =>
                {
                    b.HasOne("e2e.Model.CampaignType", "CampaignType")
                        .WithMany("Campaigns")
                        .HasForeignKey("CampaignTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Campaigns__Campa__59FA5E80");

                    b.HasOne("e2e.Model.ProductsService", "ProductService")
                        .WithMany("Campaigns")
                        .HasForeignKey("ProductServiceId")
                        .IsRequired()
                        .HasConstraintName("FK__Campaigns__Produ__5AEE82B9");

                    b.HasOne("e2e.Model.CampaignStatus", "Status")
                        .WithMany("Campaigns")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK__Campaigns__Statu__5BE2A6F2");

                    b.Navigation("CampaignType");

                    b.Navigation("ProductService");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("e2e.Model.MasterDocument", b =>
                {
                    b.HasOne("e2e.Model.Campaign", "Campaign")
                        .WithOne("MasterDocument")
                        .HasForeignKey("e2e.Model.MasterDocument", "CampaignId")
                        .IsRequired()
                        .HasConstraintName("FK__MasterDoc__Campa__08B54D69");

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("e2e.Model.ParticipantDetail", b =>
                {
                    b.HasOne("e2e.Model.MasterDocument", "Campaign")
                        .WithMany("ParticipantDetails")
                        .HasForeignKey("CampaignId")
                        .IsRequired()
                        .HasConstraintName("FK__Participa__Campa__2A164134");

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("e2e.Model.Campaign", b =>
                {
                    b.Navigation("MasterDocument");
                });

            modelBuilder.Entity("e2e.Model.CampaignStatus", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("e2e.Model.CampaignType", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("e2e.Model.MasterDocument", b =>
                {
                    b.Navigation("ParticipantDetails");
                });

            modelBuilder.Entity("e2e.Model.ProductsService", b =>
                {
                    b.Navigation("Campaigns");
                });
#pragma warning restore 612, 618
        }
    }
}
