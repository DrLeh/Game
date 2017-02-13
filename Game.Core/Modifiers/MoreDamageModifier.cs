using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers
{
    public abstract class MoreDamageModifier : IModifier
    {
        public abstract DamageType DamageType { get; }
        public ModifierTag Tags => ModifierTag.None;

        public Num Amount { get; set; }

        public MoreDamageModifier(Num amount)
        {
            Amount = amount;
        }
    }
}
