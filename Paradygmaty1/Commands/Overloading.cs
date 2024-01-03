using Paradygmaty1.Model;

namespace Paradygmaty1.Commands;

public class Overloading: ICommand
{
    public string Name()
    {
        return "Przeciążanie parametrów";
    }

    public void Execute()
    {
        int intSumResult = Sum(1, 2);
        double doubleSumResult = Sum(1, 0.23);
        double stringToDoubleSumResult = Sum("1", "1.23");
        
        Console.WriteLine($"{intSumResult} {doubleSumResult} {stringToDoubleSumResult}");
    }

    private int Sum(int a, int b)
    {
        return a + b;
    }

    private double Sum(double a, double b)
    {
        return a + b;
    }

    private double Sum(string a, string b)
    {
        bool isValidA = double.TryParse(a, out double aInt);
        bool isValidB = double.TryParse(b, out double bInt);

        if (!isValidA || !isValidB)
        {
            Console.Error.WriteLine("Niepoprawna wartośc {a} lub {b}. Wartości muszą być numerycznymi ciągami znaków.");
            return 0;
        }

        return aInt + bInt;
    }
}