using System.Collections.Generic;

namespace HamiltonPath.ConsoleApp.Command
{
    /// <summary>
    /// ICammand interface
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Execute command method
        /// </summary>
        /// <param name="parameters">Method arguments</param>
        void Execute(IEnumerable<string> parameters);
    }
}
