using Game.Core.Modifiers.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers.Elemental
{
    public class ColdDamageModifier : IDamageModifier
    {
        public DamageType DamageType => DamageType.Cold;

        public ModifierTag Tags => ModifierTag.None;
    }

    public class IncreasedColdDamageModifier : IncreasedItemDamageModifier
    {
        public IncreasedColdDamageModifier(Num amount) : base(amount) { }

        public override Affix Affix => Affix.Prefix;
        public override DamageType DamageType => DamageType.Cold;
        public override string Name => "Chill";
    }

    public class MoreColdDamageModifier : MoreItemDamageModifier
    {
        public MoreColdDamageModifier(Num amount) : base(amount) { }

        public override Affix Affix => Affix.Suffix;
        public override DamageType DamageType => DamageType.Cold;
        public override string Name => "Freezing";
    }
}
