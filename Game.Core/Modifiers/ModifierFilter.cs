using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers
{
    public static class ModifierFilterExtensions
    {
        public static IEnumerable<IModifier> DamageType(this IEnumerable<IModifier> modifiers, DamageType type)
        {
            return modifiers.OfType<IDamageModifier>().Where(x => x.DamageType == type);
        }

        public static IEnumerable<IModifier> WeaponType(this IEnumerable<IModifier> modifiers, WeaponType type)
        {
            return modifiers.OfType<IWeaponDamageModifier>().Where(x => x.WeaponType == type);
        }

        public static IEnumerable<IModifier> Concat(params IItem[] items)
        {
            foreach (var item in items.Where(x => x != null))
                foreach (var mod in item.Modifiers.Modifiers)
                    yield return mod;
        }
    }
}
