using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core
{
    public struct Num 
    {
        //we want to use float as the underlying type (over double) because video cards are better optimized for it, 
        // and damage numbers shouldn't be expected to go above float.MaxValue (3.4e38)
        private float _value;
        public Num(float value)
        {
            _value = value;
        }
        public static implicit operator float(Num n) => n._value;
        public static implicit operator Num(float v) => new Num(v);

        public override bool Equals(object obj)
        {
            if (obj is Num || obj is float)
                return Equals((Num)obj);
            return false;
        }
        public bool Equals(Num n) { return Math.Abs(_value - n._value) < 0.01;  }

        public override string ToString()
        {
            return _value.ToString();
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
