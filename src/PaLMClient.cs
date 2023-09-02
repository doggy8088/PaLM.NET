using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaLM.NET
{
    public class PaLMClient : IDisposable
    {
        HttpClient client = new HttpClient() {
            DefaultRequestHeaders = {
                { "User-Agent", "PaLM.NET" }
            }
        };

        string baseUri = "https://generativelanguage.googleapis.com/v1beta2/models";

        public string ApiKey { get; set; }

        public PaLMClient(string apikey)
        {
            this.ApiKey = apikey;
        }

        public async Task<MessageResult> GenerateMessageAsync(MessageOption msg)
        {
            var url = $"{baseUri}/chat-bison-001:generateMessage?key={ApiKey}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var payload = JsonSerializer.Serialize(msg);
            var content = new StringContent(payload);
            request.Content = content;

            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(result);
            }

            return JsonSerializer.Deserialize<MessageResult>(result);
        }

        public async Task<TextResult> GenerateTextAsync(TextOption options)
        {
            var url = $"{baseUri}/text-bison-001:generateText?key={ApiKey}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var payload = JsonSerializer.Serialize(options);
            var content = new StringContent(payload);

            request.Content = content;
            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(result);
            }

            return JsonSerializer.Deserialize<TextResult>(result);
        }

        public async Task<EmbeddingResult> GenerateEmbeddingsAsync(EmbeddingOption options)
        {
            var url = $"{baseUri}/embedding-gecko-001:embedText?key={ApiKey}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var payload = JsonSerializer.Serialize(options);
            var content = new StringContent(payload);

            request.Content = content;
            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(result);
            }

            return JsonSerializer.Deserialize<EmbeddingResult>(result);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
