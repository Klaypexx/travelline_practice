using Gladiators.Models.Armors;
using Gladiators.Models.Archetype;
using Gladiators.Models.Fighters;
using Gladiators.Models.Races;
using Gladiators.Models.Weapons;

namespace Fighters
{
    public class FighterFactory
    {
        public static Fighter NewFighter()
        {
            string fightername = CreateName();

            List<IRace> races = new() { new Human(), new Lizard() };
            IRace fighterRace = PickOption("race", races);

            List<IArchetype> archetype = new() { new Warrior(), new Mage() };
            IArchetype fighterArchetype = PickOption("class", archetype);

            List<IWeapon> weapon = new() { new NoWeapon(), new Bat() };
            IWeapon fighterWeapon = PickOption("weapon", weapon);

            List<IArmor> armor = new() { new NoArmor(), new IronArmor() };
            IArmor fighterArmor = PickOption("armor", armor);

            return new Fighter(fightername, fighterRace, fighterArchetype, fighterWeapon, fighterArmor);
        }

        private static string CreateName()
        {
            while (true)
            {
                Console.WriteLine("Enter fighter name");
                string name = Console.ReadLine();
                if (name.Length > 20 || name.Length < 1)
                {
                    Console.WriteLine("The fighter's name is incorrect.");
                    Console.ReadLine();
                }
                else
                {
                    return name;
                }
            }
        }

        private static T PickOption<T>(string optionType, List<T> options)
        {
            while (true)
            {
                Console.WriteLine($"Select a fighter's {optionType} by number from the list:");
                int countOption = 1;
                foreach (T option in options)
                {
                    Console.WriteLine($"{countOption}. {option.GetType().Name}");
                    countOption++;
                }

                int currentOption = int.Parse(Console.ReadLine());

                if (options.Count < currentOption)
                {
                    Console.WriteLine($"There is no {optionType} under this number");
                    Console.ReadLine();
                }
                else
                {
                    return options[currentOption - 1];
                }
            }
        }
    }
}
