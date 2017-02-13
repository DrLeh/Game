using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers
{
    public class ModifierApplicator
    {
        public static IEnumerable<IModifier> GetRelevantFilters(IAbility ability, IEnumerable<IModifier> modifiers)
        {
            var taggedModifiers = modifiers.Where(x => AnyFlagsSet(ability.Tags, x.Tags));
            var damageType = modifiers.DamageType(ability.DamageType);
            return taggedModifiers
                .Concat(damageType)
                .Distinct()
                ;
        }

        private static bool AnyFlagsSet(ModifierTag required, ModifierTag set)
        {
            var toCheck = Enum.GetValues(typeof(ModifierTag)) as IEnumerable<ModifierTag>;
            foreach (Enum value in toCheck.Where(x => required.HasFlag(x) && x != ModifierTag.None))
                if (set.HasFlag(value))
                    return true;

            return false;
        }
    }
}
