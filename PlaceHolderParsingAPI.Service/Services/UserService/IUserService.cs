using PlaceHolderParsingAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceHolderParsingAPI.Service.Services
{
    /// <summary>
    /// интерфейс сервиса для работы с пользователями
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// получаем коллекцию всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserModel>> GetUsersAsync();

        /// <summary>
        /// получаем пользователя по идентификатору
        /// </summary>
        /// <param name="Id">идентификатор пользователя</param>
        /// <returns></returns>
        Task<UserModel> GetUserAsync(int id);
    }
}
