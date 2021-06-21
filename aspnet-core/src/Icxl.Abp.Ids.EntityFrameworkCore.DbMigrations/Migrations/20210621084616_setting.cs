using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Icxl.Abp.Ids.Migrations
{
    public partial class setting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test.ChurchSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChurchSettingName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NodesMaxIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test.ChurchSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test.ChurchSettingNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChurchSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test.ChurchSettingNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test.ChurchSettingNode_Test.ChurchSetting_ChurchSettingId",
                        column: x => x.ChurchSettingId,
                        principalTable: "Test.ChurchSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Test.ChurchSettingNode_ChurchSettingId",
                table: "Test.ChurchSettingNode",
                column: "ChurchSettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test.ChurchSettingNode");

            migrationBuilder.DropTable(
                name: "Test.ChurchSetting");
        }
    }
}
