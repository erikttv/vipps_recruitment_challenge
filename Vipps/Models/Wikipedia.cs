

using Newtonsoft.Json;

namespace Vipps.Models
{
    public class WikipediaResponse
    {
        public WikiParse parse { get; set; }
    }

    public class WikiParse
    {
        public string title { get; set; }
        public int pageid { get; set; }
        public int numTopic { get; set; }
        public TextFromWiki text { get; set; }
    }

    
    public class TextFromWiki
    {
        [JsonProperty("*")]
        public string actualText { get; set; }
    }
    
    
}