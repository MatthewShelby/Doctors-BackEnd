using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctors.Migrations
{
    public partial class AddGenDTOs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    value = table.Column<string>(nullable: true),
                    Companyid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Serducts",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    owner = table.Column<string>(nullable: false),
                    serductType = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    subCategory = table.Column<string>(nullable: true),
                    shortDescription = table.Column<string>(nullable: true),
                    longDescription = table.Column<string>(nullable: true),
                    Companyid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serducts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SerductImages",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    imageType = table.Column<int>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    altText = table.Column<string>(nullable: false),
                    Serductid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerductImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_SerductImages_Serducts_Serductid",
                        column: x => x.Serductid,
                        principalTable: "Serducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    owner = table.Column<string>(nullable: false),
                    companyName = table.Column<string>(nullable: false),
                    companyShortBio = table.Column<string>(nullable: true),
                    companyLongBio = table.Column<string>(nullable: true),
                    profileImageid = table.Column<string>(nullable: true),
                    logoImageid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Companies_SerductImages_logoImageid",
                        column: x => x.logoImageid,
                        principalTable: "SerductImages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_SerductImages_profileImageid",
                        column: x => x.profileImageid,
                        principalTable: "SerductImages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_logoImageid",
                table: "Companies",
                column: "logoImageid");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_profileImageid",
                table: "Companies",
                column: "profileImageid");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_Companyid",
                table: "ContactInfos",
                column: "Companyid");

            migrationBuilder.CreateIndex(
                name: "IX_SerductImages_Serductid",
                table: "SerductImages",
                column: "Serductid");

            migrationBuilder.CreateIndex(
                name: "IX_Serducts_Companyid",
                table: "Serducts",
                column: "Companyid");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Companies_Companyid",
                table: "ContactInfos",
                column: "Companyid",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Serducts_Companies_Companyid",
                table: "Serducts",
                column: "Companyid",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_SerductImages_logoImageid",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_SerductImages_profileImageid",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "SerductImages");

            migrationBuilder.DropTable(
                name: "Serducts");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
