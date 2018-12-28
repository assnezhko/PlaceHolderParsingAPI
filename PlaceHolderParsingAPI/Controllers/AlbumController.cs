using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaceHolderParsingAPI.Parsing.Services;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using PlaceHolderParsingAPI.Domain.Models;
using System.Net.Http;
using System.Xml.Linq;
using PlaceHolderParsingAPI.Service.Services;

namespace PlaceHolderParsingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AlbumController : ControllerBase
    {
        IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        [FormatFilter]//для выбора ответа добавляем параметр ?format=xml. по умолчанию json
        public async Task <ActionResult> Album()
        {
            var result = await _albumService.GetAlbumsAsync();
            if (result == null)
                return BadRequest("Нет данных!");
            return Ok(result);

        }

        [HttpGet("{id}")]
        [FormatFilter]//для выбора ответа добавляем параметр ?format=xml. по умолчанию json
        public async Task<ActionResult> Album(int Id)
        {
            var result = await _albumService.GetAlbumAsync(Id);
            if (result == null)
                return BadRequest("Нет данных!");
            return Ok(result);
        }

        [HttpGet("{userId}")]
        [FormatFilter]//для выбора ответа добавляем параметр ?format=xml. по умолчанию json
        public async Task<ActionResult> AlbumByUserID(int userId)
        {
            var result = await _albumService.GetAlbumsByUserIdAsync(userId);
            if (result == null)
                return BadRequest("Нет данных!");
            return Ok(result);
        }
    }
}
