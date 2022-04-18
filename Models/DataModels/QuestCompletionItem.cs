using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.DataModels
{
    public class QuestCompletionItem
    {
        public int QuestCompletionItemID { get; set; }
        public Item details { get; set; }
        public int quantity { get; set; }

        public QuestCompletionItem() {  }

        public QuestCompletionItem(int questCompletionItemID, Item details, int quantity)
        {
            this.QuestCompletionItemID = questCompletionItemID;
            this.details = details;
            this.quantity = quantity;
        }
    }
}
