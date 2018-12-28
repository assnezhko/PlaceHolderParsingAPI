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
    /// сервис для работы с пользователями
    /// </summary>
    class UserService : IUserService
    {
        private readonly IParsingService _parsingService;
        private readonly IConfiguration _config;//настройки конфигурации

        public UserService(IParsingService parsingService, IConfiguration config)
        {
            _parsingService = parsingService;
            _config = config;
        }

        /// <summary>
        /// получаем коллекцию всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            string  usersUrl = _config.GetSection("API:UserAPI:key").Value;
            IEnumerable<UserModel> users;
            try
            {
                Func<Task<IEnumerable<UserModel>>> userFun = async () => await _parsingService.GetCollectionAsync<UserModel>(usersUrl);

                users = await CacheService.GetExistingOrAdd<UserModel>("users", userFun, TimeSpan.FromSeconds(60));
            }

            catch (Exception)
            {
                return null;
            }

            return users;
        }

        /// <summary>
        /// получаем пользователя по идентификатору
        /// </summary>
        /// <param name="Id">идентификатор пользователя</param>
        /// <returns></returns>
        public async Task<UserModel> GetUserAsync(int id)
        {
            var users = await GetUsersAsync();

            if (users == null)
                return null;

            var item = users.Where(i => i.Id == id).FirstOrDefault();
            return item;
        }
    }
}
