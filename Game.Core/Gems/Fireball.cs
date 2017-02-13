using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Gems
{
    public class FireballGem : ActiveGem
    {
        public override IAbility Ability => new FireBall();
        public override GemLevelSet LevelSet => new GemLevelSet();
        public override string Name => "Fireball";
    }

    public class FireBall : Ability, IProjectile
    {
        public FireBall()
        {
            BaseDamage = 10;
        }

        public override ModifierTag Tags => ModifierTag.Aoe;
        public override DamageType DamageType => DamageType.Fire;
    }
}
