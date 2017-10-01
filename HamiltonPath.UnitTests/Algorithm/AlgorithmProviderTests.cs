using System;
using System.Collections.Generic;
using FluentAssertions;
using HamiltonPath.BusinessLogic.Algorithm;
using HamiltonPath.BusinessLogic.Models;
using Xunit;

namespace HamiltonPath.UnitTests.Algorithm
{
    public sealed class AlgorithmProviderTests
    {
        private readonly IAlgorithmProvider _algorithmProvider;

        public AlgorithmProviderTests()
        {
            _algorithmProvider = new AlgorithmProvider();
        }

        [Theory]
        [MemberData(nameof(GetInvalidGraph))]
        public void Should_Throw_Exception(int[,] graph)
        {
            Action act = () => _algorithmProvider.Compute(graph);
            act.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [MemberData(nameof(GetGraph))]
        public void Should_Return_Path(int[,] graph, Path result)
        {
            _algorithmProvider.Compute(graph).Should().Be(result.ToString());
        }

        private static IEnumerable<object[]> GetGraph()
        {
            yield return new object[] { AlgotithmProviderTestData.Graph2, AlgotithmProviderTestData.Graph2Result };
            yield return new object[] { AlgotithmProviderTestData.Graph3, AlgotithmProviderTestData.Graph3Result };
            yield return new object[] { AlgotithmProviderTestData.Graph4, AlgotithmProviderTestData.Graph4Result };
            yield return new object[] { AlgotithmProviderTestData.Graph5, AlgotithmProviderTestData.Graph5Result };
            yield return new object[] { AlgotithmProviderTestData.Graph6, AlgotithmProviderTestData.Graph6Result };
            yield return new object[] { AlgotithmProviderTestData.Graph7, AlgotithmProviderTestData.Graph7Result };
            yield return new object[] { AlgotithmProviderTestData.Graph8, AlgotithmProviderTestData.Graph8Result };
            yield return new object[] { AlgotithmProviderTestData.Graph9, AlgotithmProviderTestData.Graph9Result };
            yield return new object[] { AlgotithmProviderTestData.Graph10, AlgotithmProviderTestData.Graph10Result };
            yield return new object[] { AlgotithmProviderTestData.Graph11, AlgotithmProviderTestData.Graph11Result };
            yield return new object[] { AlgotithmProviderTestData.Graph12, AlgotithmProviderTestData.Graph12Result };   // 17 s
            yield return new object[] { AlgotithmProviderTestData.Graph13, AlgotithmProviderTestData.Graph13Result };   // 01 min
            yield return new object[] { AlgotithmProviderTestData.Graph14, AlgotithmProviderTestData.Graph14Result };   // 06 min
            yield return new object[] { AlgotithmProviderTestData.Graph15, AlgotithmProviderTestData.Graph15Result };   // 28 min
        }

        private static IEnumerable<object[]> GetInvalidGraph()
        {
            yield return new object[] { AlgotithmProviderTestData.InvalidGraphDiagonal };
            yield return new object[] { AlgotithmProviderTestData.InvalidGraphNotSymetric };
        }
    }
}
