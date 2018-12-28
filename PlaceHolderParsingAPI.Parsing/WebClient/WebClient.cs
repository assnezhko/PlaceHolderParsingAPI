using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlaceHolderParsingAPI.Parsing.WebClient
{
    /// <summary>
    /// класс,
    /// работающий с веб-клиентом
    /// </summary>
    class WebClient: IWebClient
    {
        /// <summary>
        /// получить результат вызова эл. адреса
        /// </summary>
        /// <param name="url">эл. адрес</param>
        /// <returns></returns>
        public async Task<string> GetRequestResultAsync(string url)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                var result = await client.DownloadStringTaskAsync(new Uri(url));
                return result;
            }
        }
    }
}
