using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceHolderParsingAPI.Parsing.Services
{
    /// <summary>
    /// сервис, работающий с парсингом
    /// </summary>
    class ParsingService : IParsingService
    {
        private readonly WebClient.IWebClient _webClient;

        public ParsingService(WebClient.IWebClient webClient)
        {
            _webClient = webClient;
        }

        /// <summary>
        /// получаем коллекцию типов
        /// </summary>
        /// <typeparam name="T">указатель места заполнения типом</typeparam>
        /// <param name="url">эл. адрес</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetCollectionAsync<T>(string url)
        {
            var resultClient = await _webClient.GetRequestResultAsync(url);
            return await Task.Run(() =>
            {
                var albums = JsonConvert.DeserializeObject<IEnumerable<T>>(resultClient);
                return albums;
            }
            );
        }
    }
}
