using Gladiators.Models.Races;
using Gladiators.Models.Weapons;
using Gladiators.Models.Armors;
using Gladiators.Models.Archetype;

namespace Gladiators.Models.Fighters
{
    public interface IFighter
    {
        public int MaxHealth { get; }
        public int MaxArmor { get; }
        public double CurrentHealth { get; }
        public int Initiative { get; } 
        public string Name { get; }
        public IWeapon Weapon { get; }
        public IRace Race { get; }
        public IArmor Armor { get; }
        public IArchetype Archetype { get; }
        public void TakeDamage(double damage);
        public double CalculateDamage();
        public string FigheterStat();
    }
}