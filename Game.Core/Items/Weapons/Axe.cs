using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Items.Weapons
{
    public abstract class Axe : Weapon
    {
        public Axe(Rarity rarity) : base(rarity) { }
        public Axe(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }

        public override WeaponType WeaponType => WeaponType.Axe;
    }

    public class HandAxe : Axe
    {
        public HandAxe(Rarity rarity) : base(rarity) { }
        public HandAxe(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }

        public override string Name => "Hand Axe";
        public override WeaponHandType WeaponHandType => WeaponHandType.One;
    }

    public class LumberAxe : Axe
    {
        public LumberAxe(Rarity rarity) : base(rarity) { }
        public LumberAxe(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }

        public override string Name => "Hand Axe";
        public override WeaponHandType WeaponHandType => WeaponHandType.Two;
    }
}
