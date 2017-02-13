using Game.Core.Exceptions;
using Game.Core.Modifiers;
using Game.Core.Modifiers.Elemental;
using Game.Core.Modifiers.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Test.Modifiers
{
    [TestClass]
    public class ModifierCollectionTest
    {
        [TestMethod]
        public void DuplicateModifer()
        {
            var modifiers = new List<IModifier>();
            modifiers.Add(new IncreasedFireDamageModifier(1));
            modifiers.Add(new IncreasedFireDamageModifier(1));

            bool failed = false;
            try
            {
                var coll = new ModifierCollection(modifiers);
                Assert.Fail();
            }
            catch (DuplicateModifierException)
            {
                failed = true;
            }
            Assert.IsTrue(failed);
        }

        [TestMethod]
        public void Filter_DamageType()
        {
            var modifiers = new List<IModifier>();
            
            var mod = new Mock<IDamageModifier>();
            mod.Setup(x => x.DamageType).Returns(DamageType.Fire);
            modifiers.Add(mod.Object);

            var mod2 = new Mock<IDamageModifier>();
            mod2.Setup(x => x.DamageType).Returns(DamageType.Cold);
            modifiers.Add(mod2.Object);


            Assert.AreEqual(1, modifiers.DamageType(DamageType.Fire).Count());
            Assert.AreEqual(1, modifiers.DamageType(DamageType.Cold).Count());
        }

        [TestMethod]
        public void Filter_WeaponType()
        {
            var modifiers = new List<IModifier>();

            var mod = new Mock<IWeaponDamageModifier>();
            mod.Setup(x => x.WeaponType).Returns(WeaponType.Axe);
            modifiers.Add(mod.Object);

            var mod2 = new Mock<IWeaponDamageModifier>();
            mod2.Setup(x => x.WeaponType).Returns(WeaponType.Sword);
            modifiers.Add(mod2.Object);


            Assert.AreEqual(1, modifiers.WeaponType(WeaponType.Axe).Count());
            Assert.AreEqual(1, modifiers.WeaponType(WeaponType.Sword).Count());
        }

        [TestMethod]
        public void Filter_DamageType_Multiple()
        {
            var modifiers = new List<IModifier>();

            var mod = new Mock<IDamageModifier>();
            mod.Setup(x => x.DamageType).Returns(DamageType.Fire);
            modifiers.Add(mod.Object);
            var mod2 = new Mock<IDamageModifier>();
            mod2.Setup(x => x.DamageType).Returns(DamageType.Fire);
            modifiers.Add(mod2.Object);

            var mod3 = new Mock<IDamageModifier>();
            mod3.Setup(x => x.DamageType).Returns(DamageType.Cold);
            modifiers.Add(mod3.Object);


            Assert.AreEqual(2, modifiers.DamageType(DamageType.Fire).Count());
            Assert.AreEqual(1, modifiers.DamageType(DamageType.Cold).Count());
        }

        [TestMethod]
        public void Filter_WeaponType_Multiple()
        {
            var modifiers = new List<IModifier>();

            var mod = new Mock<IWeaponDamageModifier>();
            mod.Setup(x => x.WeaponType).Returns(WeaponType.Axe);
            modifiers.Add(mod.Object);

            var mod2 = new Mock<IWeaponDamageModifier>();
            mod2.Setup(x => x.WeaponType).Returns(WeaponType.Axe);
            modifiers.Add(mod2.Object);

            var mod3 = new Mock<IWeaponDamageModifier>();
            mod3.Setup(x => x.WeaponType).Returns(WeaponType.Sword);
            modifiers.Add(mod3.Object);


            Assert.AreEqual(2, modifiers.WeaponType(WeaponType.Axe).Count());
            Assert.AreEqual(1, modifiers.WeaponType(WeaponType.Sword).Count());
        }

        [TestMethod]
        public void Filter_DamageType_WeaponType_Multiple()
        {
            var modifiers = new List<IModifier>();

            var mod = new Mock<IWeaponDamageModifier>();
            mod.Setup(x => x.WeaponType).Returns(WeaponType.Axe);
            mod.Setup(x => x.DamageType).Returns(DamageType.Cold);
            modifiers.Add(mod.Object);

            var mod2 = new Mock<IWeaponDamageModifier>();
            mod2.Setup(x => x.WeaponType).Returns(WeaponType.Axe);
            mod2.Setup(x => x.DamageType).Returns(DamageType.Fire); 
            modifiers.Add(mod2.Object);

            var mod3 = new Mock<IWeaponDamageModifier>();
            mod3.Setup(x => x.WeaponType).Returns(WeaponType.Sword);
            mod3.Setup(x => x.DamageType).Returns(DamageType.Lightning);
            modifiers.Add(mod3.Object);


            Assert.AreEqual(1, modifiers.DamageType(DamageType.Cold).WeaponType(WeaponType.Axe).Count());
            Assert.AreEqual(1, modifiers.DamageType(DamageType.Fire).WeaponType(WeaponType.Axe).Count());
            Assert.AreEqual(1, modifiers.DamageType(DamageType.Lightning).WeaponType(WeaponType.Sword).Count());
        }
    }
}
