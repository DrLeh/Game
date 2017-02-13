using Game.Core.Items;
using Game.Core.Items.Armors.Amulets;
using Game.Core.Modifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Test
{
    [TestClass]
    public class EquipmentSetTest
    {
        [TestMethod]
        public void AllModifiersTest()
        {
            var modifiers = new List<IItemModifier>();
            var mockMod = new Mock<IItemDamageModifier>();
            mockMod.Setup(x => x.DamageType).Returns(DamageType.Chaos);
            mockMod.Setup(x => x.Amount).Returns(.1f);
            modifiers.Add(mockMod.Object);
            var mods = new ItemModifierCollection(Rarity.Magic, modifiers);

            var amulet = new JadeAmulet(Rarity.Magic, mods);

            var target = new EquipmentSet
            {
                Amulet = amulet,
            };

            var mod = target.AllModifiers.First();
            Assert.AreEqual(mockMod.Object, mod);
        }
    }
}
