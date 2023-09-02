using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaLM.NET
{
    public class ChatCandidate
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class ChatMessage
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class MessageResult
    {
        [JsonPropertyName("candidates")]
        public List<ChatCandidate> Candidates { get; set; }

        [JsonPropertyName("messages")]
        public List<ChatMessage> Messages { get; set; }
    }


}
