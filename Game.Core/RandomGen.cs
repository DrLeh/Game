using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core
{
    public interface IRng
    {
        float NextFloat();
        int Next(int max);
        int Next(int min, int max);
        TEnum NextEnum<TEnum>();
    }

    public class Rng : IRng
    {
        //todo: remove this and inject
        public static Rng Instance = new Rng();

        private static Random rng;
        static Rng()
        {
            rng = new Random();
        }

        public int Next(int max)
        {
            return rng.Next(max);
        }
        public int Next(int min, int max)
        {
            return rng.Next(min, max);
        }

        //fastest verison i found from http://stackoverflow.com/questions/3365337/best-way-to-generate-a-random-float-in-c-sharp
        const double diff = float.MaxValue - float.MinValue;
        public float NextFloat()
        {
            double sample = rng.NextDouble();
            return (float)((sample * diff) + float.MinValue);
        }

        public float FloatBetween(float minimum, float maximum)
        {
            return NextFloat() * (maximum - minimum) + minimum;
        }

        public TEnum NextEnum<TEnum>()
        {
            var values = Enum.GetValues(typeof(TEnum));
            return (TEnum)values.GetValue(Next(values.Length));
        }

        //public TOut Weighted<TOut>(WeightedDict<TOut> dict)
        //{
        //    return dict.Get(NextFloat());
        //}
    }

    //public class WeightedDict<T>
    //{
    //    private IDictionary<float, T> _dict;
    //    public WeightedDict(IDictionary<float, T> dict)
    //    {
    //        _dict = dict;

    //    }

    //    public T Get(float weight)
    //    {

    //    }
    //}
}
