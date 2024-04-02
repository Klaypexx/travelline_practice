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
            int roundOwnerIndex = -1;
            int round = 1;

            while (true)
            {
                if (fighterList.Count == 1)
                {
                    return fighterList[0];
                } 
                
                bool isInit = false;
                while (!isInit)
                {
                    for (int i = 0; i < fighterList.Count; i++)
                    {
                        if (rnd.Next(0, 10 - fighterList[i].Initiative) == rnd.Next(0, 10 - fighterList[i].Initiative))
                        {
                            roundOwnerIndex = i;
                            isInit = true;

                        }
                    }
                }

                while (true)
                {
                    opponentIndex = rnd.Next(0, fighterList.Count);
                    if (opponentIndex != roundOwnerIndex)
                    {
                        break;
                    }
                }

                Console.WriteLine($"\nRound {round++}");
                Console.WriteLine($"{fighterList[roundOwnerIndex].Name} VS {fighterList[opponentIndex].Name}");
                if (FightAndCheckIfOpponentDead(fighterList[roundOwnerIndex], fighterList[opponentIndex]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{fighterList[opponentIndex].Name} die in a battle\n");
                    Console.ResetColor();
                    fighterList.RemoveAt(opponentIndex);
                };
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