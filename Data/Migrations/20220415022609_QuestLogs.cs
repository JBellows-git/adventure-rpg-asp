using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class QuestLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestLogs",
                columns: table => new
                {
                    QuestLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerCharacterID = table.Column<int>(type: "int", nullable: true),
                    CollectedQuestQuestID = table.Column<int>(type: "int", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestLogs", x => x.QuestLogID);
                    table.ForeignKey(
                        name: "FK_QuestLogs_PlayerCharacters_PlayerCharacterID",
                        column: x => x.PlayerCharacterID,
                        principalTable: "PlayerCharacters",
                        principalColumn: "PlayerCharacterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestLogs_Quests_CollectedQuestQuestID",
                        column: x => x.CollectedQuestQuestID,
                        principalTable: "Quests",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestLogs_CollectedQuestQuestID",
                table: "QuestLogs",
                column: "CollectedQuestQuestID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestLogs_PlayerCharacterID",
                table: "QuestLogs",
                column: "PlayerCharacterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestLogs");
        }
    }
}
