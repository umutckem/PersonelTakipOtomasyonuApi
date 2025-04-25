using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelTakipOtomasyonuApı.Migrations
{
    /// <inheritdoc />
    public partial class PersonelOtomasyonu_V11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aktifMi",
                table: "personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "yıllıkİzinHakkı",
                table: "personels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aktifMi",
                table: "personels");

            migrationBuilder.DropColumn(
                name: "yıllıkİzinHakkı",
                table: "personels");
        }
    }
}
