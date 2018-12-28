using PlaceHolderParsingAPI.Domain.Models;
using PlaceHolderParsingAPI.Parsing.Services;
using PlaceHolderParsingAPI.Utils.Caching;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceHolderParsingAPI.Service.Services
{
    /// <summary>
    /// сервис для работы с альбомами
    /// </summary>
    class AlbumService : IAlbumService
    {
        private readonly IParsingService _parsingService;
        private readonly IConfiguration _config;//настройки конфигурации

        public AlbumService(IParsingService parsingService, IConfiguration config)
        {
            _parsingService = parsingService;
            _config = config;
        }

        /// <summary>
        /// получаем коллекцию всех альбомов
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AlbumModel>> GetAlbumsAsync()
        {
            string albumsUrl = _config.GetSection("API:AlbumAPI:key").Value;
            IEnumerable<AlbumModel> albums;
            try
            {
                Func<Task<IEnumerable<AlbumModel>>> albumFun = async () => await _parsingService.GetCollectionAsync<AlbumModel>(albumsUrl);

                albums = await CacheService.GetExistingOrAdd<AlbumModel>("albums", albumFun, TimeSpan.FromSeconds(60));
            }

            catch(Exception)
            {
                return null;
            }
            return albums;
        }

        /// <summary>
        /// получаем альбом по идентификатору
        /// </summary>
        /// <param name="Id">идентификатор альбома</param>
        /// <returns></returns>
        public async Task<AlbumModel> GetAlbumAsync(int id)
        {
            var albums = await GetAlbumsAsync();

            if (albums == null)
                return null;

            var item = albums.Where(i => i.Id == id).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// получаем альбомы пользователя
        /// </summary>
        /// <param name="userID">идентификатор пользователя</param>
        /// <returns></returns>
        public async Task<IEnumerable<AlbumModel>> GetAlbumsByUserIdAsync(int userID)
        {
            var albums = await GetAlbumsAsync();

            if (albums == null)
                return null;

            var items = albums.Where(i => i.UserId == userID);
            return items;
        }
    }
}
