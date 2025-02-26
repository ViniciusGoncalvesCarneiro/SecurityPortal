using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GumAdvisor.Migrations
{
    public partial class Add_Iso_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Iso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Clause = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InformationSecurityControl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISO27001ControlDescription = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Iso", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iso");
        }
    }
}
