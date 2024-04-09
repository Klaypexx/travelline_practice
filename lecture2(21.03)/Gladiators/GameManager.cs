using Gladiators.Models.Fighters;
using System.Diagnostics;

namespace Fighters
{
    public class GameManager
    {
        private List<Fighter> _fighterList;
        private int _opponentIndex = -1;
        private int _round = 1;

        public GameManager(List<Fighter> fighterList)
        {
            _fighterList = fighterList;
        }

        public Fighter GetWinner()
        {
            ShowAllFighters();

            _fighterList = _fighterList.OrderByDescending(f => f.Initiative).ToList();

            while (true)
            {
                if (_fighterList.Count == 1)
                {
                    return _fighterList[0];
                }

                Fight();
            }
            throw new UnreachableException();
        }

        private void ShowAllFighters()
        {
            Console.WriteLine("All Fighters:");
            foreach (Fighter fighter in _fighterList)
            {
                Console.Write($"{fighter.Name} ");
            }
            Console.WriteLine();
        }

        private void Fight()
        {
            for (int fighter = 0; fighter < _fighterList.Count; fighter++)
            {
                SetOpponent(fighter);

                Console.WriteLine($"\nRound {_round++}");
                Console.WriteLine($"{_fighterList[fighter].Name} VS {_fighterList[_opponentIndex].Name}");

                RoundFight(_fighterList[fighter], _fighterList[_opponentIndex]);

                if (_fighterList[_opponentIndex].IsDead())
                {
                    FighterDieText();
                    _fighterList.RemoveAt(_opponentIndex);
                };
            }
        }

        private void FighterDieText()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{_fighterList[_opponentIndex].Name} die in a battle\n");
            Console.ResetColor();
        }

        private void SetOpponent(int fighter)
        {
            Random rnd = new Random();
            do
            {
                _opponentIndex = rnd.Next(0, _fighterList.Count);
            }
            while (_opponentIndex == fighter);
        }

        private string GetRoundStat(double damage, IFighter opponent)
        {
            string roundStat = $"Fighter {opponent.Name} get {damage} damage.\n";
            roundStat += $"The armor resist {opponent.MaxArmor} damage.\n";
            roundStat += $"Now has {opponent.CurrentHealth} health";

            return roundStat;
        }

        private void RoundFight(IFighter roundOwner, IFighter opponent)
        {
            double damage = roundOwner.GetDamage();
            opponent.TakeDamage(damage);

            string roundStat = GetRoundStat(damage, opponent);

            Console.WriteLine(roundStat);
        }
    }
}