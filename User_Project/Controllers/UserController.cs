using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {

        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok(new {message="Burası herkese açık endpoint"});
        }



        [Authorize(Roles ="admin")]
        [HttpGet("admin")]
        public IActionResult GetAdminData() 
        { 
            return Ok(new {message= "Burası sadece admin rolüne özel." });
        
        }

    }
}
