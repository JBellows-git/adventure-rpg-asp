using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class LootTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LootItems",
                columns: table => new
                {
                    LootItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailsItemID = table.Column<int>(type: "int", nullable: true),
                    DropRate = table.Column<int>(type: "int", nullable: false),
                    MinQuantity = table.Column<int>(type: "int", nullable: false),
                    MaxQuantity = table.Column<int>(type: "int", nullable: false),
                    EnemyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootItems", x => x.LootItemID);
                    table.ForeignKey(
                        name: "FK_LootItems_Enemies_EnemyID",
                        column: x => x.EnemyID,
                        principalTable: "Enemies",
                        principalColumn: "EnemyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LootItems_Items_DetailsItemID",
                        column: x => x.DetailsItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LootItems_DetailsItemID",
                table: "LootItems",
                column: "DetailsItemID");

            migrationBuilder.CreateIndex(
                name: "IX_LootItems_EnemyID",
                table: "LootItems",
                column: "EnemyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LootItems");
        }
    }
}
