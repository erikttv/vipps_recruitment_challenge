using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vipps.Models;

namespace Vipps.Services
{
    public class SearchWord
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<WikipediaResponse> GetArticleFromWikipedia(string topic)
        {
            try
            {
                string url = "https://en.wikipedia.org/w/api.php?action=parse&section=0&prop=text&format=json&page=" + topic;
                HttpResponseMessage responseMessage = await Client.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();
                string allLines = await responseMessage.Content.ReadAsStringAsync();
                WikipediaResponse wikipediaResponse = JsonConvert.DeserializeObject<WikipediaResponse>(allLines);
                if (wikipediaResponse == null)
                {
                    return null;
                }
                wikipediaResponse.parse.numTopic = countTopic(topic, wikipediaResponse.parse.text.actualText);
                return wikipediaResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        private int countTopic(string topic, string text)
        {
            int numTopic = 0;
            int topicLength = topic.Length;
            for (int i = 0; i < text.Length; i++)
            {
                if (i + topicLength >= text.Length)
                {
                    return numTopic;
                }
                if (String.Equals(topic.ToLower(), text.Substring(i, topicLength).ToLower()))
                {
                    numTopic++;
                }
            }
            return numTopic;
        }
    }
}