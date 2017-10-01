using System.Collections.Generic;
using System.Linq;
using HamiltonPath.BusinessLogic.Algorithm;
using HamiltonPath.BusinessLogic.Serialization;
using HamiltonPath.ConsoleApp.Common;

namespace HamiltonPath.ConsoleApp.Command
{
    /// <summary>
    /// Find Hamilton Path Command
    /// </summary>
    [CommandName(Consts.Commands.HamiltonPath, Consts.Commands.HamiltonPathDescription)]
    internal sealed class FindHamiltonPathCommand : ICommand
    {
        private readonly ISerializer _serializer;
        private readonly IAlgorithmProvider _algorithmProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serializer">Serializer</param>
        /// <param name="algorithmProvider">Algorithm Provider</param>
        public FindHamiltonPathCommand(ISerializer serializer, IAlgorithmProvider algorithmProvider)
        {
            _serializer = serializer;
            _algorithmProvider = algorithmProvider;
        }

        /// <summary>
        /// Parametress constructor
        /// </summary>
        public FindHamiltonPathCommand()
        {

        }

        /// <summary>
        /// Finds Hamilton Path and saves output to file
        /// </summary>
        /// <param name="parameters">Input path file, output path file</param>
        public void Execute(IEnumerable<string> parameters)
        {
            var enumerable = parameters as IList<string> ?? parameters.ToList();
            _serializer.Serialize(enumerable[1], _serializer.Deserialize(enumerable[0]), _algorithmProvider.Compute(_serializer.Deserialize(enumerable[0])).ToString());
        }
    }
}
