namespace Paradygmaty1.Commands;

/*
 * Przekazywanie przez wartość oznacza, że do podprogramu/funkcji przekazywana jest kopia
 * wartości zmiennej, a nie sama wartość.
 *
 * W C#, typy proste oraz struktury domyślnie są przekazywane przez wartość.
 *
 * Poniższy przykład prezentuje przekazywanie przez wartość. Krok po kroku:
 *
 * 1. Do zmiennej `x` zostaje przypisana losowa wartość liczbowa
 * 2. Zmienna zostaje przekazana do podprogramu `doCalculationsOnNumber`
 * 3. Program zostaje wstrzymany, a podprogram `doCalculationsOnNumber` rozpoczyna pracę
 * 3. Podprogram `doCalculationsOnNumber` wykonuje obliczenia na przekazanej zmiennej
 * 4. Oryginalna wartość zmiennej `x` pozostaje bez zmian
 */
public class PassByValue: ICommand
{
    private readonly Random _rng = new();
    
    public string Name()
    {
        return "Przekazywanie przez wartość";
    }
    
    public void Execute()
    {
        // przypisanie losowej wartości
        int x = _rng.Next();
        
        Console.WriteLine("Wartość przez obliczeniami:");
        Console.WriteLine($"x = {x}\n");
        
        // przekazanie zmiennej do podprogramu
        doCalculationsOnNumber(x);
        
        // wiadomości z podprogramu zostaną wyświetlone PRZED poniższymi w związku ze wstrzymaniem
        // wykonywania programu na czas działana podprogramu
        Console.WriteLine($"Wartość po obliczeniach:");
        Console.WriteLine($"x = {x}\n");
    }

    private void doCalculationsOnNumber(int x)
    {
        // wykonanie obliczeń i przypisanie wyniku do przekazanej zmiennej
        x = x / 2;
        
        Console.WriteLine($"Wartość w podprogramie wykonującym obliczenia:");
        Console.WriteLine($"x = {x}\n");
    } 
}