// See https://aka.ms/new-console-template for more information

using Paradygmaty1;
using Paradygmaty1.Commands;

ICommand[] commands =
{
    new PassByValue(),
    new PassByResult(),
};

Orchestrator orchestrator = new Orchestrator(commands);
orchestrator.StartMainLoop();