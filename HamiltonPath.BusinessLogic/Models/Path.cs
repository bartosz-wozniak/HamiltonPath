using System.Collections.Generic;

namespace HamiltonPath.BusinessLogic.Models
{
    /// <summary>
    ///     Path
    /// </summary>
    public sealed class Path
    {
        /// <summary>
        ///     Cost
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        ///     Path Verticles
        /// </summary>
        public List<int> Verticles { get; set; }

        /// <summary>
        ///     ToString Method
        /// </summary>
        /// <returns>String representation of Path</returns>
        public override string ToString()
        {
            return "Cost = " + Cost + "; Path = " + string.Join(", ", Verticles);
        }
    }
}
