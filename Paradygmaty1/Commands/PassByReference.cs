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
               "W C# obiekty są domyślnie przekazywane przez referencje.\n" +
               "Referencją może również być wskaźnik fukncji.";
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
        
        _ioHelper.Info("\nReferencją może również być wskaźnik funkcji.\n");
        _ioHelper.StepComment("Mając 2 podprogramy:\n" +
                              "  * `printPerson`, który przyjmuje obiekt `Person` aby wyświetlić jego dane\n" +
                              "  * `runCallbackOnPersonsChildren`, który przyjmuje obiekt `Person` oraz wskażnik funkcji, do którego trafią jego dzieci\n" +
                              "Następuje wywołanie `runCallbackOnPersonsChildren` z parametrami `person = parent` oraz wskaźnikiem `callback = printPerson`");
        
        runCallbackOnPersonsChildren(parent, printPerson);
        _ioHelper.StepComment("Podprogram zakończył pracę.");
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

    private void printPerson(Person person)
    {
        _ioHelper.Result($"  {person.Name} ({person.Age})");
    }

    private void runCallbackOnPersonsChildren(Person person, Action<Person> callback)
    {
        person.Children.ForEach(callback);
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