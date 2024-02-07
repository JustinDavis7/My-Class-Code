using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorts
{
    public static class Analyzer
    {
        public static Analysis Analyze(int[] sizes, long[] compares)
        {
            var analyze = new Analysis();
            var ratios = new List<List<double>>();

            analyze.Error = 0D;
            for(var i = 0; i < 7; ++i)
            {
                ratios.Add(new List<double>());
            }

            for(int i = 0; i < sizes.Length; ++i)
            {
                ratios[0].Add(compares[i] / 1);
                ratios[1].Add(compares[i] / Math.Log(sizes.Length));
                ratios[2].Add(compares[i] / sizes.Length);
                ratios[3].Add(compares[i] / (sizes[i]*Math.Log(sizes.Length)));
                ratios[4].Add(compares[i] / Math.Pow(sizes.Length, 2));
                ratios[5].Add(compares[i] / Math.Pow(sizes.Length, 3));
                ratios[6].Add(compares[i] / Math.Pow(2, sizes.Length));
            }

            var meansList = new List<double>();
            var relativeErrorList = new List<double>();
            var relativeError = 0D;
            var mean = 0D;

            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < sizes.Length; ++j)
                {
                    mean += ratios[i][j];
                }
                meansList.Add(mean / sizes.Length);
            }

            for (int i = 0; i < 7; ++i)
            {
                relativeError = 0;
                for (int j = 0; j < sizes.Length; ++j)
                { 
                    relativeError += (Math.Abs(ratios[i][j] - meansList[i]) / meansList[i]);
                }
                relativeErrorList.Add(relativeError / sizes.Length);
            }

            double lowestError = 10;
            foreach(double error in relativeErrorList)
            {
                if (error < lowestError && error != 0)
                    lowestError = error;
            }

            int oValue = 0;

            for(int i = 0; i < 7; ++i)
            {
                if(lowestError == relativeErrorList[i])
                {
                    oValue = i;
                    break;
                }
            }

            if (oValue == 0)
                analyze.BigOValue = BigOValue.Linear;
            else if (oValue == 1)
                analyze.BigOValue = BigOValue.Cubic;
            else if (oValue == 2)
                analyze.BigOValue = BigOValue.Logarithmic;
            else if (oValue == 3)
                analyze.BigOValue = BigOValue.Constant;
            else if (oValue == 4)
                analyze.BigOValue = BigOValue.LogLinear;
            else if (oValue == 5)
                analyze.BigOValue = BigOValue.Exponential;
            else if (oValue == 6)
                analyze.BigOValue = BigOValue.Quadratic;

            analyze.Ratios = ratios[oValue].ToArray();

            return analyze;
        }
    }
}
