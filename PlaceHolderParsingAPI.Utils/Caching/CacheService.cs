using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PlaceHolderParsingAPI.Utils.Caching
{
    /// <summary>
    /// Класс для работы с кэшем
    /// </summary>
    public static class CacheService
    {
        /// <summary>
        /// Добавляет объект в кэш
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="key">Ключ</param>
        /// <param name="item">Объект</param>
        /// <param name="policy">Настройки устаревания объекта в кэше</param>
        public static void Set<T>(string key, T item, CacheItemPolicy policy)
        {
            MemoryCache.Default.Set(key, item, policy);
        }

        /// <summary>
        /// Получает объект из кэша
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="key">Ключ</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return (T)MemoryCache.Default.Get(key);
        }

        /// <summary>
        /// Получает коллекцию объектов из кэша, если объект не существуют, добавляет новый
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="key">Ключ</param>
        /// <param name="getter">Функция для получения объекта</param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public async static Task<IEnumerable<T>> GetExistingOrAdd<T>(string key, Func<Task<IEnumerable<T>>> getter, CacheItemPolicy policy)
        {
            if (MemoryCache.Default[key] == null)
            {
                var result = await getter();
                MemoryCache.Default.Add(key, result, policy);
            }

            return (IEnumerable<T>)MemoryCache.Default[key];
        }

        /// <summary>
        /// Получает коллекцию объектов из кэша, если объект не существуют, добавляет новый
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="key">Ключ</param>
        /// <param name="getter">Функция для получения объекта</param>
        /// <param name="slidingExpiration">Промежуток времени через который объект в кэше устаревает и удаляется</param>
        /// <returns></returns>
        public async static Task<IEnumerable<T>> GetExistingOrAdd<T>(string key, Func<Task<IEnumerable<T>>> getter, TimeSpan slidingExpiration)
        {
            var policy = new CacheItemPolicy()
            {
                SlidingExpiration = slidingExpiration
            };

            return await GetExistingOrAdd(key, getter, policy);
        }
    }
}
