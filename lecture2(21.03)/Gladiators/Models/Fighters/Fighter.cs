using Gladiators.Models.Races;
using Gladiators.Models.Weapons;
using Gladiators.Models.Armors;
using Gladiators.Models.Archetype;

namespace Gladiators.Models.Fighters
{
    public class Fighter : IFighter
    {
        public int MaxArmor => _race.Armor + _armor.Armor;
        public double CurrentHealth { get; private set; }
        public int Initiative => _race.Initiative + _archetype.Initiative;
        public string Name { get; }
        private int MaxHealth => _race.Health + _archetype.Health;
        private IRace _race;
        private IWeapon _weapon;
        private IArmor _armor;
        private IArchetype _archetype;
        public Fighter(string name, IRace race, IArchetype fclass, IWeapon weapon, IArmor armor)
        {
            _archetype = fclass;
            Name = name;
            _race = race;
            _weapon = weapon;
            _armor = armor;
            CurrentHealth = MaxHealth;
        }
        public string GetFigheterStat()
        {
            string fighterStatText = $"{Name} characteristics\nThe maximum health indicator - {MaxHealth}\n";
            fighterStatText += $"The maximum armor indicator - {MaxArmor}\nInitiative - {Initiative}\n";
            fighterStatText += $"Race - {_race.Name}\nClass - {_archetype.Name}\n";
            fighterStatText += $"Weapon - {_weapon.Name}\nArmor - {_armor.Name}";

            return fighterStatText;
        }

        public double GetDamage()
        {
            double originalDamage = (_race.Damage + _archetype.Damage + _weapon.Damage);

            double swingPower = GetSwingPower();
            bool isCriticalDamage = IsCriticalDamage();

            double multiplyDamage = originalDamage * swingPower;
            double damage = originalDamage + multiplyDamage;

            if (isCriticalDamage)
            {
                damage *= 2;
            }

            string damageInformationText = GetDamageInformation(originalDamage, Math.Round(multiplyDamage, 2), isCriticalDamage, damage);
            Console.WriteLine(damageInformationText);

            return damage;
        }

        public void TakeDamage(double damage)
        {
            double tempHealth = CurrentHealth - Math.Max(damage - MaxArmor, 0);
            CurrentHealth = Math.Round(tempHealth, 2);
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }
        private string GetDamageInformation(double original, double multiply, bool critical, double damage)
        {
            string damageInformationText = $"Default damage: {original}\n";
            if (critical)
            {
                damageInformationText += "Critical Damage x2\n";
            }
            if (multiply > 0)
            {
                damageInformationText += "After a successful swing ";
            }
            else
            {
                damageInformationText += "After a failed swing ";
            }
            damageInformationText += $"The damage has changed to {multiply} and became: {damage}\n";


            damageInformationText += $"Previous damage: {original}. After Damage: {damage}";

            return damageInformationText;
        }
        private double GetSwingPower()
        {
            Random rnd = new Random();
            double[] swingPower = { -0.2, - 0.1, 0, 0.1 };
            double swingPowerValue = swingPower[rnd.Next(0, swingPower.Length)];

            return swingPowerValue;
        }

        private bool IsCriticalDamage()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 10) == rnd.Next(0, 10))
            {
                return true;
            }
            return false;
        }
    }
}