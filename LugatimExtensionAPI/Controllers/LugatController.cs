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


        [HttpGet("{word}")]
        public async Task<string> Get(string word)
         {
            var httpClient = new HttpClient();
            HttpResponseMessage result = await httpClient.GetAsync(string.Concat(LugatConts.LugatBaseUrl, word));
            var response = await result.Content.ReadAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(response);

            var htmlBody = doc.DocumentNode.SelectNodes("/html/");


            return htmlBody.FirstOrDefault() != null ? htmlBody.FirstOrDefault().InnerText.Trim() : "CIKMAZ SOKAK";
        }
    }
}
