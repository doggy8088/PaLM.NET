using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PaLM.NET
{
    public class Embedding
    {
        [JsonPropertyName("value")]
        public List<double> Values { get; set; }
    }

    public class EmbeddingResult
    {
        [JsonPropertyName("embedding")]
        public Embedding Embedding { get; set; }
    }
}
