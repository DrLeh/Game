using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Modifiers
{
    public class ItemModifierCollection : ModifierCollection
    {
        public const int MaxPrefixes = 3;
        public const int MaxSuffixes = 3;

        public IEnumerable<IItemModifier> Prefixes => Modifiers.OfType<IItemModifier>().Where(x => x.Affix == Affix.Prefix);
        public IEnumerable<IItemModifier> Suffixes => Modifiers.OfType<IItemModifier>().Where(x => x.Affix == Affix.Suffix);

        public ItemModifierCollection(Rarity rarity, IEnumerable<IItemModifier> modifiers)
            : base(modifiers)
        {
            if (!ValidateModifiers(rarity, modifiers))
                throw new Exception("Invalid number of modifiers on item");
        }

        public static bool ValidateModifiers(Rarity rarity, IEnumerable<IItemModifier> modifiers)
        {
            switch (rarity)
            {
                case Rarity.Normal: return !modifiers.Any();
                case Rarity.Magic:
                    return modifiers.Count() <= 2 && modifiers.Count(x => x.Affix == Affix.Prefix) <= 1 && modifiers.Count(x => x.Affix == Affix.Suffix) <= 1;
                case Rarity.Rare:
                    return modifiers.Count() <= 2 && modifiers.Count(x => x.Affix == Affix.Prefix) <= 3 && modifiers.Count(x => x.Affix == Affix.Suffix) <= 3;
            }
            return true;
        }
    }
}
