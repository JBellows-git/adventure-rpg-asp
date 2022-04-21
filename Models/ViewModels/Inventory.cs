using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.ViewModels
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public PlayerCharacter PlayerCharacter { get; set; }
        public Item Detail { get; set; }
        public int Quantity { get; set; }

        public Inventory() { }

        public Inventory(int inventoryID, PlayerCharacter playerCharacter, Item detail, int quantity)
        {
            InventoryID = inventoryID;
            PlayerCharacter = playerCharacter;
            Detail = detail;
            Quantity = quantity;
        }
    }
}
