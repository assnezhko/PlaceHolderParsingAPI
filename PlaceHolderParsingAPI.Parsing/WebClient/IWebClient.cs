using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceHolderParsingAPI.Parsing.WebClient
{
    /// <summary>
    /// интерфейс класса,
    /// работающий с веб-клиентом
    /// </summary>
    interface IWebClient
    {
        /// <summary>
        /// получить результат вызова эл. адреса
        /// </summary>
        /// <param name="url">эл. адрес</param>
        /// <returns></returns>
        Task<string> GetRequestResultAsync(string url);
    }
}
