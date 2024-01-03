namespace Paradygmaty1.Model;

public class Person
{
    public string Name { get; }
    public int Age;
    public List<Person> Children { get; }

    public Person(string name, int age, List<Person> children)
    {
        Name = name;
        Age = age;
        Children = children;
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Children = new List<Person>();
    }

    public int ChildrenCount()
    {
        return Children.Count;
    }

    public int SumChildrenAge()
    {
        return Children.ToList().ConvertAll(child => child.Age).Sum();
    }

    public List<Person> GetChildren()
    {
        return Children;
    }
}