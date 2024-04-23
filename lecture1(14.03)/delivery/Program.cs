public class Program
{
    public static void Main()
    {
        Console.Write("Введите название продукта: ");
        string productName = Console.ReadLine();

        Console.Write("Введите количество: ");
        string amountOfProduct = Console.ReadLine();

        int amount;

        try
        {
            amount = int.Parse(amountOfProduct);
        } 
        catch
        {
            Console.WriteLine($"Входная строка была введена в неправильном формате.");
            return;
        }

        Console.Write("Введите ваше имя: ");
        string userName = Console.ReadLine();

        Console.Write("Введите ваш адрес: ");
        string address = Console.ReadLine();

        DateTime currentDate = DateTime.Now;
        DateTime deliveryDate = currentDate.AddDays(3);

        string confirmationText = $"Здравствуйте, {userName},";
        confirmationText += $" вы заказали {amount} {productName} ";
        confirmationText += $"на адрес {address}, все верно?\n";
        confirmationText += $"Для подтверждения напишите - да";

        string deliveryInformationText = $"{userName}!\n";
        deliveryInformationText += $"Ваш заказ {productName} в количестве {amount} оформлен! \n";
        deliveryInformationText += $"Ожидайте доставку по адресу {address} к {deliveryDate}";

        Console.WriteLine(confirmationText);
        string isCorrect = Console.ReadLine().Trim().ToLower();

        if (isCorrect == "да")
        {
            Console.WriteLine(deliveryInformationText);
        } 
        else
        {
            Console.WriteLine("Заказ отменен");
        }
    }
}