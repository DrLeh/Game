using Game.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers
{
    public class ModifierCollection
    {
        List<IModifier> _modifiers;
        public ModifierCollection(IEnumerable<IModifier> modifiers)
        {
            _modifiers = modifiers.ToList();
            ValidateModifiers(_modifiers);
        }

        public IEnumerable<IModifier> Modifiers => _modifiers;

        public void Add(IModifier mod)
        {
            _modifiers.Add(mod);
        }

        public void Remove(IModifier mod)
        {
            _modifiers.Remove(mod);
        }

        public IEnumerable<IModifier> ByDamageType(DamageType type) => _modifiers.DamageType(type);

        private static DamageCalculator GetDamageCalculator_Internal(IEnumerable<IModifier> modifiers)
        {
            return new DamageCalculator
            {
                Base = 1,
                Increased = modifiers.OfType<IncreasedDamageModifier>().Sum(y => y.Amount),
                More = modifiers.OfType<MoreDamageModifier>().Select(y => y.Amount).ToList(),
            };
        }


        public DamageCalculator GetDamageCalculator() => GetDamageCalculator_Internal(_modifiers);
        public DamageCalculator GetDamageCalculator(DamageType type) => GetDamageCalculator_Internal(ByDamageType(type));
        
        public static void ValidateModifiers(IEnumerable<IModifier> modifiers)
        {
            if (modifiers.Count() != modifiers.Select(x => x.GetType()).Distinct().Count()) //one affix of each type allowed
                throw new DuplicateModifierException();
                            
        }
    }
}
