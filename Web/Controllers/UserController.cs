using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Dto.Responses;

namespace Web.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase
    {
        public IUserService _userService { get; }
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult<Response<User>> Get([FromQuery] int? id)
        {
            if(id == null)
                return BadRequest("Id is null");
            return Ok(this._userService.GetById(id.Value));
        }
    }
}