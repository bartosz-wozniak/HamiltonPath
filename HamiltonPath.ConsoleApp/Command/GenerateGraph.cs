using System;
using System.Collections.Generic;
using System.Linq;
using HamiltonPath.BusinessLogic.TaskGenerator;
using HamiltonPath.ConsoleApp.Common;

namespace HamiltonPath.ConsoleApp.Command
{
    /// <summary>
    /// Generate Graph Command
    /// </summary>
    [CommandName(Consts.Commands.GenerateGraph, Consts.Commands.GenerateGraphDescription)]
    internal sealed class GenerateGraphCommand : ICommand
    {
        private readonly ITaskGenerator _taskGenerator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="taskGenerator">TaskGenerator</param>
        public GenerateGraphCommand(ITaskGenerator taskGenerator)
        {
            _taskGenerator = taskGenerator;
        }

        /// <summary>
        /// Parametress constructor
        /// </summary>
        public GenerateGraphCommand()
        {

        }

        /// <summary>
        /// Generates graph that can be used as an input for algorith and saves to an output file
        /// </summary>
        /// <param name="parameters">number of verticles, output path file</param>
        public void Execute(IEnumerable<string> parameters)
        {
            var enumerable = parameters as IList<string> ?? parameters.ToList();

            int n;
            if (!int.TryParse(enumerable[0], out n))
            {
                throw new ArgumentException("N is not a number");
            }
            _taskGenerator.GenerateAndSave(n, enumerable[1]);
        }
    }
}
