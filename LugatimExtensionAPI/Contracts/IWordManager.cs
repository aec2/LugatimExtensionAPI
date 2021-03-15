using LugatimExtensionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LugatimExtensionAPI.Contracts
{
    public interface IWordManager
    {
        public Task<string> GetWordHttpByUrlAsync(string word);

        public WordResult ParseWordResponseToModel(string wordResponse, string word);
    }
}
