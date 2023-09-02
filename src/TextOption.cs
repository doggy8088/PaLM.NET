using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PaLM.NET
{
    public class TextPrompt
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class TextOption
    {
        [JsonPropertyName("prompt")]
        public TextPrompt Prompt { get; set; } = new TextPrompt();

        [JsonPropertyName("temperature")]
        public double Temperature { get; set; } = 0.9;

        [JsonPropertyName("candidate_count")]
        public int CandidateCount { get; set; } = 1;

        [JsonPropertyName("top_k")]
        public int TopK { get; set; } = 40;

        [JsonPropertyName("top_p")]
        public double TopP { get; set; } = 0.95;

        [JsonPropertyName("max_output_tokens")]
        public int MaxOutputTokens { get; set; } = 1024;

        [JsonPropertyName("stop_sequences")]
        public List<string> StopSequences { get; set; } = new List<string>();

        [JsonPropertyName("safety_settings")]
        public List<SafetySetting> SafetySettings { get; set; } = new List<SafetySetting>();
    }

    public class SafetySetting
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("threshold")]
        public int Threshold { get; set; }
    }
}
