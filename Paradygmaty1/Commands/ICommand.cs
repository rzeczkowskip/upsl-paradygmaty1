namespace Paradygmaty1.Commands;

public interface ICommand
{
    public string Name();

    public string Description();

    public void Execute();
}
