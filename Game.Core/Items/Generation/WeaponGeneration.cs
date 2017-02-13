using Game.Core.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Items.Generation
{
    public class WeaponGenerator
    {
        private static Dictionary<Type, List<Type>> typeCache;

        static WeaponGenerator()
        {
            var definedTypes = Assembly.GetAssembly(typeof(Weapon)).DefinedTypes;
            var abstractWeaponTypes = definedTypes.Where(x => typeof(Weapon).IsAssignableFrom(x) && x.IsAbstract && x != typeof(Weapon));

            typeCache = abstractWeaponTypes.ToDictionary(x => x.AsType(), abs =>
                definedTypes.Where(y => abs.IsAssignableFrom(y) && !y.IsAbstract)
                .Select(y => y.AsType())
                .ToList());
        }


        public Weapon Generate()
        {
            var weaponType = Rng.Instance.NextEnum<WeaponType>();
            switch (weaponType)
            {
                case WeaponType.Axe:
                    return GenerateAxe();
                case WeaponType.Sword:
                    return GenerateSword();
            }

            //return ;
            return null;
        }

        public Type PickType<T>()
        {
            if (!typeof(T).IsAbstract)
                return typeof(T);

            var itemTypes = typeCache[typeof(T)];
            var which = Rng.Instance.Next(0, itemTypes.Count());
            return itemTypes.Skip(which).FirstOrDefault();
        }

        public T CreateType<T>()
            where T : class
        {
            var weaponArgs = new object[] { Rarity.Magic, };
            var type = PickType<T>();
            var axeType = (T)Activator.CreateInstance(type, args: weaponArgs);
            return axeType;
        }

        public Axe GenerateAxe()
        {
            return CreateType<Axe>();
        }

        public Sword GenerateSword()
        {
            return CreateType<Sword>();
        }
    }
}
