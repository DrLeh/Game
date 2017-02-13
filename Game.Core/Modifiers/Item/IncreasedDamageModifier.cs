using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers.Item
{
    public abstract class IncreasedItemDamageModifier : IncreasedDamageModifier,  IItemDamageModifier
    {
        public abstract Affix Affix { get; }
        public abstract string Name { get; }

        public IncreasedItemDamageModifier(Num amount) : base(amount) { }
    }
}
