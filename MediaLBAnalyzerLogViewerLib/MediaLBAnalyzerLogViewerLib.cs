using System;

namespace MediaLBAnalyzerLogViewerLib
{
    public class MediaLBAnalyzerLogViewerLib
    {
        public ViewerConfig config { get; set; }

        public void LoadConfig(string filename)
        {
            var yaml = System.IO.File.ReadAllText(filename);
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder().Build();
            config = deserializer.Deserialize<ViewerConfig>(yaml);
        }
    }
}
