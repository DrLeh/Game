using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Items.Weapons
{
    public abstract class Sword : Weapon
    {
        public Sword(Rarity rarity) : base(rarity) { }
        public Sword(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }

        public override WeaponType WeaponType => WeaponType.Sword;
    }

    public class ShortSword : Sword
    {
        public ShortSword(Rarity rarity) : base(rarity) { }
        public ShortSword(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }

        public override string Name => "Short Sword";
        public override WeaponHandType WeaponHandType => WeaponHandType.One;
    }
}
