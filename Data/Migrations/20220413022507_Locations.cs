using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class Locations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemRequiredToEnterItemID = table.Column<int>(type: "int", nullable: true),
                    QuestAvailableHereQuestID = table.Column<int>(type: "int", nullable: true),
                    EnemyFightHereEnemyID = table.Column<int>(type: "int", nullable: true),
                    LocationToNorth = table.Column<int>(type: "int", nullable: false),
                    LocationToSouth = table.Column<int>(type: "int", nullable: false),
                    LocationToEast = table.Column<int>(type: "int", nullable: false),
                    LocationToWest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_Enemies_EnemyFightHereEnemyID",
                        column: x => x.EnemyFightHereEnemyID,
                        principalTable: "Enemies",
                        principalColumn: "EnemyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Items_ItemRequiredToEnterItemID",
                        column: x => x.ItemRequiredToEnterItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Quests_QuestAvailableHereQuestID",
                        column: x => x.QuestAvailableHereQuestID,
                        principalTable: "Quests",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EnemyFightHereEnemyID",
                table: "Locations",
                column: "EnemyFightHereEnemyID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ItemRequiredToEnterItemID",
                table: "Locations",
                column: "ItemRequiredToEnterItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_QuestAvailableHereQuestID",
                table: "Locations",
                column: "QuestAvailableHereQuestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
