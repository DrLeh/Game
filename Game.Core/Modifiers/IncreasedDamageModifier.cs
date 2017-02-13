using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers
{
    public abstract class IncreasedDamageModifier : IModifier
    {
        public abstract DamageType DamageType { get; }

        public Num Amount { get; private set; }

        public ModifierTag Tags => ModifierTag.None;

        public IncreasedDamageModifier(Num amount)
        {
            Amount = amount;
        }
    }
}
