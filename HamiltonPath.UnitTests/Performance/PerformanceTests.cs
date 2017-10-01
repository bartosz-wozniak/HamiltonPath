using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using HamiltonPath.BusinessLogic.Algorithm;
using HamiltonPath.BusinessLogic.Serialization;
using HamiltonPath.BusinessLogic.TaskGenerator;
using Xunit;

namespace HamiltonPath.UnitTests.Performance
{
    public class PerformanceTests
    {
        private readonly ITaskGenerator _taskGenerator;
        private readonly IAlgorithmProvider _algorithmProvider;
        private readonly Serializer _serializer;

        public PerformanceTests()
        {
            _serializer = new Serializer();
            _algorithmProvider = new AlgorithmProvider();
            _taskGenerator = new TaskGenerator(_serializer, _algorithmProvider);
        }

        private static IEnumerable<object[]> PerformanceTestData()
        {
            yield return new object[] {15,10};
        }

        [Theory]
        [MemberData(nameof(PerformanceTestData))]
        public void PerformanceTest(int maxVerticles, int maxExamplesForVerticles)
        {
            Directory.CreateDirectory("HamiltonPath\\PerformanceTest");
            Directory.CreateDirectory("HamiltonPath\\PerformanceTest\\Examples");

            const string csvPath = "HamiltonPath\\PerformanceTest\\results.csv";
            var exampleNumber = 1;

            using (var file = File.CreateText(csvPath))
            {
                file.WriteLineAsync("ExampleNumber, VerticlesCount, PathCost, CalculationTimeInMiliseconds, ElapsedTime");
            }

            //14*10
            for (var i = 2; i <= maxVerticles; i++)
            {
                for (var j = 1; j <= maxExamplesForVerticles; j++)
                {
                    var example = _taskGenerator.Generate(i);

                    var watch = new Stopwatch();

                    watch.Start();

                    var computedPath = _algorithmProvider.Compute(example);

                    watch.Stop();

                    SaveExampleDetailsToFile(exampleNumber, example, computedPath);

                    using (var file = File.AppendText(csvPath))
                    {
                        file.WriteLineAsync($"{exampleNumber},{i},{computedPath.Cost},{watch.ElapsedMilliseconds},{watch.Elapsed}");
                    }

                    exampleNumber++;
                }
            }
        }

        private void SaveExampleDetailsToFile(int exampleNumber, int[,] example, BusinessLogic.Models.Path computedPath)
        {
            //zapisać graf, wynik i czas -> do pliku (nr przykładu)
            var inputPath = $"HamiltonPath\\PerformanceTest\\Examples\\example_{exampleNumber}_input.txt";

            _serializer.SerializeGraph(inputPath, example);

            var outputPath = $"HamiltonPath\\PerformanceTest\\Examples\\example_{exampleNumber}_output.txt";

            _serializer.Serialize(outputPath, example, computedPath.ToString());
        }
    }
}
