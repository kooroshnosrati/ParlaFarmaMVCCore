using Microsoft.EntityFrameworkCore.Migrations;

namespace ParlaFarmaMVCCore.Data.Migrations
{
    public partial class addSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lang = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Title1 = table.Column<string>(nullable: true),
                    Title2 = table.Column<string>(nullable: true),
                    Title3 = table.Column<string>(nullable: true),
                    ButtonText = table.Column<string>(nullable: true),
                    ButtonLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Sliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Sliders");
        }
    }
}
