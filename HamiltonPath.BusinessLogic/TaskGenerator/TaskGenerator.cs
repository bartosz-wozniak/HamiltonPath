using System;
using System.Collections.Generic;
using System.Diagnostics;
using HamiltonPath.BusinessLogic.Algorithm;
using HamiltonPath.BusinessLogic.Serialization;

namespace HamiltonPath.BusinessLogic.TaskGenerator
{
    /// <inheritdoc/>
    public sealed class TaskGenerator : ITaskGenerator
    {
        private readonly ISerializer _serializer;

        private readonly IAlgorithmProvider _algorithmProvider;

        private const int MaxRnd = 1000;

        /// <summary>
        /// Constructor
        /// </summary>
        public TaskGenerator() {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serializer">Serializer</param>
        /// <param name="algorithmProvider">Algorithm implementantion</param>
        public TaskGenerator(ISerializer serializer, IAlgorithmProvider algorithmProvider)
        {
            _serializer = serializer;
            _algorithmProvider = algorithmProvider;
        }

        /// <summary>
        /// Generates and saves to file random graph
        /// </summary>
        /// <param name="n">Number of verticles in graph</param>
        /// <param name="path">File to save graph</param>
        public void GenerateAndSave(int n, string path)
        {
            var graph = Generate(n);
            _serializer.SerializeGraph(path, graph);
        }

        /// <summary>
        /// Generates random graph
        /// </summary>
        /// <param name="n">Number of verticles in graph</param>
        /// <returns></returns>
        public int[,] Generate(int n)
        {
            var graph = new int[n, n];
            var rnd = new Random();
            for (var i = 1; i < n; ++i)
            {
                for (var j = 0; j < i; ++j)
                {
                    graph[j, i] = graph[i, j] = rnd.Next(MaxRnd);
                }
            }
            return graph;
        }

        /// <inheritdoc />
        public void GenerateAndComputeMultiple()
        {
            var dictionary = new Dictionary<int, List<long>>();
            for (var i = 2; i < 12; ++i)
            {
                dictionary.Add(i, new List<long>());
            }
            System.IO.Directory.CreateDirectory("HamiltonPath");
            System.IO.Directory.CreateDirectory("HamiltonPath\\Input");
            System.IO.Directory.CreateDirectory("HamiltonPath\\Output");
            foreach (var key in dictionary.Keys)
            {
                for (var i = 0; i < 100; ++i)
                {
                    var inputPath = "HamiltonPath\\Input\\graph" + key + "_" + i + ".txt";
                    var outputPath = "HamiltonPath\\Output\\graph" + key + "_" + i + ".txt";
                    GenerateAndSave(key, inputPath);
                    var graph = _serializer.Deserialize(inputPath);
                    var sw = Stopwatch.StartNew();
                    var hamiltonPath = _algorithmProvider.Compute(graph).ToString();
                    sw.Stop();
                    _serializer.Serialize(outputPath, graph, hamiltonPath);
                    dictionary[key].Add(sw.ElapsedMilliseconds);
                }
            }
            const string timesPath = "HamiltonPath\\times.txt";
            _serializer.SerializeTimes(timesPath, dictionary);
        }
    }
}
