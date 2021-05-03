using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaLBAnalyzerLogViewerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLBAnalyzerLogViewerLib.Tests
{
    [TestClass()]
    public class LogEntityTests
    {
        [TestMethod()]
        public void ConvertFromCsvTest()
        {
            var record = "01,MediaLB - RAW,18:01:19.123-456,Lock,1024,10,00000001,10,20,32,,00 01 02 03,,Lock,";
            var ret = LogEntity.ConvertFromCsv(record);
            Assert.Fail();
        }
    }
}