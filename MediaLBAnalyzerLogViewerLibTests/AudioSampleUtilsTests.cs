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
    public class AudioSampleUtilsTests
    {
        [TestMethod()]
        public void Convert16bitToDoubleTest()
        {
            var value = new byte[] { 0x01, 0x02 };
            var result = AudioSampleUtils.Convert16bitToDouble(value, Endian.BigEndian);
            var expect = 0x0102 / Math.Abs((double)Int16.MinValue);
            Assert.AreEqual(true, Math.Abs(expect - result) < 1e-5);

            result = AudioSampleUtils.Convert16bitToDouble(value, Endian.LittleEndian);
            expect = 0x0201 / Math.Abs((double)Int16.MinValue);
            Assert.AreEqual(true, Math.Abs(expect - result) < 1e-5);
        }

        [TestMethod()]
        public void Convert32bitToDoubleTest()
        {
            var value = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            var result = AudioSampleUtils.Convert32bitToDouble(value, Endian.BigEndian);
            var expect = 0x01020304 / Math.Abs((double)Int32.MinValue);
            Assert.AreEqual(true, Math.Abs(expect - result) < 1e-5);

            result = AudioSampleUtils.Convert32bitToDouble(value, Endian.LittleEndian);
            expect = 0x04030201 / Math.Abs((double)Int32.MinValue);
            Assert.AreEqual(true, Math.Abs(expect - result) < 1e-5);
        }

        [TestMethod()]
        public void Convert24bitToDoubleTest()
        {
            var value = new byte[] { 0x01, 0x02, 0x03 };
            var result = AudioSampleUtils.Convert24bitToDouble(value, Endian.BigEndian);
            var expect = 0x01020300 / Math.Abs((double)Int32.MinValue);
            Assert.AreEqual(true, Math.Abs(expect - result) < 1e-5);

            result = AudioSampleUtils.Convert24bitToDouble(value, Endian.LittleEndian);
            expect = 0x03020100 / Math.Abs((double)Int32.MinValue);
            Assert.AreEqual(true, Math.Abs(expect - result) < 1e-5);
        }
    }
}