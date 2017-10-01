namespace HamiltonPath.BusinessLogic.Common
{
    /// <summary>
    /// Constants
    /// </summary>
    internal static class Consts
    {
        internal static class Serializer
        {
            internal const string GraphTitle = "Graph: ";

            internal const string GraphNotLoaded = "Not Loaded";

            internal const string HamiltonPathTitle = "Hamilton Path: ";
        }

        internal static class Exceptions
        {
            internal const string InvalidLine = "Cannot parse line with weights.";

            internal const string NotSquereMatrix = "Matrix should be squere.";

            internal const string InvalidWeight = "Weight is not a number.";

            internal const string EmptyGraph = "Graph Matrix is empty.";

            internal const string InvalidDiagonal = "Diagonal elements have to be equal to 0.";

            internal const string NotCorrespodnigWeights = "G(i, j) != G(j, i)";
        }

        internal static class SpecialCharacters
        {
            internal const string SpaceString = " ";

            internal const char SpaceChar = ' ';
        }
    }
}
