using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class Quests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestCompletionItem",
                columns: table => new
                {
                    QuestCompletionItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detailsItemID = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestCompletionItem", x => x.QuestCompletionItemID);
                    table.ForeignKey(
                        name: "FK_QuestCompletionItem_Items_detailsItemID",
                        column: x => x.detailsItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RewardExperiencePoints = table.Column<int>(type: "int", nullable: false),
                    RewardGold = table.Column<int>(type: "int", nullable: false),
                    RewardItemItemID = table.Column<int>(type: "int", nullable: true),
                    QuestCompletionItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.QuestID);
                    table.ForeignKey(
                        name: "FK_Quests_Items_RewardItemItemID",
                        column: x => x.RewardItemItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quests_QuestCompletionItem_QuestCompletionItemID",
                        column: x => x.QuestCompletionItemID,
                        principalTable: "QuestCompletionItem",
                        principalColumn: "QuestCompletionItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestCompletionItem_detailsItemID",
                table: "QuestCompletionItem",
                column: "detailsItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_QuestCompletionItemID",
                table: "Quests",
                column: "QuestCompletionItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_RewardItemItemID",
                table: "Quests",
                column: "RewardItemItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "QuestCompletionItem");
        }
    }
}
