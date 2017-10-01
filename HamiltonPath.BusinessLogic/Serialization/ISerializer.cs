using System.Collections.Generic;

namespace HamiltonPath.BusinessLogic.Serialization
{
    /// <summary>
    ///     Serialization Interface
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        ///    Serializes To File
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <param name="graph">graph matrix</param>
        /// <param name="hamiltonPath">string representation of hamilton path</param>
        void Serialize(string fileName, int[,] graph, string hamiltonPath);

        /// <summary>
        ///    Serializes To File
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <param name="graph">graph matrix</param>
        void SerializeGraph(string fileName, int[,] graph);

        /// <summary>
        ///    Serializes To File
        /// </summary>
        /// <param name="fileName">Path</param>
        /// <param name="times">Times</param>
        void SerializeTimes(string fileName, Dictionary<int, List<long>> times);

        /// <summary>
        ///     Deserializes from file
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <returns></returns>
        int[,] Deserialize(string fileName);
    }
}
