using Gladiators.Models.Races;
using Gladiators.Models.Weapons;
using Gladiators.Models.Armors;
using Gladiators.Models.Archetype;

namespace Gladiators.Models.Fighters
{
    public class Fighter : IFighter
    {
        public int MaxHealth => Race.Health + Archetype.Health;
        public int MaxArmor => Race.Armor + Armor.Armor;
        public double CurrentHealth { get; private set; }
        public int Initiative => Race.Initiative + Archetype.Initiative;
        public string Name { get; }
        public IRace Race { get; }
        public IWeapon Weapon { get; }
        public IArmor Armor { get; }
        public IArchetype Archetype { get; }
        public Fighter(string name, IRace race, IArchetype fclass, IWeapon weapon, IArmor armor)
        {
            Archetype = fclass;
            Name = name;
            Race = race;
            Weapon = weapon;
            Armor = armor;
            CurrentHealth = MaxHealth;
        }

        public string FigheterStat()
        {
            string fighterStatText = $"{Name} characteristics\nThe maximum health indicator - {MaxHealth}\nThe maximum armor indicator - {MaxArmor}\nInitiative - {Initiative}\nRace - {Race.Name}\nClass - {Archetype.Name}\nWeapon - {Weapon.Name}\nArmor - {Armor.Name}";
            return fighterStatText;
        }

        public string DamageInformation(double original, double multiply, bool critical, double damage)
        {
            string damageInformationText = $"Default damage: {original}\n";
            if (multiply > 0)
            {
                damageInformationText += "After a successful swing ";
            }
            else
            {
                damageInformationText += "After a failed swing ";
            }
            damageInformationText += $"The damage has changed to {multiply} and became: {damage}\n";

            if (critical)
            {
                damageInformationText += "Critical Damage x2\n";
            }

            damageInformationText += $"Previous damage: {original}. After Damage: {damage}";

            return damageInformationText;
        }
        public double CalculateswingPower(double damage)
        {
            Random rnd = new Random();
            double[] swingPower = { -0.2, - 0.1, 0, 0.1 };
            double swingPowerValue = swingPower[rnd.Next(0, swingPower.Length)];

            return swingPowerValue;
        }

        public bool IsCriticalDamage()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 10) == rnd.Next(0, 10))
            {
                return true;
            }
            return false;
        }

        public double CalculateDamage()
        {
            double originalDamage = (Race.Damage + Archetype.Damage + Weapon.Damage);

            double swingPower = CalculateswingPower(originalDamage);
            bool isCriticalDamage = IsCriticalDamage();

            double multiplyDamage = originalDamage * swingPower;
            double damage = originalDamage + multiplyDamage;


            if (isCriticalDamage)
            {
                damage *= 2;
            }

            string damageInformationText = DamageInformation(originalDamage, multiplyDamage, isCriticalDamage, damage);
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
    }
}