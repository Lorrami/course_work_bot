using System.Xml;
using System.Xml.Serialization;

namespace Bot
{
    public class Requirements
    {
        public string? Level { get; set; }
        public string? Notes { get; set; }
        
        public string? MinimumOS { get; set; }
        public string? MinimumProcessor { get; set; }
        public string? MinimumMemory { get; set; }
        public string? MinimumGraphics { get; set; }
        public string? MinimumStorage { get; set; }
    
        public string? RecommendedOS { get; set; }
        public string? RecommendedProcessor { get; set; }
        public string? RecommendedMemory { get; set; }
        public string? RecommendedGraphics { get; set; }
        public string? RecommendedStorage { get; set; }

    }
}
