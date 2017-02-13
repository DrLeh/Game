using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Modifiers;

namespace Game.Core.Items
{
    public abstract class Weapon : SocketableEquipment, IItem, IEquipment
    {
        public ItemModifierCollection Modifiers { get; set; }
        public abstract string Name { get; }
        public Rarity Rarity { get; private set; }

        public abstract WeaponType WeaponType { get; }
        public abstract WeaponHandType WeaponHandType { get; }

        public Weapon(Rarity rarity)
        {
            Rarity = rarity;
        }

        public Weapon(Rarity rarity, ItemModifierCollection modifiers)
            : this(rarity)
        {
            Modifiers = modifiers;
        }
    }

}
