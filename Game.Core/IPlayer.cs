using Game.Core.Items;
using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core
{
    public interface IPlayer : IEntity
    {
    }

    public interface IEntity
    {
        int Level { get; set; }

        int HP { get; set; }
        int MaxHP { get; set; }
        int MP { get; set; }
        int MaxMP { get; set; }
    }

    public interface IEnemy : IEntity
    {

    }

    public class Player : IPlayer
    {
        public string AccountName { get; set; } //FK
        public string CharacterName { get; set; }

        public int Level { get; set; }
        public int XP { get; set; }

        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int MP { get; set; }
        public int MaxMP { get; set; }

        public EquipmentSet EquipmentSet { get; set; }

        public List<IModifier> SkillTreeModifiers { get; set; }
        public IEnumerable<IModifier> GlobalModifiers => (SkillTreeModifiers ?? new List<IModifier>()).Concat(EquipmentSet.AllModifiers);
    }

    public class EquipmentSet
    {
        public Weapon MainHand { get; set; }
        public Weapon OffHand { get; set; }

        public Helmet Helmet { get; set; }
        public Chest Chest { get; set; }
        public Boots Boots { get; set; }
        public Gloves Gloves { get; set; }
        public Amulet Amulet { get; set; }

        public Ring RightRing { get; set; }
        public Ring LeftRing { get; set; }

        public IEnumerable<IModifier> AllModifiers => ModifierFilterExtensions.Concat(MainHand, OffHand, Helmet, Chest, Boots, Gloves, Amulet, RightRing, LeftRing);
    }

}
