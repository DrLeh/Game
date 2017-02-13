using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core
{
    public class DamageCalculator
    {
        public DamageCalculator() : this(false)
        {
        }
        public DamageCalculator(bool cache)
        {
            UseCache = cache;
            More = new List<Num>();
        }

        public Num Base { get; set; }
        public Num Increased { get; set; }
        public List<Num> More { get; set; }

        public bool UseCache { get; set; }

        private Num? cached;
        public Num CalcDamage()
        {
            if (cached.HasValue && UseCache)
                return cached.Value;

            var result = Base;
            foreach (var more in More.Concat(new[] { Increased }))
                result = result * (1 + more);

            return (cached = result).Value;
        }
    }
}
