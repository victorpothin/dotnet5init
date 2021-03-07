using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; }
        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }
    }
}