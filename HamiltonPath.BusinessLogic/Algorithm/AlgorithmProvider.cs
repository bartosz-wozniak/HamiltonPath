using System.Collections.Generic;
using System.Linq;
using HamiltonPath.BusinessLogic.Models;

namespace HamiltonPath.BusinessLogic.Algorithm
{
    /// <inheritdoc/>
    public sealed class AlgorithmProvider : IAlgorithmProvider
    {
        /// <inheritdoc/>
        public Path Compute(int[,] graph)
        {
            Validator.Validator.ValidateGraphMatrix(graph);
            var bestPath = new Path { Cost = int.MaxValue };
            var verticles = new List<int>();
            for (var i = 0; i < graph.GetLength(0); ++i)
            {
                verticles.Add(i);
            }

            for (var k = 1; k < graph.GetLength(0); ++k)
            {
                for (var j = 0; j < k; ++j)
                {
                    var path = Hpa(graph, j, k, verticles);
                    if (path.Cost < bestPath.Cost)
                    {
                        bestPath = path;
                    }
                }
            }
            return bestPath;
        }

        private static Path Hpa(int[,] graph, int start, int finish, List<int> verticles)
        {
            if (verticles.Count <= 3)
            {
                return FindPath(graph, start, finish, verticles);
            }

            var localBestPath = new Path { Cost = int.MaxValue };
            var v = verticles.Where(item => item != start && item != finish).ToList();

            foreach (var center in v)
            {
                var u = v.Where(item => item != center).ToList();
                var subsets = new List<List<int>>();
                GetCombinations(u.Count - 1, u.Count / 2, new bool[u.Count], u, subsets);

                foreach (var a in subsets)
                {
                    var b = u.Where(item => !a.Contains(item)).ToList();
                    a.AddRange(new[] { start, center });
                    b.AddRange(new[] { center, finish });
                    var aHpa = Hpa(graph, start, center, a);
                    var bHpa = Hpa(graph, center, finish, b);
                    var hpa = ConcatenatePaths(bHpa, aHpa);
                    if (hpa.Cost < localBestPath.Cost)
                    {
                        localBestPath = hpa;
                    }
                }
            }
            return localBestPath;
        }

        private static Path ConcatenatePaths(Path bHpa, Path aHpa)
        {
            bHpa.Verticles.RemoveAt(0);
            aHpa.Verticles.AddRange(bHpa.Verticles);
            var hpa = new Path
            {
                Cost = aHpa.Cost + bHpa.Cost,
                Verticles = aHpa.Verticles
            };
            return hpa;
        }

        private static Path FindPath(int[,] graph, int start, int finish, List<int> verticles)
        {
            var path = new Path { Verticles = new List<int> { start } };
            if (verticles.Count == 3)
            {
                path.Verticles.Add(verticles.Find(item => item != start && item != finish));
            }
            path.Verticles.Add(finish);
            for (var i = 1; i < path.Verticles.Count; ++i)
            {
                path.Cost += graph[path.Verticles[i - 1], path.Verticles[i]];
            }
            return path;
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        private static void GetCombinations(int n, int r, IList<bool> used, IReadOnlyList<int> verticles, List<List<int>> combinations)
        {
            if (r == 0)
            {
                var combination = new List<int>();
                for (var i = 0; i < used.Count; ++i)
                {
                    if (used[i])
                    {
                        combination.Add(verticles[i]);
                    }
                }
                combinations.Add(combination);
            }
            else if (n < 0)
            {

            }
            else
            {
                used[n] = true;
                GetCombinations(n - 1, r - 1, used, verticles, combinations);
                used[n] = false;
                // ReSharper disable once TailRecursiveCall
                GetCombinations(n - 1, r, used, verticles, combinations);
            }
        }

        [System.Obsolete("GetSubsets<T> is deprecated, please use GetCombinations instead.", true)]
        // ReSharper disable once UnusedMember.Local
        private static IEnumerable<IEnumerable<T>> GetSubsets<T>(IEnumerable<T> items, int count)
        {
            var i = 0;
            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var item in items)
            {
                if (count == 1) yield return new[] { item };
                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var result in GetSubsets(items.Skip(i + 1), count - 1))
                    yield return new[] { item }.Concat(result);
                ++i;
            }
        }
    }

}
