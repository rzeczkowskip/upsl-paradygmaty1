namespace Paradygmaty1.Commands;

public class PassByValue: ICommand
{
    private readonly IOHelper _ioHelper;

    public PassByValue(IOHelper ioHelper)
    {
        _ioHelper = ioHelper;
    }
    
    public string Name()
    {
        return "Przekazywanie przez wartość";
    }
    public string Description()
    {
        return
            "* Przekazywanie przez wartość oznacza, że do podprogramu/funkcji przekazywana jest kopia wartości zmiennej, a nie sama wartość.\n" +
            "\n" +
            "W C#, typy proste oraz struktury domyślnie są przekazywane przez wartość.\n" +
            "Poniższy przykład prezentuje przekazywanie przez wartość.";
    }
    public void Execute()
    {
        _ioHelper.StepComment("Przypisanie początkowej wartości do `x`");
        int x = 420;
        
        _ioHelper.StepComment("Wartość przez obliczeniami:");
        _ioHelper.Result($"x = {x}\n");
        
        _ioHelper.StepComment("Przekazanie wartości `x` do podprogramu `doCalculationsOnNumber`\n" +
                              "W tym momencie program zostaje wstrzymany, a podprogram rozpoczyna pracę.");
        
        _ioHelper.PressEnterToContinue();
        
        int result = doCalculationsOnNumber(x);
        
        _ioHelper.PressEnterToContinue();
        
        // wiadomości z podprogramu zostaną wyświetlone PRZED poniższymi w związku ze wstrzymaniem
        // wykonywania programu na czas działana podprogramu
        _ioHelper.StepComment($"Wartość po obliczeniach (x - wartość oryginalna, x2 - wartość po obliczeniach):");
        _ioHelper.Result($"x = {x}, x2 = {result}");
        
        _ioHelper.Info("Jak widać, mimo modyfikacji zmiennej w podprogramie, oryginalna zmienna zachowała swoją wartość.");
    }

    private int doCalculationsOnNumber(int x)
    {
        _ioHelper.StepComment($"Na przekazanej wartości `x` ({x}) wykonanie zostaje równanie `x - x + 2`");
        x = x - x + 2;
        
        _ioHelper.StepComment("Wartość w podprogramie wykonującym obliczenia:");
        _ioHelper.Result($"x = {x}\n");

        return x;
    } 
}