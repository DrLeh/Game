using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Modifiers;

namespace Game.Core.Items
{
    public abstract class Armor : SocketableEquipment, IItem, IEquipment
    {
        public ItemModifierCollection Modifiers { get; private set; }
        public abstract string Name { get; }
        public Rarity Rarity { get; set; }

        public Armor(Rarity rarity)
        {
            Rarity = rarity;
        }

        public Armor(Rarity rarity, ItemModifierCollection modifiers)
            : this(rarity)
        {
            Modifiers = modifiers;
        }
    }

    public abstract class Helmet : Armor
    {
        public Helmet(Rarity rarity) : base(rarity) { }
        public Helmet(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }
    }

    public abstract class Gloves : Armor
    {
        public Gloves(Rarity rarity) : base(rarity) { }
        public Gloves(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }
    }

    public abstract class Boots : Armor
    {
        public Boots(Rarity rarity) : base(rarity) { }
        public Boots(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }
    }

    public abstract class Chest : Armor
    {
        public Chest(Rarity rarity) : base(rarity) { }
        public Chest(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }
    }

    public abstract class Amulet : Armor
    {
        public Amulet(Rarity rarity) : base(rarity) { }
        public Amulet(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }
    }

    public abstract class Ring : Armor
    {
        public Ring(Rarity rarity) : base(rarity) { }
        public Ring(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }
    }
}
