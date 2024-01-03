using System.Globalization;
using Paradygmaty1.Model;

namespace Paradygmaty1.Commands;

public class Overloading: ICommand
{
    private readonly IOHelper _ioHelper;

    public Overloading(IOHelper ioHelper)
    {
        _ioHelper = ioHelper;
    }
    
    public string Name()
    {
        return "Przeciążanie parametrów";
    }

    public string Description()
    {
        return "W dużym uproszczeniu, przeciążanie pozwala na stworzenie wielu funkcji o tej samej nazwie, ale o różnych\n" +
               "zestawach parametrów. Każda z funkcji musi różnić się conajmniej jednym z następujących elementów:\n" +
               "  * Liczba parametrów\n" +
               "  * Typy parametrów\n" +
               "  * Kolejnością parametrów\n" +
               "\n" +
               "W przykładzie tego programu przygotowana została funckja dodająca 2 wartości `a` oraz `b`.\n" +
               "Obie wartości muszą być tego samego typu, a te typt to `int`, `double` oraz `string`\n" +
               "Wartości `string` zamieniane są na `double` i dopiero sumowane.";
    }

    public void Execute()
    {
        _ioHelper.PressEnterToContinue();
        ;
        int intSumResult = Sum(1, 2);
        _ioHelper.StepComment("Podprogram zakończył pracę");
        _ioHelper.Result($"x = {intSumResult}");
        _ioHelper.PressEnterToContinue();
        
        double doubleSumResult = Sum(1, 0.23);
        _ioHelper.StepComment("Podprogram zakończył pracę");
        _ioHelper.Result($"x = {doubleSumResult}");
        _ioHelper.PressEnterToContinue();
        
        double stringToDoubleSumResult = Sum("1", "1.23");
        _ioHelper.StepComment("Podprogram zakończył pracę");
        _ioHelper.Result($"x = {stringToDoubleSumResult}");
    }

    private int Sum(int a, int b)
    {
        sumValuesComment(a, b);
        return a + b;
    }

    private double Sum(double a, double b)
    {
        sumValuesComment(a, b);
        return a + b;
    }

    private double Sum(string a, string b)
    {
        bool isValidA = double.TryParse(a, NumberStyles.Any, CultureInfo.InvariantCulture, out double aNumber);
        bool isValidB = double.TryParse(b, NumberStyles.Any, CultureInfo.InvariantCulture, out double bNumber);

        if (!isValidA || !isValidB)
        {
            _ioHelper.Error("Niepoprawna wartość {a} lub {b}. Wartości muszą być numerycznymi ciągami znaków.");
            return 0;
        }

        sumValuesComment(a, b);
        _ioHelper.StepComment("Przekazanie wykonania do `Sum(double a, double b)`");
        return Sum(aNumber, bNumber);
    }

    private void sumValuesComment(dynamic a, dynamic b)
    {
        _ioHelper.StepComment($"Sumowanie wartości {a} ({a.GetType().Name}) i {b} ({b.GetType().Name})");
    }
}