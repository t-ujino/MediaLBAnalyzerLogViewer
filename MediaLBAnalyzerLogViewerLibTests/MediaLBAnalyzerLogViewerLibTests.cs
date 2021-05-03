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
    public class MediaLBAnalyzerLogViewerLibTests
    {
        [TestMethod()]
        public void LoadConfigTest()
        {
            var filename = "viewerconfig.yaml";
            var lib = new MediaLBAnalyzerLogViewerLib();
            lib.LoadConfig(filename);
            var expects = new List<ChConfig>();
            expects.Add(new ChConfig() { LogicalCh = 0x02, Depth = 24, Chs = 2, Fs = 48000 });
            expects.Add(new ChConfig() { LogicalCh = 0x20, Depth = 24, Chs = 2, Fs = 96000 });
            expects.Add(new ChConfig() { LogicalCh = 0x32, Depth = 16, Chs = 7, Fs = 48000 });
            for (int i = 0; i < lib.config.ChConfigs.Count(); i++)
            {
                Assert.AreEqual(expects[i], lib.config.ChConfigs[i]);
            }
        }
    }
}