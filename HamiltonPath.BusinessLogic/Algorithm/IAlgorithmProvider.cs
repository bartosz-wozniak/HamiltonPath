using HamiltonPath.BusinessLogic.Models;

namespace HamiltonPath.BusinessLogic.Algorithm
{
    /// <summary>
    ///     Algorithm Provider
    /// </summary>
    public interface IAlgorithmProvider
    {
        /// <summary>
        ///     Run Algorithm
        /// </summary>
        /// <param name="graph">Graph Matrix</param>
        /// <returns>Hamilton Path</returns>
        Path Compute(int[,] graph);
    }
}
