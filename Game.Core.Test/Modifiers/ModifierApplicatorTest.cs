using Game.Core.Gems;
using Game.Core.Modifiers;
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
    public class ModifierApplicatorTest
    {
        [TestMethod]
        public void ModifierApplicator_Test()
        {
            var ability = new Mock<IAbility>();
            ability.Setup(x => x.Tags).Returns(ModifierTag.Aoe);
            var modifiers = new List<IModifier>();

            var mod1 = new Mock<IModifier>();
            mod1.Setup(x => x.Tags).Returns(ModifierTag.Aoe);
            modifiers.Add(mod1.Object);

            var mod2 = new Mock<IModifier>();
            mod2.Setup(x => x.Tags).Returns(ModifierTag.Movement);
            modifiers.Add(mod2.Object);

            var result = ModifierApplicator.GetRelevantFilters(ability.Object, modifiers);

            Assert.AreEqual(mod1.Object, result.FirstOrDefault());
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void SupportedAbility_Test()
        {
            var ability = new Mock<IAbility>();
            ability.Setup(x => x.Tags).Returns(ModifierTag.Aoe);
            var abilityModifiers = new List<IModifier>();

            var abMod1 = new Mock<IModifier>();
            abilityModifiers.Add(abMod1.Object);

            ability.Setup(x => x.Modifiers).Returns(abilityModifiers);


            var modifiers = new List<IModifier>();

            var mod1 = new Mock<IModifier>();
            mod1.Setup(x => x.Tags).Returns(ModifierTag.Aoe);
            modifiers.Add(mod1.Object);

            var mod2 = new Mock<IModifier>();
            mod2.Setup(x => x.Tags).Returns(ModifierTag.Movement);
            modifiers.Add(mod2.Object);


            var supported = new SupportedAbility
            {
                Ability = ability.Object,
                SupportModifiers = modifiers
            };
            Assert.AreEqual(2, supported.FullAbility.Modifiers.Count());
        }

        [TestMethod]
        public void SupportedAbility_MultipleSource_Test()
        {
            var ability = new Mock<IAbility>();
            ability.Setup(x => x.Tags).Returns(ModifierTag.Aoe);
            ability.Setup(x => x.DamageType).Returns(DamageType.Fire);
            var abilityModifiers = new List<IModifier>();

            var abMod1 = new Mock<IModifier>();
            abilityModifiers.Add(abMod1.Object);

            ability.Setup(x => x.Modifiers).Returns(abilityModifiers);


            var modifiers = new List<IModifier>();

            var mod1 = new Mock<IModifier>();
            mod1.Setup(x => x.Tags).Returns(ModifierTag.Aoe);
            modifiers.Add(mod1.Object);

            var mod2 = new Mock<IModifier>();
            mod2.Setup(x => x.Tags).Returns(ModifierTag.Movement);
            modifiers.Add(mod2.Object);

            var mod3 = new Mock<IDamageModifier>();
            mod3.Setup(x => x.DamageType).Returns(DamageType.Fire);
            modifiers.Add(mod3.Object);

            var mod4 = new Mock<IDamageModifier>();
            mod4.Setup(x => x.DamageType).Returns(DamageType.Chaos);
            modifiers.Add(mod4.Object);


            var supported = new SupportedAbility
            {
                Ability = ability.Object,
                SupportModifiers = modifiers
            };
            Assert.AreEqual(3, supported.FullAbility.Modifiers.Count());
        }
    }
}
