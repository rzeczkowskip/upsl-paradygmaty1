namespace Paradygmaty1.Commands;


/*
 * Przekazywanie przez wartość i wynik wspiera język Ada. Oto przykład
 
   ```
   with Gnat.Io; use Gnat.Io;
   
   procedure proc is
   
   x : Integer;
   
   Procedure  PassByValueResult (A: in out integer) is  
   begin
       -- parametr A jest oznaczony jako `in` oraz `out`. Początkowa wartość lokalna to kopia przekazanej wartości
       A := A + 4;
   end PassByValueResult;
   
   begin 
       x := 1; -- ustawiamy wartość `x` na 1
       PassByValueResult (x);
       Put(x); -- x = 5
       New_Line;
   end proc;
   ```
 */
public class PassByValueResult: ICommand
{
    private readonly IOHelper _ioHelper;

    public PassByValueResult(IOHelper ioHelper)
    {
        _ioHelper = ioHelper;
    }
    
    public string Name()
    {
        return "Przekazywanie przez wartość-wynik";
    }
    public string Description()
    {
        return "Przekazywanie przez wartość i wynik jest połączeniem przekazywania przez wartość i przez wynik.\n" +
               "Parametr przekazywany do podprogramu jest jednocześnie wejśćiem (kopią przekazanej wartości) i wyjściem.\n" +
               "\n" +
               "W języku C# nie istnieje przekazywanie przez wartość i wynik. Konieczne jest użycie referencji lub kilku parametrów.\n" +
               "Ten przykład operuje na kilku parametrach, a komentarze opisują, w którym momencie parametry powinny być jednym.";
    }
    public void Execute()
    {
        int input = 1;
     
        _ioHelper.StepComment("Do podprogramu `passByValueResult` przekazywane są 2 parametry:\n" +
                              "`input = 1` oraz `out result` bez wartości.\n" +
                              "W rzeczywistości to powinien być jeden parametr, co zostanie zasymulowane w podprogramie.\n");
        
        _ioHelper.PressEnterToContinue();
        passByValueResult(input, out int result);
        
        _ioHelper.StepComment("Podprogram zakończył pracę");
        _ioHelper.PressEnterToContinue();
        
        _ioHelper.StepComment("Oto wynik zapisany w przekazanej zmiennej:");
        _ioHelper.Result($"result = {result}");
    }

    private void passByValueResult(int input, out int result)
    {
        _ioHelper.StepComment("Aby zasymulować zmienną `result` jako wejście, przypusujemy do niej wartość zmiennej `input`\n" +
                              "Od tej pory zmienna input będzie ignorowana.");

        result = input; // symulacja wyjścia i wejścia w jednej zmiennej

        _ioHelper.StepComment("Następuje przypisanie wartości `result + 1` do parametru `result`");
        
        result = result + 4;
    }
}