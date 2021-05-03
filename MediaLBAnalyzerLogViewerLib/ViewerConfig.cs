using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLBAnalyzerLogViewerLib
{
    public class ViewerConfig
    {
        public List<ChConfig> ChConfigs { get; set; }
    }

    public record ChConfig
    {
        public int LogicalCh { get; set; }
        public int Depth { get; set; }
        public int Chs { get; set; }
        public int Fs { get; set; }
    }
}
