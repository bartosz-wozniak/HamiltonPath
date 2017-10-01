using System;
using System.Collections.Generic;
using System.Reflection;
using HamiltonPath.ConsoleApp.Common;

namespace HamiltonPath.ConsoleApp.Command
{
    /// <summary>
    /// Help Command Displays help
    /// </summary>
    [CommandName(Consts.Commands.Help, Consts.Commands.HelpDescription)]
    internal sealed class HelpCommand : ICommand
    {
        /// <summary>
        /// Runs help command
        /// </summary>
        /// <param name="parameters">parameters are ignored</param>
        public void Execute(IEnumerable<string> parameters)
        {
            Console.WriteLine(Consts.Comments.AvailableCommands);
            foreach (var command in CommandHelper.GetAvailableCommandNames(Assembly.GetExecutingAssembly()))
            {
                Console.WriteLine(command.Name + Consts.Comments.Dash + command.Description);
            }
        }
    }
}
