using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Gems
{
    public class IncreasedFireDamageSupport : SupportGem
    {
        public override GemLevelSet LevelSet => new GemLevelSet();
        public override string Name => "Increased Fire Damage Support";
    }
}
