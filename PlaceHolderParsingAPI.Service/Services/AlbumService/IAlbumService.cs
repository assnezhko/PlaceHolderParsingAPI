using PlaceHolderParsingAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceHolderParsingAPI.Service.Services
{
    /// <summary>
    /// интерфейс для работы с альбомами
    /// </summary>
    public interface IAlbumService
    {
        /// <summary>
        /// получаем коллекцию всех альбомов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AlbumModel>> GetAlbumsAsync();

        /// <summary>
        /// получаем альбом по идентификатору
        /// </summary>
        /// <param name="Id">идентификатор альбома</param>
        /// <returns></returns>
        Task<AlbumModel> GetAlbumAsync(int Id);

        /// <summary>
        /// получаем альбомы пользователя
        /// </summary>
        /// <param name="userID">идентификатор пользователя</param>
        /// <returns></returns>
        Task<IEnumerable<AlbumModel>> GetAlbumsByUserIdAsync(int userID);
    }
}
