using Accommodations.Commands;
using Accommodations.Dto;
using Accommodations.Validation;

namespace Accommodations;

public static class AccommodationsProcessor
{
    private static BookingService _bookingService = new();
    private static Dictionary<int, ICommand> _executedCommands = new();
    private static int s_commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine("Booking Command Line Interface");
        Console.WriteLine("Commands:");
        Console.WriteLine("'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room");
        Console.WriteLine("'cancel <BookingId>' - to cancel a booking");
        Console.WriteLine("'undo' - to undo the last command");
        Console.WriteLine("'find <BookingId>' - to find a booking by ID");
        Console.WriteLine("'search <StartDate> <EndDate> <CategoryName>' - to search bookings");
        Console.WriteLine("'exit' - to exit the application");

        string input;
        while ((input = Console.ReadLine()) != "exit")
        {
            try
            {
                ProcessCommand(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string commandName = parts[0];
        switch (commandName)
        {
            case "book":
                if (parts.Length != 6)
                {
                    Console.WriteLine("Invalid number of arguments for booking.");
                    return;
                }

                CurrencyDto currency = (CurrencyDto)ValidationData.ThrowIfNull(ValidationData.CurrentDtoParse(parts[5]), "Currency value is incorrect");

                //Добавил CultureInfo.InvariantCulture, без него выдается ошибка при парсинге строкового типа даты
                //Добавил условие для некорректной даты

                DateTime startDate = (DateTime)ValidationData.ThrowIfNull(ValidationData.DateTimeParse(parts[3]), "Date of the book beginning is incorrect");

                DateTime endDate = (DateTime)ValidationData.ThrowIfNull(ValidationData.DateTimeParse(parts[4]), "Date of the book ending is incorrect");

                BookingDto bookingDto = new()
                {
                    UserId = int.Parse(parts[1]),
                    Category = parts[2],
                    StartDate = startDate,
                    EndDate = endDate,
                    Currency = currency,
                };

                BookCommand bookCommand = new(_bookingService, bookingDto);
                bookCommand.Execute();

                if (startDate >= DateTime.Now) //переменная _executedCommands будет увеличиваться, если startDate >= DateTime.Now
                {
                    _executedCommands.Add(++s_commandIndex, bookCommand);
                }
                Console.WriteLine("Booking command run is successful.");
                break;

            case "cancel":
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid number of arguments for canceling.");
                    return;
                }

                Guid bookingId = (Guid)ValidationData.ThrowIfNull(ValidationData.GuidParse(parts[1]), "Id is incorrect");

                CancelBookingCommand cancelCommand = new(_bookingService, bookingId);
                cancelCommand.Execute();
                _executedCommands.Add(++s_commandIndex, cancelCommand);
                Console.WriteLine("Cancellation command run is successful.");
                break;

            case "undo":
                //Добавил проверку на то, что количество команд будет 0
                if (s_commandIndex == 0)
                {
                    Console.WriteLine("The command history is empty");
                    return;
                }
                _executedCommands[s_commandIndex].Undo();
                _executedCommands.Remove(s_commandIndex);
                s_commandIndex--;
                Console.WriteLine("Last command undone.");

                break;
            case "find":
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid arguments for 'find'. Expected format: 'find <BookingId>'");
                    return;
                }
                Guid id = (Guid)ValidationData.ThrowIfNull(ValidationData.GuidParse(parts[1]), "Id is incorrect");
                FindBookingByIdCommand findCommand = new(_bookingService, id);
                findCommand.Execute();
                break;

            case "search":
                if (parts.Length != 4)
                {
                    Console.WriteLine("Invalid arguments for 'search'. Expected format: 'search <StartDate> <EndDate> <CategoryName>'");
                    return;
                }

                startDate = (DateTime)ValidationData.ThrowIfNull(ValidationData.DateTimeParse(parts[1]), "Date of the book beginning is incorrect");

                endDate = (DateTime)ValidationData.ThrowIfNull(ValidationData.DateTimeParse(parts[2]), "Date of the book ending is incorrect");

                string categoryName = parts[3];
                SearchBookingsCommand searchCommand = new(_bookingService, startDate, endDate, categoryName);
                searchCommand.Execute();
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}
