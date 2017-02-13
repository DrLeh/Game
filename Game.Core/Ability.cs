using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core
{
    public interface ITarget
    {

    }

    [Flags]
    public enum ModifierTag
    {
        None = 0,

        Aoe = 1,
        Movement = 1 << 1,
    }

    public interface IAbility
    {
        float BaseDamage { get; set; }
        float Damage { get; }
        List<IModifier> Modifiers { get; set; }
        ModifierTag Tags { get; }
        DamageType DamageType { get; }
}

    public interface IProjectile
    {

    }

    public enum Affix
    {
        Prefix,
        Suffix,
    }

    [Flags]
    public enum DamageType
    {
        Physical = 1,
        Cold = 1 << 1,
        Fire = 1 << 2,
        Lightning = 1 << 3,
        Chaos = 1 << 4,

        Elemental = Cold | Fire | Lightning,
    }


    public abstract class Ability : IAbility
    {

        public float IncreaseDamagePercent { get; set; }
        public List<float> MoreDamangePercents { get; set; }

        public float BaseDamage { get; set; }
        public float Damage
        {
            get
            {
                return new DamageCalculator
                {
                    Base = BaseDamage,

                }.CalcDamage();
            }
        }

        public List<IModifier> Modifiers { get; set; }
        public abstract ModifierTag Tags { get; }
        public abstract DamageType DamageType { get; }
    }

    public class ArbitraryAbility : Ability
    {
        public override DamageType DamageType => DamageType.Physical;
        public override ModifierTag Tags => ModifierTag.None;
    }
}
