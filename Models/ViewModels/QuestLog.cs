using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.ViewModels
{
    public class QuestLog
    {
        public int QuestLogID { get; set; }
        public PlayerCharacter Player { get; set; }
        public Quest CollectedQuest { get; set; }
        public bool Completed { get; set; }

        public QuestLog()
        {
        }

        public QuestLog(int questLogID, PlayerCharacter player, Quest collectedQuest, bool completed)
        {
            QuestLogID = questLogID;
            Player = player;
            CollectedQuest = collectedQuest;
            Completed = completed;
        }
    }
}
