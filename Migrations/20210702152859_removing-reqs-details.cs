using Microsoft.EntityFrameworkCore.Migrations;

namespace Airbnb.Migrations
{
    public partial class removingreqsdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyGuestDetail");

            migrationBuilder.DropTable(
                name: "PropertyGuestRequirement");

            migrationBuilder.DropTable(
                name: "GuestsDetails");

            migrationBuilder.DropTable(
                name: "GuestRequirements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestsDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyGuestRequirement",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    GuestRequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyGuestRequirement", x => new { x.PropertyId, x.GuestRequirementId });
                    table.ForeignKey(
                        name: "FK_PropertyGuestRequirement_GuestRequirements_GuestRequirementId",
                        column: x => x.GuestRequirementId,
                        principalTable: "GuestRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyGuestRequirement_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyGuestDetail",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    GuestDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyGuestDetail", x => new { x.PropertyId, x.GuestDetailId });
                    table.ForeignKey(
                        name: "FK_PropertyGuestDetail_GuestsDetails_GuestDetailId",
                        column: x => x.GuestDetailId,
                        principalTable: "GuestsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyGuestDetail_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyGuestDetail_GuestDetailId",
                table: "PropertyGuestDetail",
                column: "GuestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyGuestRequirement_GuestRequirementId",
                table: "PropertyGuestRequirement",
                column: "GuestRequirementId");
        }
    }
}
