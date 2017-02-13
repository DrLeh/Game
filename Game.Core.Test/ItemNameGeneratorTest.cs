using System;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Game.Core.Modifiers;
using System.Collections.Generic;
using Game.Core.Modifiers.Item;
using Game.Core.Modifiers.Elemental;

namespace Game.Core.Test
{
    [TestClass]
    public class ItemNameGeneratorTest
    {
        [TestMethod]
        public void Magic_Name()
        {
            var item = new Mock<IEquipment>();
            item.SetupGet(x => x.Name).Returns("Tribal Axe");
            item.SetupGet(x => x.Rarity).Returns(Rarity.Magic);
            item.SetupGet(x => x.Modifiers).Returns(new ItemModifierCollection(item.Object.Rarity, new List<IItemModifier>
            {
                new IncreasedFireDamageModifier(50),
                new MoreFireDamageModifier(50)
            }));

            Assert.AreEqual("Fiery Tribal Axe of Engulfing", ItemNameGenerator.GetName(item.Object));
        }
    }
}
