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

            if (string.IsNullOrEmpty(betText))
            {
                Console.WriteLine("Вы ввели пустое значение ставки");
                continue;
            }

            if (!int.TryParse(betText, out int bet))
            {
                Console.WriteLine("Ошибка: Введите корректное целое число для ставки.");
                continue;
            }

            if (bet > balance)
            {
                Console.WriteLine("У вас нет столько денег для ставки");
                continue;
            }

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
        Console.WriteLine("У вас не осталось денег...");
    }
}