using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Items.Armors.Amulets
{
    public class JadeAmulet : Amulet
    {
        public JadeAmulet(Rarity rarity) : base(rarity) { }
        public JadeAmulet(Rarity rarity, ItemModifierCollection modifiers) : base(rarity, modifiers) { }

        public override string Name => "Jade Amulet";
    }
}
