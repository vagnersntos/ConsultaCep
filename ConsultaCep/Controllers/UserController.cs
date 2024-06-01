using ConsultaCep.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaCep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> GetUsers()
        {
            return Ok();
        }
    }
}
