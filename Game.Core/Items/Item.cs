using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Items
{
    public enum MajorItemType
    {
        Weapon,
        Armor,
        Currency,
    }

    public abstract class Item : IItem
    {
        public ItemModifierCollection Modifiers { get; set; }

        public string Name { get; set; }
        
        public Rarity Rarity { get; set; }
    }
}
