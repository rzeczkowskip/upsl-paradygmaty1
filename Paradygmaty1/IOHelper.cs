namespace Paradygmaty1;

public class IOHelper
{
    public void StepComment(string message = "")
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        foreach (var s in message.Split("\n"))
        {
            Console.WriteLine($"// {s}");
        }
        Console.ResetColor();
    }

    public void PressEnterToContinue()
    {
        Console.Write("Naciśnij [ENTER] aby kontynuować...");
        Console.ReadLine();
        Console.WriteLine();
    }

    public void Result(string message = "")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }

    public void Message(string message = "")
    {
        Console.WriteLine(message);
    }

    public void Info(string message = "")
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }

    public void Error(string message = "")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}