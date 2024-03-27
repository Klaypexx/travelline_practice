using Gladiators.Models.Races;
using Gladiators.Models.Weapons;
using Gladiators.Models.Armors;
using Gladiators.Models.Classes;

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

        public IClass Class { get; }

        public void TakeDamage(double damage);
        public double CalculateDamage();

        public void FigheterStat();
    }
}