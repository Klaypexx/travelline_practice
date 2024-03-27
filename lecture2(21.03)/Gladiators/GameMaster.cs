using Gladiators.Models.Fighters;
using System.Diagnostics;

namespace Fighters
{
    public class GameMaster
    {
        public Fighter PlayAndGetWinner(List<Fighter> FighterList)
        {

            Console.WriteLine("All Fighters:");
            for (int i = 0; i < FighterList.Count; i++)
            {
                Console.Write($"{FighterList[i].Name} ");
            }
            Console.WriteLine();

            Random rnd = new Random();

            int OpponentIndex;
            int RoundOwnerIndex = -1;
            int round = 1;


            while (true)
            {
                if (FighterList.Count > 1) { 
                
                    bool IsInit = false;
                    while (!IsInit)
                    {
                        for (int i = 0; i < FighterList.Count; i++)
                        {
                            if (rnd.Next(0, 10 - FighterList[i].Initiative) == rnd.Next(0, 10 - FighterList[i].Initiative))
                            {
                                RoundOwnerIndex = i;
                                IsInit = true;

                            }
                        }
                    }

                    while (true)
                    {
                        OpponentIndex = rnd.Next(0, FighterList.Count);
                        if (OpponentIndex != RoundOwnerIndex)
                        {
                            break;
                        }
                    }

                    Console.WriteLine($"Round {round++}");
                    Console.WriteLine($"{FighterList[RoundOwnerIndex].Name} VS {FighterList[OpponentIndex].Name}");
                    if (FightAndCheckIfOpponentDead(FighterList[RoundOwnerIndex], FighterList[OpponentIndex]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{FighterList[OpponentIndex].Name} die in a battle");
                        Console.ResetColor();
                        Console.WriteLine();
                        FighterList.RemoveAt(OpponentIndex);
                    };


                }
                else
                {
                    return FighterList[0];
                }


            }

            throw new UnreachableException();


        }

        public bool FightAndCheckIfOpponentDead(IFighter roundOwner, IFighter opponent)
        {
            double damage = roundOwner.CalculateDamage();
            opponent.TakeDamage(damage);

            Console.WriteLine($"Fighter {opponent.Name} get {damage} damage.\nThe armor resist {opponent.MaxArmor} damage.\nNow has {opponent.CurrentHealth} health");
            return opponent.CurrentHealth < 1;
        }
    }
}