using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core
{
    public interface IModifier
    {
        ModifierTag Tags { get; }
    }

    public interface IItemModifier : IModifier
    {
        Affix Affix { get; }
        string Name { get; }
    }


    public interface IDamageModifier : IModifier
    {
        DamageType DamageType { get; }
    }

    public interface IItemDamageModifier : IItemModifier, IDamageModifier
    {
        Num Amount { get; }
    }

    public enum WeaponType
    {
        Sword,
        Axe,
        //Bow
    }

    public enum WeaponHandType
    {
        One,
        Two,
    }

    public interface IWeaponDamageModifier : IDamageModifier
    {
        WeaponType WeaponType { get; }
    }
}
