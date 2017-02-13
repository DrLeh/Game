using Game.Core.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Gems
{
    public interface IGem
    {
        int Level { get; set; }
        int XP { get; set; }
        string Name { get; }
    }

    public abstract class Gem : IGem
    {
        public int Level { get; set; }
        public int XP { get; set; }

        public abstract string Name { get; }
        public abstract GemLevelSet LevelSet { get; }

        public bool ReadyToLevel { get; private set; }

        private int? _nextLevelXP;
        private int NextLevelXP => _nextLevelXP ?? (int)(_nextLevelXP = LevelSet.XpToNextLevel(Level));

        public void AccrueXP(int xp)
        {
            XP += xp;
            var next = NextLevelXP;
            if (XP > next)
            {
                XP = next;
                ReadyToLevel = true;
            }
        }

        public void LevelUp()
        {
            XP = 0;
            Level++;
            ReadyToLevel = false;
            _nextLevelXP = null;
        }
    }

    public abstract class ActiveGem : Gem
    {
        public abstract IAbility Ability { get; }
    }

    public abstract class SupportGem : Gem
    {
        public IModifier Modifier { get; }
    }

    public class GemLevelSet
    {
        //todo: stor e how a gem changes
        public GemLevelSet()
        {
            LevelDetails = Enumerable.Range(1, 30).ToDictionary(x => x, x => 0);
        }

        public Dictionary<int, int> LevelDetails { get; set; }

        public int XpToNextLevel(int currentLevel) => LevelDetails[currentLevel];
    }

    public class SupportedGem
    {
        public ActiveGem ActiveGem { get; set; }
        public List<SupportGem> Supports { get; set; }


    }
    public class SupportedAbility
    {
        public IAbility Ability { get; set; }
        public IEnumerable<IModifier> SupportModifiers { get; set; }

        public IAbility FullAbility
        {
            get
            {
                var a = new ArbitraryAbility
                {
                    BaseDamage = Ability.BaseDamage,
                    Modifiers = Ability.Modifiers.Concat(ModifierApplicator.GetRelevantFilters(Ability, SupportModifiers)).ToList()
                };
                return a;
            }
        }
    }
}
