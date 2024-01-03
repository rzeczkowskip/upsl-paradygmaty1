using Paradygmaty1.Model;

namespace Paradygmaty1.Commands;

/*
 * Przekazywanie przez referencję oznacza, że do podprogramu/funkcji przekazywany jest wskaźnik do zmiennej, a nie jej
 * wartość. Pozwala to na modyfikację wartości zmiennej bezpośrednio w podprogramie.
 
 * W C# obiekty są domyślnie przekazywane przez referencję
 *
 * Poniższy przykład prezentuje przekazywanie przez wartość. Krok po kroku:
 *
 * 1. Do zmiennej `x` zostaje przypisana losowa wartość liczbowa
 * 2. Zmienna zostaje przekazana do podprogramu `doCalculationsOnNumber`
 * 3. Program zostaje wstrzymany, a podprogram `doCalculationsOnNumber` rozpoczyna pracę
 * 3. Podprogram `doCalculationsOnNumber` wykonuje obliczenia na przekazanej zmiennej
 * 4. Oryginalna wartość zmiennej `x` pozostaje bez zmian
 */
public class PassByReference: ICommand
{
    public string Name()
    {
        return "Przekazywanie przez referencję";
    }

    public void Execute()
    {
        int modifiedPersonAgeCount;
        List<Person> children = new List<Person>()
        {
            new("Bob", 1),
            new("Alice", 10)
        };
        
        Person parent = new Person("John", 22, children);

        modifiedPersonAgeCount = 0;
        showPersonInfo("przed wywołaniem", parent, modifiedPersonAgeCount);
        Console.WriteLine();

        modifiedPersonAgeCount = 0;
        increasePersonAndChildrenAge(parent, ref modifiedPersonAgeCount);
        showPersonInfo("po dodaniu wieku", parent, modifiedPersonAgeCount);
        Console.WriteLine();

        modifiedPersonAgeCount = 0;
        parent.Children.Add(new Person("Mike", 7));
        showPersonInfo("po dodaniu 7 letniego dziecka", parent, modifiedPersonAgeCount);
        Console.WriteLine();

        modifiedPersonAgeCount = 0;
        increasePersonAndChildrenAge(parent, ref modifiedPersonAgeCount);
        showPersonInfo("po dodaniu wieku", parent, modifiedPersonAgeCount);
    }

    private void increasePersonAndChildrenAge(Person person, ref int modifiedPersonAgeCount)
    {
        modifiedPersonAgeCount += 1;
        person.Age += 1;
        foreach (var child in person.Children)
        {
            increasePersonAndChildrenAge(child, ref modifiedPersonAgeCount);
        }
    }

    private void showPersonInfo(string comment, Person person, int modifiedPersonAgeCount)
    {
        Console.WriteLine($"Wiek rodzica {comment}: {person.Age}");
        Console.WriteLine($"Ilość dzieci {comment}: {person.ChildrenCount()}");
        Console.WriteLine($"Suma wieku dzieci {comment}: {person.SumChildrenAge()}");
        Console.WriteLine($"Wiek zmieniony u {modifiedPersonAgeCount} osób.");
    }
}