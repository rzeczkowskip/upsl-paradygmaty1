using Paradygmaty1.Model;

namespace Paradygmaty1.Commands;

public class PassByReference: ICommand
{
    private readonly IOHelper _ioHelper;

    public PassByReference(IOHelper ioHelper)
    {
        _ioHelper = ioHelper;
    }
    
    public string Name()
    {
        return "Przekazywanie przez referencję";
    }

    public string Description()
    {
        return "Przekazywanie przez referencję oznacza, że do podprogramu/funkcji przekazywany jest wskaźnik do zmiennej," +
               "a nie jej wartość. Pozwala to na modyfikację wartości zmiennej bezpośrednio w podprogramie.\n" +
               "\n" +
               "W C# obiekty są domyślnie przekazywane przez referencje";
    }


    public void Execute()
    {
        _ioHelper.StepComment("Następuje przygotwanie zmiennych `modifiedPersonAgeCount` oraz `person`\n" +
                              "Obie będą przekazywane przez referencje do podprogramów. Zmienna `modifiedPersonAgeCount`\n" +
                              "Będzie śledziła ilość zmian w wieku modelu osoby i jej dzieci, a `person` to obiekt,\n" +
                              "w którym dokonujemy zmian (oraz w obiekatch zawartych w nim samym).");
        
        int modifiedPersonAgeCount = 0;
        List<Person> children = new List<Person>()
        {
            new("Bob", 1),
            new("Alice", 10)
        };
        
        Person parent = new Person("John", 22, children);
        
        reinitModifiedPersonAgeCount(ref modifiedPersonAgeCount);
        _ioHelper.StepComment("Następuje wywoałenie podprogramu `increasePersonAndChildrenAge`.");
        showPersonInfo("przed wywołaniem", parent, modifiedPersonAgeCount);
        
        _ioHelper.PressEnterToContinue();
        
        reinitModifiedPersonAgeCount(ref modifiedPersonAgeCount);
        _ioHelper.StepComment("Następuje wywoałenie podprogramu `increasePersonAndChildrenAge`.");
        increasePersonAndChildrenAge(parent, ref modifiedPersonAgeCount);
        _ioHelper.StepComment("Podprogram zakończył pracę");
        showPersonInfo("po dodaniu wieku", parent, modifiedPersonAgeCount);
        
        _ioHelper.PressEnterToContinue();

        reinitModifiedPersonAgeCount(ref modifiedPersonAgeCount);
        _ioHelper.StepComment("Następuje dodanie nowego dziecka do referencji listy dzieci.");
        parent.Children.Add(new Person("Mike", 7));
        _ioHelper.StepComment("Podprogram zakończył pracę.");
        showPersonInfo("po dodaniu 7 letniego dziecka", parent, modifiedPersonAgeCount);
        
        _ioHelper.PressEnterToContinue();

        reinitModifiedPersonAgeCount(ref modifiedPersonAgeCount);
        _ioHelper.StepComment("Następuje wywoałenie podprogramu `increasePersonAndChildrenAge`.");
        increasePersonAndChildrenAge(parent, ref modifiedPersonAgeCount);
        _ioHelper.StepComment("Podprogram zakończył pracę.");
        showPersonInfo("po dodaniu wieku", parent, modifiedPersonAgeCount);
    }

    private void increasePersonAndChildrenAge(Person person, ref int modifiedPersonAgeCount)
    {
        _ioHelper.StepComment($"  Zwiększanie wieku osoby {person.Name}");
        
        modifiedPersonAgeCount += 1;
        person.Age += 1;
        
        foreach (var child in person.Children)
        {
            increasePersonAndChildrenAge(child, ref modifiedPersonAgeCount);
        }
    }

    private void showPersonInfo(string comment, Person person, int modifiedPersonAgeCount)
    {
        _ioHelper.StepComment("Aktualne dane osoby:");
        _ioHelper.Result($"Wiek rodzica {comment} = {person.Age}");
        _ioHelper.Result($"Ilość dzieci {comment} = {person.ChildrenCount()}");
        _ioHelper.Result($"Suma wieku dzieci {comment} = {person.SumChildrenAge()}");
        _ioHelper.Result($"Wiek zmieniony u {modifiedPersonAgeCount} osób.");
    }

    private void reinitModifiedPersonAgeCount(ref int modifiedPersonAgeCount)
    {
        _ioHelper.StepComment("Wartość `modifiedPersonAgeCount` zostaje usatwiona na 0");
        modifiedPersonAgeCount = 0;
    }
}