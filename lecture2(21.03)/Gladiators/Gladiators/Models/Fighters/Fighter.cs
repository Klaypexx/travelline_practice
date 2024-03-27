using Gladiators.Models.Races;
using Gladiators.Models.Weapons;
using Gladiators.Models.Armors;
using Gladiators.Models.Classes;

namespace Gladiators.Models.Fighters
{
    public class Fighter : IFighter
    {
        public int MaxHealth => Race.Health + Class.Health;

        public int MaxArmor => Race.Armor + Armor.Armor;
        public double CurrentHealth { get; private set; }

        public int Initiative => Race.Initiative + Class.Initiative;
        public string Name { get; }

        public IRace Race { get; }
        public IWeapon Weapon { get; }
        public IArmor Armor { get; }

        public IClass Class { get; }

        public Fighter(string name, IRace race, IClass fclass, IWeapon weapon, IArmor armor)
        {
            Class = fclass;
            Name = name;
            Race = race;
            Weapon = weapon;
            Armor = armor;
            CurrentHealth = MaxHealth;
        }

        public void FigheterStat()
        {
            Console.WriteLine($"{Name} characteristics");
            Console.WriteLine($"The maximum health indicator - {MaxHealth}\nThe maximum armor indicator - {MaxArmor}\nInitiative - {Initiative}\nRace - {Race.Name}\nClass - {Class.Name}\nWeapon - {Weapon.Name}\nArmor - {Armor.Name}");
        }

        public void DamageInformation(double original, double multiply, bool critical, double damage)
        {
            Console.WriteLine($"Default damage: {original}");
            if (multiply > 0)
            {
                Console.Write("After a successful swing ");
            }
            else
            {
                Console.Write("After a failed swing ");
            }
            Console.WriteLine($"The damage has changed to {multiply} and became: {damage}");

            if (critical)
            {
                Console.WriteLine("Critical Damage x2");
            }

            Console.WriteLine($"Previous damage: {original}. After Damage: {damage}");


        }
        public double CalculateSwingPower(double damage)
        {
            Random rnd = new Random();
            double[] SwingPower = { -0.2, - 0.1, 0, 0.1 };
            double SwingPowerValue = SwingPower[rnd.Next(0, SwingPower.Length)];

            return SwingPowerValue;
        }

        public bool CalculateCriticalDamage()
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
            double OriginalDamage = (Race.Damage + Class.Damage + Weapon.Damage);

            double SwingPower = CalculateSwingPower(OriginalDamage);
            bool IsCriticalDamage = CalculateCriticalDamage();

            double MultiplyDamage = OriginalDamage * SwingPower;
            double Damage = OriginalDamage + MultiplyDamage;


            if (IsCriticalDamage)
            {
                Damage *= 2;
            }

            DamageInformation(OriginalDamage, MultiplyDamage, IsCriticalDamage, Damage);

            return Damage;
        }


        public void TakeDamage(double damage)
        {
            double TempHealth = CurrentHealth - Math.Max(damage - MaxArmor, 0);
            CurrentHealth = Math.Round(TempHealth, 2);
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }
    }
}