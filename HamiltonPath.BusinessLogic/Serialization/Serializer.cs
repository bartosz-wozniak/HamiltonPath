using System;
using System.Collections.Generic;
using System.IO;
using HamiltonPath.BusinessLogic.Common;

namespace HamiltonPath.BusinessLogic.Serialization
{
    /// <inheritdoc/>
    public sealed class Serializer : ISerializer
    {
        /// <inheritdoc/>
        public void Serialize(string fileName, int[,] graph, string hamiltonPath)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                streamWriter.WriteLine(Consts.Serializer.GraphTitle);
                WriteGraph(graph, streamWriter);
                streamWriter.WriteLine(string.Empty);
                WriteHamiltonPath(hamiltonPath, streamWriter);
            }
        }

        /// <inheritdoc />
        public void SerializeGraph(string fileName, int[,] graph)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                WriteGraph(graph, streamWriter);
            }
        }

        /// <inheritdoc />
        public void SerializeTimes(string fileName, Dictionary<int, List<long>> times)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                foreach (var time in times.Keys)
                {
                    streamWriter.WriteLine(time + ": " + string.Join(", ", times[time]));
                }
            }
        }

        /// <inheritdoc/>
        public int[,] Deserialize(string fileName)
        {
            int[,] ret = null;
            using (var streamReader = new StreamReader(fileName))
            {
                var lineCounter = -1;
                while (!streamReader.EndOfStream)
                {
                    lineCounter = ReadLine(lineCounter, streamReader, ref ret);
                }
            }
            Validator.Validator.ValidateGraphMatrix(ret);
            return ret;
        }

        private static int ReadLine(int lineCounter, TextReader streamReader, ref int[,] ret)
        {
            ++lineCounter;
            var line = streamReader.ReadLine();
            var weights = line?.Split(new[] { Consts.SpecialCharacters.SpaceChar }, StringSplitOptions.RemoveEmptyEntries);
            if (weights == null)
            {
                throw new ArgumentException(Consts.Exceptions.InvalidLine);
            }
            if (ret == null)
            {
                ret = new int[weights.Length, weights.Length];
            }
            if (lineCounter >= ret.GetLength(0) || weights.Length != ret.GetLength(0))
            {
                throw new ArgumentException(Consts.Exceptions.NotSquereMatrix);
            }
            for (var i = 0; i < weights.Length; ++i)
            {
                int temp;
                if (int.TryParse(weights[i], out temp))
                {
                    ret[lineCounter, i] = temp;
                }
                else
                {
                    throw new ArgumentException(Consts.Exceptions.InvalidWeight);
                }
            }
            return lineCounter;
        }

        private static void WriteHamiltonPath(string hamiltonPath, TextWriter streamWriter)
        {
            streamWriter.WriteLine(Consts.Serializer.HamiltonPathTitle);
            streamWriter.WriteLine(hamiltonPath);
        }

        private static void WriteGraph(int[,] graph, TextWriter streamWriter)
        {
            if (graph == null)
            {
                streamWriter.WriteLine(Consts.Serializer.GraphNotLoaded);
            }
            else
            {
                for (var i = 0; i < graph.GetLength(0); ++i)
                {
                    var line = string.Empty;
                    for (var j = 0; j < graph.GetLength(1); ++j)
                        line += graph[i, j] + Consts.SpecialCharacters.SpaceString;
                    streamWriter.WriteLine(line);
                }
            }
        } 
    }
}
