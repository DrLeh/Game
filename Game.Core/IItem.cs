using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core
{
    public enum Rarity
    {
        Normal,
        Magic,
        Rare,
        Unique
    }

    //any item that can drop and be in inventory
    public interface IItem
    {
        ItemModifierCollection Modifiers { get; }
        string Name { get; }
    }

    
    //equiment item that can be equipped
    public interface IEquipment : IItem
    {
        Rarity Rarity { get; }
    }

    public interface ICurrency : IItem
    {

    }
}
