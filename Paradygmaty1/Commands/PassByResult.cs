namespace Paradygmaty1.Commands;


/*
 * Przekazywanie przez wynik oznacza, że do podprogramu/funkcji przekazywana jest zmienna, do której przypisywana jest
 * wartość w podprogramie. Nie jest to jednak przekazywanie przez referencję, gdzie przekazywany jest wkaźnik do
 * zmiennej.
 *
 * W języku C# nabradziej zbliżonym sposobem zaprezentowania przekazywania przez wynik jest użycie modyfikatora `out`.
 *
 * 1. Do podprogramu `passByResult` przekazywana jest zmienna `result` bez wartości początkowej
 * 2. Zmienna `result` zachowuje się jak parametr lokalny
 * 3. Po wykonaniu obliczeń w `passByResult`, wynik przypisywany jest do zmiennej `result` i trafia do programu
 *    głównego.
 */
public class PassByResult: ICommand
{
    public string Name()
    {
        return "Przekazywanie przez wynik";
    }

    public void Execute()
    {
        // utworzenie i przekazanie zmiennej `result` do podprogramu
        passByResult(out int result);
        
        Console.WriteLine(result);
    }

    private void passByResult(out int result)
    {
        // nie można wykonać operacji na result przed przypisaniem wartości do zmiennej
        // `result += 1;` zwróci błąd

        // przypisanie wartości do przekazanej zmiennej
        result = 1;
    }
}