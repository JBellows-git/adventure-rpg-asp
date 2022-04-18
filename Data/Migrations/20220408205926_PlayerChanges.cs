using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class PlayerChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentArmorItemID",
                table: "PlayerCharacters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentWeaponItemID",
                table: "PlayerCharacters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_CurrentArmorItemID",
                table: "PlayerCharacters",
                column: "CurrentArmorItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_CurrentWeaponItemID",
                table: "PlayerCharacters",
                column: "CurrentWeaponItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_Items_CurrentArmorItemID",
                table: "PlayerCharacters",
                column: "CurrentArmorItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_Items_CurrentWeaponItemID",
                table: "PlayerCharacters",
                column: "CurrentWeaponItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_Items_CurrentArmorItemID",
                table: "PlayerCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_Items_CurrentWeaponItemID",
                table: "PlayerCharacters");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacters_CurrentArmorItemID",
                table: "PlayerCharacters");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacters_CurrentWeaponItemID",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "CurrentArmorItemID",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "CurrentWeaponItemID",
                table: "PlayerCharacters");
        }
    }
}
