using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e2e.Migrations
{
    /// <inheritdoc />
    public partial class addMasterDocumentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AreaDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Areas__70B82028B6F45229", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "CampaignStatuses",
                columns: table => new
                {
                    CampaignStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignStatusName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CampaignStatusDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Campaign__165A0AB352BAC524", x => x.CampaignStatusID);
                });

            migrationBuilder.CreateTable(
                name: "CampaignTypes",
                columns: table => new
                {
                    CampaignTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignTypeName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CampaignTypeDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Campaign__68FE2790011D084F", x => x.CampaignTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ProductsServices",
                columns: table => new
                {
                    ProductServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductServiceName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ProductServiceDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__A4EAC406D795E2E3", x => x.ProductServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ProfileDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profiles__290C8884B2E42582", x => x.ProfileID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    AreaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FailedAttemps = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    LastPasswordUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCACD3D55106", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CampaignTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductServiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Campaign__3F5E8D7944FFED52", x => x.CampaignID);
                    table.ForeignKey(
                        name: "FK__Campaigns__Campa__59FA5E80",
                        column: x => x.CampaignTypeID,
                        principalTable: "CampaignTypes",
                        principalColumn: "CampaignTypeID");
                    table.ForeignKey(
                        name: "FK__Campaigns__Produ__5AEE82B9",
                        column: x => x.ProductServiceID,
                        principalTable: "ProductsServices",
                        principalColumn: "ProductServiceID");
                    table.ForeignKey(
                        name: "FK__Campaigns__Statu__5BE2A6F2",
                        column: x => x.StatusID,
                        principalTable: "CampaignStatuses",
                        principalColumn: "CampaignStatusID");
                });

            migrationBuilder.CreateTable(
                name: "MasterDocument",
                columns: table => new
                {
                    CampaignID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MasterDo__3F5E8D79CDA3F592", x => x.CampaignID);
                    table.ForeignKey(
                        name: "FK__MasterDoc__Campa__08B54D69",
                        column: x => x.CampaignID,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignID");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantDetails",
                columns: table => new
                {
                    DetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    CampaignID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParticipantSectionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TitleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Particip__135C316D9A2DF9D8", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK__Participa__Campa__2A164134",
                        column: x => x.CampaignID,
                        principalTable: "MasterDocument",
                        principalColumn: "CampaignID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Areas__8EB6AF57CB0732C7",
                table: "Areas",
                column: "AreaName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignTypeID",
                table: "Campaigns",
                column: "CampaignTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ProductServiceID",
                table: "Campaigns",
                column: "ProductServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_StatusID",
                table: "Campaigns",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDetails_CampaignID",
                table: "ParticipantDetails",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "UQ__Profiles__A8A4D470F56649AE",
                table: "Profiles",
                column: "ProfileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__8D663598E3C4AFE5",
                table: "User",
                column: "EmployeeNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "ParticipantDetails");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MasterDocument");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "CampaignTypes");

            migrationBuilder.DropTable(
                name: "ProductsServices");

            migrationBuilder.DropTable(
                name: "CampaignStatuses");
        }
    }
}
