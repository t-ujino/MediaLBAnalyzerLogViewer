using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLBAnalyzerLogViewerLib
{
    public enum Endian
    {
        LittleEndian,
        BigEndian
    }

    public class AudioSampleUtils
    {
        static public double Convert16bitToDouble(byte[] data, Endian endian = Endian.LittleEndian)
        {
            var array = (endian == Endian.LittleEndian) ? data : data.Reverse().ToArray();
            var value = BitConverter.ToInt16(array);
            return value / Math.Abs((double)Int16.MinValue);
        }

        static public double Convert32bitToDouble(byte[] data, Endian endian = Endian.LittleEndian)
        {
            var array = (endian == Endian.LittleEndian) ? data : data.Reverse().ToArray();
            var value = BitConverter.ToInt32(array);
            return value / Math.Abs((double)Int32.MinValue);
        }

        static public double Convert24bitToDouble(byte[] data, Endian endian = Endian.LittleEndian)
        {
            var array = (endian == Endian.LittleEndian) ?
                new byte[] { 0x00 }.Concat(data) : new byte[] { 0x00 }.Concat(data.Reverse());
            return Convert32bitToDouble(array.ToArray());
        }
    }
}
