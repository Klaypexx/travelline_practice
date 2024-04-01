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
            string fightername = Createname();
            IRace fighterRace = PickOption("race", new Dictionary<int, Func<IRace>> {
                { 1, () => new Human() },
                { 2, () => new Lizard() }
            });
            IArchetype fighterArchetype = PickOption("class", new Dictionary<int, Func<IArchetype>> {
                { 1, () => new Warrior() },
                { 2, () => new Mage() }
            });
            IWeapon fighterWeapon = PickOption("weapon", new Dictionary<int, Func<IWeapon>> {
                { 1, () => new NoWeapon() },
                { 2, () => new Bat() }
            });
            IArmor fighterArmor = PickOption("armor", new Dictionary<int, Func<IArmor>> {
                { 1, () => new NoArmor() },
                { 2, () => new IronArmor() }
            });

            return new Fighter(fightername, fighterRace, fighterArchetype, fighterWeapon, fighterArmor);
        }

        private static string Createname()
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

        private static T PickOption<T>(string optionType, Dictionary<int, Func<T>> options)
        {
            while (true)
            {
                Console.WriteLine($"Select a fighter's {optionType} by number from the list:");
                foreach (KeyValuePair<int, Func<T>> option in options)
                {
                    Console.WriteLine($"{option.Key}. {option.Value().GetType().Name}");
                }

                int currentOption = int.Parse(Console.ReadLine());

                if (options.ContainsKey(currentOption))
                {
                    return options[currentOption]();
                }
                else
                {
                    Console.WriteLine($"There is no {optionType} under this number");
                    Console.ReadLine();
                }
            }
        }
    }
}
