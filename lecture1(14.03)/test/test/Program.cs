public class Program
{
    public static void Main()
    {
        Console.Write("Введите название продукта: ");
        string product = Console.ReadLine();

        Console.Write("Введите количество: ");
        string amountText = Console.ReadLine();
        int amount = int.Parse(amountText);

        Console.Write("Введите ваше имя: ");
        string userName = Console.ReadLine();

        Console.Write("Введите ваш адрес: ");
        string adress = Console.ReadLine();

        DateTime dateTime = DateTime.Now;

        string firstOutputText = $"Здравствуйте, {userName}, вы заказали {amount} {product} на адрес {adress}, все верно?";
        string secondOuputText = $"{userName}!\nВаш заказ {product} в количестве {amount} оформлен! \nОжидайте доставку по адресу {adress} к {dateTime.AddDays(3)}";

        Console.WriteLine(firstOutputText);
        string isCorrect = Console.ReadLine();
        if (isCorrect == "Yes" || isCorrect == "yes" || isCorrect == "Да" || isCorrect == "да" || isCorrect == "")
        {
            Console.WriteLine(secondOuputText);
        }
    }
}
