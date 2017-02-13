using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core
{
    public static class ItemNameGenerator
    {
        public static string GetName(IEquipment item)
        {
            switch (item.Rarity)
            {
                case Rarity.Normal:
                case Rarity.Unique:
                    return item.Name;
                case Rarity.Magic:
                    return GetMagicItemName(item);
                case Rarity.Rare:
                    return GetRareItemName(item);
            }
            throw new Exception("Invalid Item");
        }

        private static string GetMagicItemName(IEquipment item)
        {
            var prefix = item.Modifiers.Prefixes.FirstOrDefault()?.Name;
            var suffix = item.Modifiers.Suffixes.FirstOrDefault()?.Name;

            var prefixTrail = prefix == null ? "" : " ";
            var suffixLead = suffix == null ? "" : " of ";

            return $"{prefix}{prefixTrail}{item.Name}{suffixLead}{suffix}";
        }

        private static string GetRareItemName(IEquipment item)
        {
            return $"Death Kill"; //code magic goes here
        }
    }
}
