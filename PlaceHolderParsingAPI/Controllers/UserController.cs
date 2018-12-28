using PlaceHolderParsingAPI.Domain.Models;
using PlaceHolderParsingAPI.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceHolderParsingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [FormatFilter]//для выбора ответа добавляем параметр ?format=xml. по умолчанию json
        public async Task<ActionResult> User()
        {
            var result = await _userService.GetUsersAsync();
            if (result == null)
                return BadRequest("Нет данных!");
            return Ok(result);
        }

        [HttpGet("{id}")]
        [FormatFilter]//для выбора ответа добавляем параметр ?format=xml. по умолчанию json
        public async Task<ActionResult> User(int Id)
        {
            var result = await _userService.GetUserAsync(Id);
            if (result == null)
                return BadRequest("Нет данных!");
            return Ok(result);
        }
    }
}
