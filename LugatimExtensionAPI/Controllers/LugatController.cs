using LugatimExtensionAPI.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using LugatimExtensionAPI.Contracts;

namespace LugatimExtensionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LugatController : ControllerBase
    {
        private readonly IWordManager wordManager;

        public LugatController(IWordManager wordManager)
        {
            this.wordManager = wordManager;
        }

        // TODO: search resultta kökten türeyen kelimeler gelince nasıl aksiyon alınacağına bakılacak.
        [HttpGet("{word}")]
        public async Task<IActionResult> GetAsync(string word)
        
        {
           var result = await wordManager.GetWordHttpByUrlAsync(word);
           var wordModel = wordManager.ParseWordResponseToModel(result, word);

            return Ok(wordModel);
        }
    }
}
