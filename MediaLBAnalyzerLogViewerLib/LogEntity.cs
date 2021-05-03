using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLBAnalyzerLogViewerLib
{
    public class LogEntity
    {
        public int Pos { get; set; }
        public string EventType { get; set; }
        public TimeSpan Time { get; set; }
        public string Lock { get; set; }
        public int Speed { get; set; }
        public int PhysicalCh { get; set; }
        public double FrameCount { get; set; }
        public int Command { get; set; }
        public int Response { get; set; }
        public int ChannelAddress { get; set; }
        public string Dummy1 { get; set; }
        public string Data { get; set; }
        public string Dummy2 { get; set; }
        public string Protocol { get; set; }
        public string Dummy3 { get; set; }
        /// <summary>
        /// LogのCSV 1行分をEntityに変換
        /// </summary>
        /// <param name="record">Log record</param>
        /// <returns>CSV -> Entity</returns>
        public static LogEntity ConvertFromCsv(string record)
        {
            var cols = record.Split(",");
            if (cols.Length != 15) throw new ArgumentException("Wrong record. Mismatch columns piecies.");
            try
            {
                var tmp = cols[2].Split("-"); // hh:mm:ss.mmm-uuu to hh:mm:ss.mmm, uuu
                var time = TimeSpan.Parse(tmp[0]) + TimeSpan.FromMilliseconds(int.Parse(tmp[1]) / 1000.0);

                return new LogEntity()
                {
                    Pos = int.Parse(cols[0]),
                    EventType = cols[1],
                    Time = time,
                    Lock = cols[3],
                    Speed = int.Parse(cols[4]),
                    PhysicalCh = int.Parse(cols[5], System.Globalization.NumberStyles.HexNumber),
                    FrameCount = double.Parse(cols[6]),
                    Command = int.Parse(cols[7], System.Globalization.NumberStyles.HexNumber),
                    Response = int.Parse(cols[8], System.Globalization.NumberStyles.HexNumber),
                    ChannelAddress = int.Parse(cols[9], System.Globalization.NumberStyles.HexNumber),
                    Dummy1 = cols[10],
                    Data = cols[11],
                    Dummy2 = cols[12],
                    Protocol = cols[13],
                    Dummy3 = cols[14]
                };
            }
            catch (Exception)
            {

                throw new ArgumentException("Wrong record. Mismatch columns type.");
            }
        }
    }
}
