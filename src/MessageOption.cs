using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaLM.NET
{
    public class Example
    {
        public Example() { }

        public Example(string input, string output)
        {
            Input.Content = input;
            Output.Content = output;
        }

        [JsonPropertyName("input")]
        public Input Input { get; set; } = new Input();

        [JsonPropertyName("output")]
        public Output Output { get; set; } = new Output();
    }

    public class Input
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class Message
    {
        public Message(string content)
        {
            Content = content;
        }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class Output
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class MessagePrompt
    {
        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("examples")]
        public List<Example> Examples { get; set; } = new List<Example>();

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; } = new List<Message>();
    }

    public class MessageOption
    {
        [JsonIgnore]
        public string Context
        {
            get { return Prompt.Context; }
            set { Prompt.Context = value; }
        }

        public void AddExample(string input, string output)
        {
            Prompt.Examples.Add(new Example(input, output));
        }
        public void AddMessage(string content)
        {
            Prompt.Messages.Add(new Message(content));

        }

        [JsonPropertyName("prompt")]
        public MessagePrompt Prompt { get; set; } = new MessagePrompt();

        [JsonPropertyName("temperature")]
        public double Temperature { get; set; } = 0.9;

        [JsonPropertyName("top_k")]
        public int TopK { get; set; } = 40;

        [JsonPropertyName("top_p")]
        public double TopP { get; set; } = 0.95;

        [JsonPropertyName("candidate_count")]
        public int CandidateCount { get; set; } = 1;
    }


}
