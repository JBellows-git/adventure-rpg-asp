using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureProject.Data.Migrations
{
    public partial class QuestCompletionItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestCompletionItem_Items_detailsItemID",
                table: "QuestCompletionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_QuestCompletionItem_QuestCompletionItemID",
                table: "Quests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestCompletionItem",
                table: "QuestCompletionItem");

            migrationBuilder.RenameTable(
                name: "QuestCompletionItem",
                newName: "QuestCompletionItems");

            migrationBuilder.RenameIndex(
                name: "IX_QuestCompletionItem_detailsItemID",
                table: "QuestCompletionItems",
                newName: "IX_QuestCompletionItems_detailsItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestCompletionItems",
                table: "QuestCompletionItems",
                column: "QuestCompletionItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestCompletionItems_Items_detailsItemID",
                table: "QuestCompletionItems",
                column: "detailsItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_QuestCompletionItems_QuestCompletionItemID",
                table: "Quests",
                column: "QuestCompletionItemID",
                principalTable: "QuestCompletionItems",
                principalColumn: "QuestCompletionItemID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestCompletionItems_Items_detailsItemID",
                table: "QuestCompletionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_QuestCompletionItems_QuestCompletionItemID",
                table: "Quests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestCompletionItems",
                table: "QuestCompletionItems");

            migrationBuilder.RenameTable(
                name: "QuestCompletionItems",
                newName: "QuestCompletionItem");

            migrationBuilder.RenameIndex(
                name: "IX_QuestCompletionItems_detailsItemID",
                table: "QuestCompletionItem",
                newName: "IX_QuestCompletionItem_detailsItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestCompletionItem",
                table: "QuestCompletionItem",
                column: "QuestCompletionItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestCompletionItem_Items_detailsItemID",
                table: "QuestCompletionItem",
                column: "detailsItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_QuestCompletionItem_QuestCompletionItemID",
                table: "Quests",
                column: "QuestCompletionItemID",
                principalTable: "QuestCompletionItem",
                principalColumn: "QuestCompletionItemID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
