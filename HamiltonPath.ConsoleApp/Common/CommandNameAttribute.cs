using System;

namespace HamiltonPath.ConsoleApp.Common
{
    /// <summary>
    /// Command Name Attribute - Custom Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class CommandNameAttribute : Attribute
    {
        /// <summary>
        /// Attribute Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Attribute Description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Command Name Attribute Constructor
        /// </summary>
        /// <param name="name">Attribute Name</param>
        /// <param name="description">Attribute Description</param>
        public CommandNameAttribute(string name, string description = "")
        {
            Name = name;
            Description = description;
        }
    }
}
