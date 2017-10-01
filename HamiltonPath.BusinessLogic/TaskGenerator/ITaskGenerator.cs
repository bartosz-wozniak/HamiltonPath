namespace HamiltonPath.BusinessLogic.TaskGenerator
{
    /// <summary>
    /// Interface for Graph Generator, Generates graphs
    /// </summary>
    public interface ITaskGenerator
    {
        /// <summary>
        /// Generates graph and saves to a file
        /// </summary>
        /// <param name="n">Number of verticles</param>
        /// <param name="path">Output file path</param>
        void GenerateAndSave(int n, string path);

        /// <summary>
        /// Generates graph
        /// </summary>
        /// <param name="n">Number of verticles</param>
        int[,] Generate(int n);

        /// <summary>
        /// Generates and Computes multiple problems
        /// </summary>
        void GenerateAndComputeMultiple();
    }
}
