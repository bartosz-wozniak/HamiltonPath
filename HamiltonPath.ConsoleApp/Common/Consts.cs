namespace HamiltonPath.ConsoleApp.Common
{
    /// <summary>
    /// Constants
    /// </summary>
    internal static class Consts
    {
        internal static class Commands
        {
            internal const string Help = "help";

            internal const string HelpDescription = "Displays help";

            internal const string HamiltonPath = "find-hamilton-path";

            internal const string HamiltonPathDescription = "Finds Hamilton Path";

            internal const string GenerateGraph = "generate-graph";

            internal const string GenerateGraphDescription = "Generates Graph that can be used as input for algorithm";

            internal const string GenerateAndCompute = "generate-compute-graph";

            internal const string GenerateAndComputeDescription = "Generates 100 graphs for each number of verticles from 2 to 11 and runs algorithm for each sample and saves to a file measured times";
        }

        internal static class Comments
        {
            internal const string AvailableCommands = "Available Commands: ";

            internal const string Dash = " - ";

            internal const string JobStarted = "Job Started";

            internal const string JobEnded = "Job Ended";

            internal const string Parameters = "Parameters: ";

            internal const string LogName = "LogName";

            internal const string Space = " ";

            internal const string NoCommand = "No command specified";

            internal const string Exception = "Job Error (Stack Trace, Message, Inner Exception Message): ";
        }
    }
}
