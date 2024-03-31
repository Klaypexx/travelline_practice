internal class Programm
{
    static void Main()
    {
        int balance = 10000;
        const int multiplicator = 2;
        Random rand = new Random();
        while (balance != 0)
        {
            Console.WriteLine($"Введите вашу ставку. Ваш баланс сейчас {balance}");
            string betText = Console.ReadLine();
            if (!string.IsNullOrEmpty(betText)) {
                if (!int.TryParse(betText, out int bet))
                {
                    Console.WriteLine("Ошибка: Введите корректное целое число для ставки.");
                    continue;
                }
                if (bet <= balance)
                {
                    int randomNumber = rand.Next(1, 20);
                    if (randomNumber == 18 || randomNumber == 19 || randomNumber == 20)
                    {
                        int winSum = bet * (1 + (multiplicator * randomNumber % 17));
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
            } else
            {
                Console.WriteLine("Вы ввели пустое значение ставки");
            }
        }
        Console.WriteLine("У вас не осталось денег...");
    }
}