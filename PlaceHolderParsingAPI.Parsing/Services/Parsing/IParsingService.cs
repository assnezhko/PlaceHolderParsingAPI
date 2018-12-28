using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceHolderParsingAPI.Parsing.Services
{
    /// <summary>
    /// интерфейс сервиса, работающего с парсингом
    /// </summary>
    public interface IParsingService
    {
        /// <summary>
        /// получаем коллекцию типов
        /// </summary>
        /// <typeparam name="T">указатель места заполнения типом</typeparam>
        /// <param name="url">эл. адрес</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetCollectionAsync<T>(string url);
    }
}
