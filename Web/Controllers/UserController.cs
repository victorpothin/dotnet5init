using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Dto.Responses;
using Dto.Requests;

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

        [HttpPut]
        public ActionResult<Response<User>> Edit([FromBody] UserRequest request)
        {
            var response = _userService.Edit(request);
            if(response.Succeeded)
                return NoContent();
            return BadRequest(response.Errors);
        }
    }
}