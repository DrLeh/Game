using Game.Core.Items.Generation;
using Game.Core.Items.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Test.ItemGeneration
{
    [TestClass]
    public class WeaponGeneratorTest
    {
        [TestMethod]
        public void WeaponGenTest()
        {
            var target = new WeaponGenerator();

            var type = target.PickType<Sword>();

            Assert.IsTrue(typeof(Sword).IsAssignableFrom(type));
        }

        [TestMethod]
        public void WeaponGenTest_Specific()
        {
            var target = new WeaponGenerator();

            var type = target.PickType<ShortSword>();

            Assert.IsTrue(typeof(ShortSword) == type);
        }

        [TestMethod]
        public void WeaponGen_CreateType_Specific()
        {
            var target = new WeaponGenerator();

            var sword = target.CreateType<ShortSword>();

            Assert.IsTrue(sword is ShortSword);
        }

        [TestMethod]
        public void WeaponGen_CreateType_Generic()
        {
            var target = new WeaponGenerator();

            var sword = target.CreateType<Sword>();

            Assert.IsTrue(typeof(Sword).IsAssignableFrom(sword.GetType()));
        }
    }
}
