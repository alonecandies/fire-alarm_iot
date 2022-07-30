using System;
using UserAPi;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace demoAPI.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class AuthenController:ControllerBase
    {
        public AppDb Db { get; }

        public AuthenController(AppDb db)
        {
            Db = db;
        }
        [HttpGet]
        public async Task<IActionResult> CheckToken()
        {
            await Db.Connection.OpenAsync();
            return new OkObjectResult(new{check = true });
        }
        
    }
}