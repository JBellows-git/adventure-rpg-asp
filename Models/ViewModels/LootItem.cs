using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.ViewModels
{
    public class LootItem
    {
        public int LootItemID { get; set; }
        public Item Details { get; set; }
        public int DropRate { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }

        public LootItem() { }

        public LootItem(int lootItemID, Item details, int dropRate, int minQuantity, int maxQuantity)
        {
            LootItemID = lootItemID;
            Details = details;
            DropRate = dropRate;
            MinQuantity = minQuantity;
            MaxQuantity = maxQuantity;
        }
    }
}
