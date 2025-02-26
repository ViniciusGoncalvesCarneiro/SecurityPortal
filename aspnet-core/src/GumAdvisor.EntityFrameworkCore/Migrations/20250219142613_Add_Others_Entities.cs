using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GumAdvisor.Migrations
{
    public partial class Add_Others_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CisToIso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CISControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CISSafeguard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISOIEC270012022 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CisToIso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CisToMitre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CISControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CISSafeguard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EnterpriseMitigationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CisToMitre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CisToNist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CISControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CISSafeguard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CisToNist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mitre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    MitreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StixId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipCitation = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Function = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Subcategory = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nist", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Iso_TenantId",
                table: "Iso",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CisToIso_TenantId",
                table: "CisToIso",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CisToMitre_TenantId",
                table: "CisToMitre",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CisToNist_TenantId",
                table: "CisToNist",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Mitre_TenantId",
                table: "Mitre",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Nist_TenantId",
                table: "Nist",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CisToIso");

            migrationBuilder.DropTable(
                name: "CisToMitre");

            migrationBuilder.DropTable(
                name: "CisToNist");

            migrationBuilder.DropTable(
                name: "Mitre");

            migrationBuilder.DropTable(
                name: "Nist");

            migrationBuilder.DropIndex(
                name: "IX_Iso_TenantId",
                table: "Iso");
        }
    }
}
