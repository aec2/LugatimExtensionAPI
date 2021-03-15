using HtmlAgilityPack;
using LugatimExtensionAPI.Constants;
using LugatimExtensionAPI.Contracts;
using LugatimExtensionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LugatimExtensionAPI
{
    public class WordManager : IWordManager
    {

        public async Task<string> GetWordHttpByUrlAsync(string word)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage result = await httpClient.GetAsync(string.Concat(LugatConts.LugatBaseUrl, word));
            var response = await result.Content.ReadAsStringAsync();

            return response;
        }

        public WordResult ParseWordResponseToModel(string wordResponse, string word)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(wordResponse);

            var script = doc.DocumentNode.Descendants()
                             .Where(n => n.Name == "script").Select(item => item.InnerText).Where(x => x != null && x.Length > 0).ToList()[1];

            var index = script.IndexOf("resultBody");
            if (index > -1)
            {
                script = script.Substring(index, script.Length - index - 2);
                var index2 = script.IndexOf("}");
                if (index2 > -1)
                {
                    script = script.Substring(0, index2).Replace("resultBody\": ", "");
                    return new WordResult { Name = word, Meaning = script };
                }
            }
            return new WordResult { Name = word, Meaning = " "};


        }
    }
}
