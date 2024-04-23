using Gladiators.Models.Races;
using Gladiators.Models.Weapons;
using Gladiators.Models.Armors;
using Gladiators.Models.Archetype;

namespace Gladiators.Models.Fighters
{
    public interface IFighter
    {
        public int MaxArmor { get; }
        public double CurrentHealth { get; }
        public int Initiative { get; } 
        public string Name { get; }
        public void TakeDamage(double damage);
        public double GetDamage();
        public string GetFigheterStat();
        public bool IsDead();
    }
}