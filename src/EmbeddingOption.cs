using System.Text.Json.Serialization;

namespace PaLM.NET
{
    public class EmbeddingOption
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
