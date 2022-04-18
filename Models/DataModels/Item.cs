using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.DataModels
{
    public class Item
    {
        public int ItemID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
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
