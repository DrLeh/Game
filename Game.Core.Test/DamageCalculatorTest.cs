using System;
using Game.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Core.Test
{
    [TestClass]
    public class DamageCalculatorTest
    {
        private void Check(float expected, Num result)
        {
            Assert.IsTrue(result.Equals(expected));
            //Assert.AreEqual(expected, (double)result);
            //Assert.IsTrue(result == expected);
        }

        [TestMethod]
        public void Increased()
        {
            var calc = new DamageCalculator();

            calc.Base = 10;
            calc.Increased = .1f;
            Check(11, calc.CalcDamage());
        }

        [TestMethod]
        public void More()
        {
            var calc = new DamageCalculator();

            calc.Base = 10;
            calc.More.Add(.1f);
            Check(11, calc.CalcDamage());
        }

        [TestMethod]
        public void MultiMore()
        {
            var calc = new DamageCalculator();

            calc.Base = 10;
            calc.More.Add(.1f);
            calc.More.Add(.2f);
            calc.More.Add(.3f);

            Check((float)(10 * 1.1 * 1.2 * 1.3), calc.CalcDamage());
        }

        [TestMethod]
        public void IncAndMore()
        {
            var calc = new DamageCalculator();

            calc.Base = 10f;
            calc.Increased = 1.25f;
            calc.More.Add(.1f);
            calc.More.Add(.2f);
            calc.More.Add(.3f);

            Check((float)(10 * 2.25 * 1.1 * 1.2 * 1.3), calc.CalcDamage());
        }
    }
}
