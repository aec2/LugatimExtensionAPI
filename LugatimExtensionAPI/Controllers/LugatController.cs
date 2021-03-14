using LugatimExtensionAPI.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace LugatimExtensionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LugatController : ControllerBase
    {

        // TODO: search resultta kökten türeyen kelimeler gelince nasıl aksiyon alınacağına bakılacak.
        [HttpGet("{word}")]
        public async Task<string> Get(string word)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage result = await httpClient.GetAsync(string.Concat(LugatConts.LugatBaseUrl, word));
            var response = await result.Content.ReadAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(response);

            var htmlBody = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div[1]/div[2]/div/div[1]/div/p");

            return htmlBody != null ? htmlBody.InnerText.Trim() : "CIKMAZ SOKAK";
        }
    }
}
