namespace Paradygmaty1.Commands;


/*
 * Przekazywanie przez wartość i wynik jest połączeniem przekazywania przez wartość i przez wynik. Parametr przekazywany
 * do podprogramu jest jednocześnie wejśćiem (kopią przekazanej wartości) i wyjściem.
 *
 * W języku C# nie istnieje przekazywanie przez wartość i wynik. Konieczne jest użycie referencji lub kilku parametrów.
 * Poniższy przykład operuje na kilku parametrach, a komentarze opisują, w którym momencie parametry powinny być jednym.
 *
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
    public string Name()
    {
        return "Przekazywanie przez wynik";
    }

    public void Execute()
    {
        int input = 1;
        // przekazujemy oba parametry w związku z niedoskonałością języka do zaprezentowania przykładu
        // w rzeczywistości, powinna to być jedna zmienna, co zostanie zasymulowane w podprogramie
        passByValueResult(input, out int result);
        
        Console.WriteLine(result);
    }

    private void passByValueResult(int input, out int result)
    {
        result = input; // symulacja wyjścia i wejścia w jednej zmiennej
        
        // obliczenia
        result = input + 4;
    }
}