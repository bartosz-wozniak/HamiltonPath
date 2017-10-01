using System.Collections.Generic;
using HamiltonPath.BusinessLogic.TaskGenerator;
using HamiltonPath.ConsoleApp.Common;

namespace HamiltonPath.ConsoleApp.Command
{
    /// <summary>
    /// Generate Graph Command
    /// </summary>
    [CommandName(Consts.Commands.GenerateAndCompute, Consts.Commands.GenerateAndComputeDescription)]
    internal sealed class GenerateAndComputeCommand : ICommand
    {
        private readonly ITaskGenerator _taskGenerator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="taskGenerator">TaskGenerator</param>
        public GenerateAndComputeCommand(ITaskGenerator taskGenerator)
        {
            _taskGenerator = taskGenerator;
        }

        /// <summary>
        /// Parametress constructor
        /// </summary>
        public GenerateAndComputeCommand()
        {

        }

        /// <summary>
        /// Generates graph that can be used as an input for algorith and saves to an output file
        /// </summary>
        /// <param name="parameters">number of verticles, output path file</param>
        public void Execute(IEnumerable<string> parameters)
        {
            _taskGenerator.GenerateAndComputeMultiple();
        }
    }
}
