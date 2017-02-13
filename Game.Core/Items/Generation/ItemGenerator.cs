using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Items.Generation
{
    public class ItemGenerator
    {

        public List<Type> ItemAffixTypes { get; set; }

        public ItemGenerator()
        {

        }

        public IItem GenerateItem()
        {
            var itemType = Rng.Instance.NextEnum<MajorItemType>();

            switch (itemType)
            {
                case MajorItemType.Armor: return GenerateArmor();
                case MajorItemType.Weapon: return GenerateArmor();

            }

            IItem ret = null;
            return ret;
        }

        public IItem GenerateArmor()
        {
            return null;
        }

        public Weapon GenerateWeapon()
        {
            return new WeaponGenerator().Generate();
        }
    }
}
