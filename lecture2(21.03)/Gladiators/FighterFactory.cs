using Gladiators.Models.Armors;
using Gladiators.Models.Archetype;
using Gladiators.Models.Fighters;
using Gladiators.Models.Races;
using Gladiators.Models.Weapons;
using System;

namespace Fighters
{
    public class FighterFactory
    {
        public static Fighter NewFighter()
        {
            string fightername = Createname();
            IRace fighterRace = PickItem<IRace>(new string[] { "Human", "Lizard" });
            IArchetype fighterArchetype = PickItem<IArchetype>(new string[] { "Warrior", "Mage" });
            IWeapon fighterWeapon = PickItem<IWeapon>(new string[] { "No weapon", "Bat" });
            IArmor fighterArmor = PickItem<IArmor>(new string[] { "No armor", "Iron Armor" });

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

        private static T PickItem<T>(string[] items)
        {
            while (true)
            {
                Console.WriteLine($"Select an item by number from the list:");
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i]}");
                }

                int selectedItem = int.Parse(Console.ReadLine());

                if (selectedItem >= 1 && selectedItem <= items.Length)
                {
                    return (T)Convert.ChangeType(items[selectedItem - 1], typeof(T));
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please choose a valid number.");
                    Console.ReadLine();
                }
            }
        }
    }
}