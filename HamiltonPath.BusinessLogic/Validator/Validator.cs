using System;
using HamiltonPath.BusinessLogic.Common;

namespace HamiltonPath.BusinessLogic.Validator
{
    internal sealed class Validator
    {
        public static void ValidateGraphMatrix(int[,] ret)
        {
            if (ret == null || ret.Length < 2)
            {
                throw new ArgumentException(Consts.Exceptions.EmptyGraph);
            }
            var length = ret.GetLength(0);
            for (var i = 0; i < length; ++i)
            {
                if (ret[i, i] != 0)
                {
                    throw new ArgumentException(Consts.Exceptions.InvalidDiagonal);
                }
            }
            for (var i = 0; i < length; ++i)
            {
                for (var j = 0; j < i; ++j)
                {
                    if (ret[i, j] != ret[j, i])
                    {
                        throw new ArgumentException(Consts.Exceptions.NotCorrespodnigWeights);
                    }
                }
            }
        }
    }
}
