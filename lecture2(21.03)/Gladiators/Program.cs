using Gladiators.Models.Fighters;

namespace Fighters
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Gladiators Battle!");

            Console.WriteLine("Choose fighters count:");

            string fightersCountText = Console.ReadLine();
            int fightersCount = 0;

            try
            {
                fightersCount = int.Parse(fightersCountText);
                if (fightersCount <= 0)
                {
                    Console.WriteLine("Invalid input value. It must be greater than 0");
                    return;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return;
            }

            List<Fighter> fightersList = new();

            for (int i = 0; i < fightersCount; i++)
            {
                Console.WriteLine($"Create fighter {i + 1}");
                fightersList.Add(FighterFactory.NewFighter());
                Console.WriteLine();
                Console.WriteLine("Would you like to see your fighter characteristics? Write yes to see.");
                string isStat = Console.ReadLine().Trim().ToLower();
                if (isStat == "yes")
                {
                    string currentFighterStat = fightersList[i].GetFigheterStat();
                    Console.WriteLine(currentFighterStat);
                }
                Console.ReadLine();
            }

            GameManager master = new GameManager();
            Fighter winner = master.GetWinner(fightersList);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The winner is {winner.Name} ");
            Console.ResetColor();
        }
    }
}