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
 *
 * Przekazywanie przez wynik wspiera język Ada. Oto przykład
 
   ```
   with Gnat.Io; use Gnat.Io;
   
   procedure proc is
   
   x : Integer;
   
   Procedure  PassByResult (A: out integer) is  
   begin
       A := A + 4; -- parametr A jest oznaczony jako `out`. Początkowa wartość lokalna to 0
   end PassByResult;
   
   begin 
       x := 1; -- ustawiamy wartość `x` na 1, aby zaprezentować brak przekazania wartości
       PassByResult (x);
       Put(x); -- x = 4
       New_Line;
   end proc;
   ```
   
   Jak widać, kod jest zbliżony do tego, który wykonujemy w C#;
 */
public class PassByResult: ICommand
{
    private readonly IOHelper _ioHelper;

    public PassByResult(IOHelper ioHelper)
    {
        _ioHelper = ioHelper;
    }
    
    public string Name()
    {
        return "Przekazywanie przez wynik";
    }
    public string Description()
    {
        throw new NotImplementedException();
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