using System.Diagnostics;
using Gladiators.Models.Fighters;
using Gladiators.Models.Races;
using Gladiators.Models.Armors;

namespace Fighters
{
    public class Programm
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Gladiators Battle!");

            Console.WriteLine("Choose Gladiators count:");

            int FightersCount = int.Parse(Console.ReadLine());

            List<Fighter> FightersList = new List<Fighter>();

            for (int i = 0; i < FightersCount; i++)
            {
                Console.WriteLine($"Create character {i + 1}");
                FightersList.Add(Settings.NewFighter());
                Console.WriteLine();
                FightersList[i].FigheterStat();
                Console.ReadLine();
            }

            var master = new GameMaster();
            var winner = master.PlayAndGetWinner(FightersList);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The winner is {winner.Name} ");
            Console.ResetColor();
        }
    }
}