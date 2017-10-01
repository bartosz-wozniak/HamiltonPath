using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HamiltonPath.ConsoleApp.Command;

namespace HamiltonPath.ConsoleApp.Common
{
    /// <summary>
    /// Command Helper class
    /// </summary>
    internal static class CommandHelper
    {
        /// <summary>
        /// Check weather a given type is a command (implements ICommand and has a commandName attribute)
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static bool IsCommand(Type type)
        {
            return typeof(ICommand).IsAssignableFrom(type) && Attribute.GetCustomAttribute(type, typeof(CommandNameAttribute)) != null;
        }

        /// <summary>
        /// Gets Command Name from attribute
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static CommandNameAttribute GetCommandName(Type type)
        {
            return (CommandNameAttribute)Attribute.GetCustomAttribute(type, typeof(CommandNameAttribute));
        }

        /// <summary>
        /// Gets all command names from given assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static IEnumerable<CommandNameAttribute> GetAvailableCommandNames(Assembly assembly)
        {
            return assembly.GetTypes().Where(IsCommand).Select(GetCommandName).OrderBy(c => c.Name);
        }
    }
}
