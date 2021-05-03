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
            var log = "01,MediaLB - RAW,18:01:19.123-456,Lock,1024,10,00000001,10,20,32,,00 01 02 03,,Lock,";
            var ret = LogEntity.ConvertFromCsv(log);
            var expect = new LogEntity()
            {
                Pos = 1,
                EventType = "MediaLB - RAW",
                Time = TimeSpan.Parse("18:01:19.1234560"),
                Lock = "Lock",
                Speed = 1024,
                PhysicalCh = 0x10,
                FrameCount = 1,
                Command = 0x10,
                Response = 0x20,
                ChannelAddress = 0x32,
                Dummy1 = string.Empty,
                Data = "00 01 02 03",
                Dummy2 = string.Empty,
                Protocol = "Lock",
                Dummy3 = string.Empty
            };
            Assert.AreEqual(expect, ret);
        }
    }
}