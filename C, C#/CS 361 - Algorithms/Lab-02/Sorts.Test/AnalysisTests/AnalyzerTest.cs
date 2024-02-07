using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Test.AnalysisTests
{
    [TestClass]
    public class AnalyzerTest
    {
        private readonly IList<IList<int>> _sizesTestData = new List<IList<int>>()
        {
            new List<int>(){10, 20, 30, 40, 50, 60, 70, 80},
            new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9},
            new List<int>(){128, 256, 512, 1024, 2048, 4096, 8192},
            new List<int>(){100, 200, 300, 400, 500, 600},
            new List<int>(){2, 4, 8, 16},
            new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9},
            new List<int>(){10, 20, 30, 40, 50, 60, 70, 80}
        };

        private readonly IList<IList<long>> _comparesTestData = new List<IList<long>>()
        {
            new List<long>(){100, 200, 300, 400, 500, 600, 700, 800},
            new List<long>(){1, 8, 27, 64, 125, 216, 343, 512, 719},
            new List<long>(){7, 8, 9, 10, 11, 12, 13},
            new List<long>(){100, 100, 100, 100, 100, 100},
            new List<long>(){2, 8, 24, 64},
            new List<long>(){2, 4, 8, 16, 32, 64, 128, 256, 512},
            new List<long>(){110, 420, 930, 1640, 2550, 3660, 4970, 6480}
        };

        private readonly BigOValue[] _expectedBigOValues =
        {
            BigOValue.Linear,
            BigOValue.Cubic,
            BigOValue.Logarithmic,
            BigOValue.Constant,
            BigOValue.LogLinear,
            BigOValue.Exponential,
            BigOValue.Quadratic
        };

        private enum TestCase
        {
            Linear,
            Cubic,
            Logarithmic,
            Constant,
            LogLinear,
            Exponential,
            Quadratic
        }

        [TestMethod]
        public void AnalyzerLinearTestCase()
        {
            var analysis = Analyzer.Analyze(_sizesTestData[(int)TestCase.Linear].ToArray(), _comparesTestData[(int)TestCase.Linear].ToArray());
            Assert.AreEqual(_expectedBigOValues[(int)TestCase.Linear], analysis.BigOValue);
        }

        [TestMethod]
        public void AnalyzerCubicTestCase()
        {
            var analysis = Analyzer.Analyze(_sizesTestData[(int)TestCase.Cubic].ToArray(), _comparesTestData[(int)TestCase.Cubic].ToArray());
            Assert.AreEqual(_expectedBigOValues[(int)TestCase.Cubic], analysis.BigOValue);
        }

        [TestMethod]
        public void AnalyzerLogarithmicTestCase()
        {
            var analysis = Analyzer.Analyze(_sizesTestData[(int)TestCase.Logarithmic].ToArray(), _comparesTestData[(int)TestCase.Logarithmic].ToArray());
            Assert.AreEqual(_expectedBigOValues[(int)TestCase.Logarithmic], analysis.BigOValue);
        }

        [TestMethod]
        public void AnalyzerConstantTestCase()
        {
            var analysis = Analyzer.Analyze(_sizesTestData[(int)TestCase.Constant].ToArray(), _comparesTestData[(int)TestCase.Constant].ToArray());
            Assert.AreEqual(_expectedBigOValues[(int)TestCase.Constant], analysis.BigOValue);
        }

        [TestMethod]
        public void AnalyzerLogLinearTestCase()
        {
            var analysis = Analyzer.Analyze(_sizesTestData[(int)TestCase.LogLinear].ToArray(), _comparesTestData[(int)TestCase.LogLinear].ToArray());
            Assert.AreEqual(_expectedBigOValues[(int)TestCase.LogLinear], analysis.BigOValue);
        }

        [TestMethod]
        public void AnalyzerExponentialTestCase()
        {
            var analysis = Analyzer.Analyze(_sizesTestData[(int)TestCase.Exponential].ToArray(), _comparesTestData[(int)TestCase.Exponential].ToArray());
            Assert.AreEqual(_expectedBigOValues[(int)TestCase.Exponential], analysis.BigOValue);
        }

        [TestMethod]
        public void AnalyzerQuadraticTestCase()
        {
            var analysis = Analyzer.Analyze(_sizesTestData[(int)TestCase.Quadratic].ToArray(), _comparesTestData[(int)TestCase.Quadratic].ToArray());
            Assert.AreEqual(_expectedBigOValues[(int)TestCase.Quadratic], analysis.BigOValue);
        }

    }
}