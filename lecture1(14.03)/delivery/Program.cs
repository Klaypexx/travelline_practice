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
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.Write("Введите ваше имя: ");
        string userName = Console.ReadLine();

        Console.Write("Введите ваш адрес: ");
        string adress = Console.ReadLine();

        DateTime currentDate = DateTime.Now;
        DateTime deliveryDate = currentDate.AddDays(3);

        string confirmationText = $"Здравствуйте, {userName}, вы заказали {amount} {productName} на адрес {adress}, все верно?\nДля подтверждения напишите - да";
        string deliveryInformationText = $"{userName}!\nВаш заказ {productName} в количестве {amount} оформлен! \nОжидайте доставку по адресу {adress} к {deliveryDate}";

        Console.WriteLine(confirmationText);
        string isCorrect = Console.ReadLine().Trim().ToLower();

        if (isCorrect == "да")
        {
            Console.WriteLine(deliveryInformationText);
        } else
        {
            Console.WriteLine("Заказ отменен");
        }
    }
}