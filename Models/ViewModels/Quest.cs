using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.ViewModels
{
    public class Quest
    {
        public int QuestID { get; set; }
        public String QuestName { get; set; }
        public String QuestDescription { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public Item RewardItem { get; set; }
        public QuestCompletionItem QuestCompletionItem { get; set; }

        public Quest() { }

        public Quest(int questID, string questName, string questDescription, int rewardExperiencePoints, int rewardGold, Item rewardItem, QuestCompletionItem questCompletionItem)
        {
            QuestID = questID;
            QuestName = questName;
            QuestDescription = questDescription;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
            QuestCompletionItem = questCompletionItem;
        }
    }
}
