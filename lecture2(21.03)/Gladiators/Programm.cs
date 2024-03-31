using Gladiators.Models.Fighters;

namespace Fighters
{
    public class Programm
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Gladiators Battle!");

            Console.WriteLine("Choose fighters count:");

            int fightersCount = int.Parse(Console.ReadLine());

            List<Fighter> fightersList = new List<Fighter>();

            for (int i = 0; i < fightersCount; i++)
            {
                Console.WriteLine($"Create fighter {i + 1}");
                fightersList.Add(FighterFactory.NewFighter());
                Console.WriteLine();
                Console.WriteLine("Would you like to see your fighter characteristics? Write yes to see.");
                string isStat = Console.ReadLine().Trim().ToLower();
                if (isStat == "yes")
                {
                    string currentFighterStat = fightersList[i].FigheterStat();
                    Console.WriteLine(currentFighterStat);
                }
                Console.ReadLine();
            }

            var master = new GameManager();
            var winner = master.GetWinner(fightersList);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The winner is {winner.Name} ");
            Console.ResetColor();
        }
    }
}