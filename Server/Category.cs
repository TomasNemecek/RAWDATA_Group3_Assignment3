using Newtonsoft.Json;

namespace Server
{
    public class Category
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}