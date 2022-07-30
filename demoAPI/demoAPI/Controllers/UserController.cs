using UserAPi;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace demoAPI.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class UserController:ControllerBase
    {
        public AppDb Db { get; }

        public UserController(AppDb db)
        {
            Db = db;
        }
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody]User user)
        {
            await Db.Connection.OpenAsync();
            user.Db = Db;
            var result = await user.Login();
            if (result ==  null)
            {
                return NotFound(new {msg = "Sai Thông tin tài khoản hoặc mật khẩu"});
            }
            string Token = user.GenerateToken(result.username, result.id, 60);
            return new OkObjectResult(new{data = result , token=Token});
            
        }

    }
}