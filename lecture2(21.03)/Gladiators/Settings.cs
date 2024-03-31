using Gladiators.Models.Armors;
using Gladiators.Models.Classes;
using Gladiators.Models.Fighters;
using Gladiators.Models.Races;
using Gladiators.Models.Weapons;

namespace Fighters
{
    public class Settings
    {
        public static Fighter NewFighter()
        {
            string FighterName = CreateName();
            IRace FighterRace = PickRace();
            IClass FigheterClass = PickClass();
            IWeapon FighterWeapon = PickWeapon();
            IArmor FighterArmor = PickArmor();

            return new Fighter(FighterName, FighterRace, FigheterClass, FighterWeapon, FighterArmor);  
        }
        
        private static string CreateName()
        {

            while (true)
            {
                Console.WriteLine("Enter character name");
                string Name = Console.ReadLine();
                if (Name.Length > 20 || Name.Length < 1)
                {
                    Console.WriteLine("The character's name is incorrect.");
                    Console.ReadLine();
                } 
                else
                {
                    return Name;  
                }
            }

        }

        private static IRace PickRace()
        {
            string[] RaceData = { "Human", "Lizard" };

            while (true)
            {
                Console.WriteLine("Select a character's race by number from the list:");
                for (int i = 0; i < RaceData.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {RaceData[i]}");
                }

                int CurrentRace = int.Parse( Console.ReadLine() );

                switch ( CurrentRace ) {
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
            string[] WeaponData = { "No weapon", "Bat" };

            while (true)
            {
                Console.WriteLine("Select a character's weapon by number from the list:");
                for (int i = 0; i < WeaponData.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {WeaponData[i]}");
                }

                int CurrentWeapon = int.Parse(Console.ReadLine());

                switch (CurrentWeapon)
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
            string[] ArmorData = { "No armor", "Iron Armor" };

            while (true)
            {
                Console.WriteLine("Select a character's armor by number from the list:");
                for (int i = 0; i < ArmorData.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {ArmorData[i]}");
                }

                int CurrentArmor = int.Parse(Console.ReadLine());

                switch (CurrentArmor)
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

        private static IClass PickClass()
        {
            string[] ClassData = { "Warrior", "Mage" };

            while (true)
            {
                Console.WriteLine("Select a character class by number from the list:");
                for (int i = 0; i < ClassData.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {ClassData[i]}");
                }

                int CurrentClass = int.Parse(Console.ReadLine());

                switch (CurrentClass)
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