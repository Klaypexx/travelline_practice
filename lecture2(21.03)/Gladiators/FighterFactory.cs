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
            IRace fighterRace = PickRace();
            IArchetype fighterArchetype = PickClass();
            IWeapon fighterWeapon = PickWeapon();
            IArmor fighterArmor = PickArmor();

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

        private static IRace PickRace()
        {
            string[] raceData = { "Human", "Lizard" };

            while (true)
            {
                Console.WriteLine("Select a fighter's race by number from the list:");
                for (int i = 0; i < raceData.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {raceData[i]}");
                }

                int currentRace = int.Parse( Console.ReadLine() );

                switch ( currentRace ) {
                    case 1:
                        return new Human();
                    case 2:
                        return new Lizard();
                    default: 
                        Console.WriteLine("There is no race under this number");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static IWeapon PickWeapon()
        {
            string[] weaponData = { "No weapon", "Bat" };

            while (true)
            {
                Console.WriteLine("Select a fighter's weapon by number from the list:");
                for (int i = 0; i < weaponData.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {weaponData[i]}");
                }

                int currentWeapon = int.Parse(Console.ReadLine());

                switch (currentWeapon)
                {
                    case 1:
                        return new NoWeapon();
                    case 2:
                        return new Bat();
                    default:
                        Console.WriteLine("There are no weapons under this number");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static IArmor PickArmor()
        {
            string[] armorData = { "No armor", "Iron Armor" };

            while (true)
            {
                Console.WriteLine("Select a fighter's armor by number from the list:");
                for (int i = 0; i < armorData.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {armorData[i]}");
                }

                int currentArmor = int.Parse(Console.ReadLine());

                switch (currentArmor)
                {
                    case 1:
                        return new NoArmor();
                    case 2:
                        return new IronArmor();
                    default:
                        Console.WriteLine("There is no reservation under this number");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static IArchetype PickClass()
        {
            string[] classData = { "Warrior", "Mage" };

            while (true)
            {
                Console.WriteLine("Select a fighter class by number from the list:");
                for (int i = 0; i < classData.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {classData[i]}");
                }

                int currentClass = int.Parse(Console.ReadLine());

                switch (currentClass)
                {
                    case 1:
                        return new Warrior();
                    case 2:
                        return new Mage();
                    default:
                        Console.WriteLine("There is no class under this number");
                        Console.ReadLine();
                        break;
                }
            }
        }

    }
}