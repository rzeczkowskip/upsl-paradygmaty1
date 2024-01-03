// See https://aka.ms/new-console-template for more information

using Paradygmaty1;
using Paradygmaty1.Commands;

IOHelper ioHelper = new IOHelper();

ICommand[] commands =
{
    new PassByValue(ioHelper),
    new PassByResult(ioHelper),
    new PassByValueResult(ioHelper),
    new PassByReference(ioHelper),
    new Overloading(ioHelper),
};

Orchestrator orchestrator = new Orchestrator(ioHelper, commands);
orchestrator.StartMainLoop();