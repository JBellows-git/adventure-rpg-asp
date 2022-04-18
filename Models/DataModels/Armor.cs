using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.DataModels
{
    public class Armor : Item
    {
        public int DamageReduction { get; set; }

        public Armor() : base() { }

        public Armor(int itemID, String name, String pluralName, int damageReduction) : base(itemID, name, pluralName)
        {
            DamageReduction = damageReduction;
        }
    }
}
