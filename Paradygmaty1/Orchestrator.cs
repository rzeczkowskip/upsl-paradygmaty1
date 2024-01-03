using Paradygmaty1.Commands;

namespace Paradygmaty1;

public class Orchestrator
{
    private readonly ICommand[] _commands;

    public Orchestrator(ICommand[] commands)
    {
        if (commands.Length == 0)
        {
            throw new Exception("Command list has to include at least 1 command.");
        }
        
        _commands = commands;
    }

    public void StartMainLoop()
    {
        while (true)
        {
            int commandToRun = AskWhichCommandToRun();

            if (commandToRun == -1)
            {
                return;
            }
        
            _commands[commandToRun].Execute();
        }
    }

    private int AskWhichCommandToRun()
    {
        Console.WriteLine("Wybierz przykład do uruchomienia:");
        Console.WriteLine();
        
        for (var i = 0; i < _commands.Length; i++)
        {
            Console.WriteLine($"\t{i+1} - {_commands[i].Name()}");
        }
        
        Console.WriteLine("\n\tq - Wyjście z programu\n");
        
        while (true)
        {
            Console.Write("Twój wybór: ");
            string? optionInput = Console.ReadLine();

            if (optionInput == "q")
            {
                return -1;
            }

            bool isValidIntInput = int.TryParse(optionInput, out int selectedOption);
            if (isValidIntInput && selectedOption > 0 && selectedOption <= _commands.Length)
            {
                return selectedOption - 1;
            }
            
            Console.WriteLine("Błędna opcja, spróbuj ponownie.");
            
        }
    }
}