internal class Programm
{
    static void Main()
    {
        double balance = 10000;
        double multiplicator = 0.5;
        Random rand = new Random();
        while (balance != 0)
        {
            Console.WriteLine($"Введите вашу ставку. Ваш баланс сейчас {balance}");
            string betText = Console.ReadLine();
            int bet = int.Parse(betText);
            if (bet <= balance)
            {
                int randomNumber = rand.Next(1, 20);
                if (randomNumber == 18 || randomNumber == 19 || randomNumber == 20)
                {
                    double winSum = bet * (1 + (multiplicator * randomNumber % 17));
                    balance += winSum;
                    Console.WriteLine($"Поздравляем! Вы выиграли {winSum}");
                }
                else
                {
                    balance -= bet;
                    Console.WriteLine("Вы проиграли");
                }
            }
            else
            {
                Console.WriteLine("У вас нет столько денег для ставки");
            }
        }
        Console.WriteLine("У вас не осталось денег...");
    }
}