using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WebApi.Models;

namespace UnitTest
{
    [TestClass]
    public class PercentileTest
    {

        [TestMethod]
        public void TestWebAPI_GetData()
        {
            var data = Percentile.GetData();
            Assert.IsNotNull(data, "WebAPI failed to return dataset");
        }

        [TestMethod]
        public void TestProgram_GetValues()
        {
            var data = RiskFirst.Percentile.Program.GetValues();
            var firstDouble = data.FirstOrDefault<double>();
            Assert.IsNotNull(firstDouble, "Program.GetValues failed to return dataset for percentile");
        }

        [TestMethod]
        public void TestProgram_PercentileInc()
        {
            double[] data = { 10.123, 30.333, 25.444, 60.666, 50.555 };
            double myPercentile = RiskFirst.Percentile.Program.PercentileInc(data, 0.5);

            Assert.AreEqual(30.333, myPercentile);
        }
    }
}
