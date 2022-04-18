using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.DataModels
{
    public class HealingPotion : Item
    {
        public int AmountToHeal { get; set; }

        public HealingPotion() : base() { }

        public HealingPotion(int itemID, String name, String pluralName, int amountToHeal) : base(itemID, name, pluralName)
        {
            AmountToHeal = amountToHeal;
        }
    }
}
