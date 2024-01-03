// See https://aka.ms/new-console-template for more information

using Paradygmaty1;
using Paradygmaty1.Commands;

ICommand[] commands =
{
    // new TestCommand()
};

Orchestrator orchestrator = new Orchestrator(commands);
orchestrator.StartMainLoop();