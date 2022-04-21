using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.ViewModels
{
    public class Item
    {
        public int ItemID { get; set; }
        
        public String Name { get; set; }
        
        public String PluralName { get; set; }

        public Item() { }

        public Item(int itemID, string name, string pluralName)
        {
            ItemID = itemID;
            Name = name;
            PluralName = pluralName;
        }
    }
}
