using Paradygmaty1.Commands;

namespace Paradygmaty1;

public class Orchestrator
{
    private readonly IOHelper _ioHelper;
    private readonly ICommand[] _commands;

    public Orchestrator(IOHelper ioHelper, ICommand[] commands)
    {
        if (commands.Length == 0)
        {
            throw new Exception("Command list has to include at least 1 command.");
        }

        _ioHelper = ioHelper;
        _commands = commands;
    }

    public void StartMainLoop()
    {
        while (true)
        {
            int commandIndexToRun = AskWhichCommandToRun();

            if (commandIndexToRun == -1)
            {
                return;
            }

            ICommand command = _commands[commandIndexToRun];
            
            _ioHelper.Message($"\n{command.Name()}\n");
            _ioHelper.Info($"{command.Description()}\n");
            _ioHelper.Info($"Kod tego przykładu możesz zobaczyć w kodzie zródłowym w klasie: {command.GetType().FullName}");
            PressEnterToContinue();
            
            _ioHelper.Message("\n=== Start  ===\n");
            
            command.Execute();

            _ioHelper.Message("\n=== Koniec ===\n");
            PressEnterToContinue();
        }
    }

    private int AskWhichCommandToRun()
    {
        _ioHelper.Message("Wybierz przykład do uruchomienia:");
        _ioHelper.Message();
        
        for (var i = 0; i < _commands.Length; i++)
        {
            _ioHelper.Message($"\t{i+1} - {_commands[i].Name()}");
        }
        
        _ioHelper.Message("\n\tq - Wyjście z programu\n");
        
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
            
            _ioHelper.Message("Błędna opcja, spróbuj ponownie.");
            
        }
    }

    private void PressEnterToContinue()
    {
        Console.Write("Naciśnij [ENTER] aby kontynuować...");
        Console.ReadLine();
    }
}