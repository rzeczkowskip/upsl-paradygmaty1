// See https://aka.ms/new-console-template for more information

using Paradygmaty1;
using Paradygmaty1.Commands;

ICommand[] commands =
{
    new PassByValue()
};

Orchestrator orchestrator = new Orchestrator(commands);
orchestrator.StartMainLoop();