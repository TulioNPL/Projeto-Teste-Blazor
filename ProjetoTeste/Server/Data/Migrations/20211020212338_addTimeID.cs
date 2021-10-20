using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTeste.Server.Data.Migrations
{
    public partial class addTimeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Jogadores");

            migrationBuilder.AddColumn<int>(
                name: "TimesId",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_TimesId",
                table: "Jogadores",
                column: "TimesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Times_TimesId",
                table: "Jogadores",
                column: "TimesId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Times_TimesId",
                table: "Jogadores");

            migrationBuilder.DropIndex(
                name: "IX_Jogadores_TimesId",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "TimesId",
                table: "Jogadores");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Jogadores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
