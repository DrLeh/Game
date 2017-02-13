using Game.Core.Modifiers.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers.Elemental
{
    public class FireDamageModifier : IDamageModifier
    {
        public DamageType DamageType => DamageType.Fire;

        public ModifierTag Tags => ModifierTag.None;
    }

    public class IncreasedFireDamageModifier : IncreasedItemDamageModifier
    {
        public IncreasedFireDamageModifier(Num amount) : base(amount) { }

        public override Affix Affix => Affix.Prefix;
        public override DamageType DamageType => DamageType.Fire;
        public override string Name => "Fiery";
    }

    public class MoreFireDamageModifier : MoreItemDamageModifier
    {
        public MoreFireDamageModifier(Num amount) : base(amount) { }

        public override Affix Affix => Affix.Suffix;
        public override DamageType DamageType => DamageType.Fire;
        public override string Name => "Engulfing";
    }
}
