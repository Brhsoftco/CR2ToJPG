using structure;

namespace CR2ToJPG.Common
{
    public class ConverterOptions
    {
        public string[] Files { get; set; }

        public string OutputDirectory { get; set; }

        public WatermarkContext Watermark { get; set; }
    }
}