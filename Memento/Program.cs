using NLog;

namespace Memento;

internal abstract class Program
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private static void Main(string[] args)
    {
        _logger.Info("Entering Memento Pattern!");
        bool running = true;
        var info = new Info("Mano", "Male", "NL");
        while (running)
        {
            _logger.Info("Press the command...");
            _logger.Info(
                "n to change name; g to change gender; a to change address\n" +
                "c to create snapshot; u to undo; r to redo; p to print; e to exit");

            var key = Console.ReadKey();

            try
            {
                switch (key.Key)
                {
                    case ConsoleKey.N:
                        Console.Write("\nEnter name: ");
                        string? name = Console.ReadLine();
                        if (name != null) info.name = name;
                        break;
                    case ConsoleKey.G:
                        Console.Write("\nEnter gender: ");
                        string? gender = Console.ReadLine();
                        if (gender != null) info.gender = gender;
                        break;
                    case ConsoleKey.A:
                        Console.Write("\nEnter address: ");
                        string? address = Console.ReadLine();
                        if (address != null) info.address = address;
                        break;
                    case ConsoleKey.C:
                        Caretaker.addMemento(info.save());
                        break;
                    case ConsoleKey.U:
                        Caretaker.undo();
                        break;
                    case ConsoleKey.R:
                        Caretaker.redo();
                        break;
                    case ConsoleKey.P:
                        Console.WriteLine($"\n{info}");
                        break;
                    case ConsoleKey.E:
                        running = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        _logger.Info("Exit Memento Pattern!");
    }
}