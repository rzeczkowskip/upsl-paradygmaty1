namespace Paradygmaty1.Commands;


/*
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
        return
            "Przekazywanie przez wynik oznacza, że do podprogramu/funkcji przekazywana jest zmienna, do której przypisywana jest wartość w podprogramie.\n" +
            "Nie jest to jednak przekazywanie przez referencję, gdzie przekazywany jest wkaźnik do zmiennej.\n" +
            "\n" +
            "W języku C# nabradziej zbliżonym sposobem zaprezentowania przekazywania przez wynik jest użycie modyfikatora `out`.\n" +
            "\n" +
            "Przekazywanie przez wynik wspiera język Ada. W kodzie źródłowym klasy został umieszczony przykład w tym języku.";
    }
    public void Execute()
    {
        _ioHelper.StepComment("Do podprogramu `passByResult` zostaje przekazany parametr jako zmienna `out int result`\n" +
                              "Parametr `result` nie został wcześniej zainicjowany.\n");
        
        passByResult(out int result);
        
        _ioHelper.StepComment("Podprogram zakończył pracę. Oto wynik zapisany w przekazanej zmiennej:");
        _ioHelper.Result($"result = {result}");
    }

    private void passByResult(out int result)
    {
        _ioHelper.StepComment("W podprogramie nie ma możliwości wykonanie operacji z wykorzystaniem wartości przekazanej zmiennej.\n" +
                              "Możliwe jest jedynie przypisanei wartości. Wyreżenie `result += 1` zwróci błąd.\n");
        
        _ioHelper.StepComment("Następuje przypisanie wartości `1` do parametru `result`");
        result = 1;
    }
}