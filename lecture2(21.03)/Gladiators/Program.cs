using Gladiators.Models.Fighters;

namespace Fighters
{
    public class Program
    {
        private static int _fightersCount;
        public static void Main()
        {
            Console.WriteLine("Welcome to the Gladiators Battle!");

            try
            {
                SetFightersCount();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            List<Fighter> fightersList = new();

            CreateFighters(fightersList);

            GameManager master = new GameManager(fightersList);
            string name = master.GetWinner().Name;

            ShowWinnerName(name);
        }

        private static void ShowWinnerName(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The winner is {name} ");
            Console.ResetColor();
        }

        private static void SetFightersCount()
        {
            Console.WriteLine("Choose fighters count:");

            string fightersCountText = Console.ReadLine();

            try
            {
                _fightersCount = int.Parse(fightersCountText);
            }
            catch (FormatException)
            {
                throw new Exception("Incorrect input format. There must be a number.");
            }

            if (_fightersCount <= 0)
            {
                throw new Exception("Invalid input value. It must be greater than 0.");
            }
        }

        private static void CreateFighters(List<Fighter> fightersList)
        {
            for (int i = 0; i < _fightersCount; i++)
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
        }
    }
}