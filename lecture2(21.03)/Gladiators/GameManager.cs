using Gladiators.Models.Fighters;
using System.Diagnostics;

namespace Fighters
{
    public class GameManager
    {
        public Fighter GetWinner(List<Fighter> fighterList)
        {

            Console.WriteLine("All Fighters:");
            foreach (Fighter fighter in fighterList)
            {
                Console.Write($"{fighter.Name} ");
            }
            Console.WriteLine();

            Random rnd = new Random();

            int opponentIndex;
            int round = 1;

            fighterList = fighterList.OrderByDescending(f => f.Initiative).ToList();

            while (true)
            {
                if (fighterList.Count == 1)
                {
                    return fighterList[0];
                } 

                for (int fighter = 0; fighter < fighterList.Count; fighter++)
                {
                    do
                    {
                        opponentIndex = rnd.Next(0, fighterList.Count);
                    }
                    while (opponentIndex == fighter);

                    Console.WriteLine($"\nRound {round++}");
                    Console.WriteLine($"{fighterList[fighter].Name} VS {fighterList[opponentIndex].Name}");
                    if (FightAndCheckIfOpponentDead(fighterList[fighter], fighterList[opponentIndex]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n{fighterList[opponentIndex].Name} die in a battle\n");
                        Console.ResetColor();
                        fighterList.RemoveAt(opponentIndex);
                    };
                }

            }
            throw new UnreachableException();
        }

        public bool FightAndCheckIfOpponentDead(IFighter roundOwner, IFighter opponent)
        {
            double damage = roundOwner.GetDamage();
            opponent.TakeDamage(damage);

            Console.WriteLine($"Fighter {opponent.Name} get {damage} damage.\nThe armor resist {opponent.MaxArmor} damage.\nNow has {opponent.CurrentHealth} health");
            return opponent.CurrentHealth < 1;
        }
    }
}