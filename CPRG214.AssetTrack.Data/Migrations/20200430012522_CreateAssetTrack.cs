using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG214.AssetTrack.Data.Migrations
{
    public partial class CreateAssetTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<string>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Computer" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Monitor" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Phone" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[] { 2, 1, "Description-A2-02", "HP", "Model-A2-02", "SN-A2-02", "Tag-A2-02" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[] { 1, 2, "Description-B1-01", "Acer", "Model-B1-01", "SN-B1-01", "Tag-B1-01" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[] { 3, 3, "Description-C3-03", "Cisco", "Model-C3-03", "SN-C3-03", "Tag-C3-03" });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeId",
                table: "Asset",
                column: "AssetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AssetType");
        }
    }
}
