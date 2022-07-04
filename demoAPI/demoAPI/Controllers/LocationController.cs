using System;
using System.Threading.Tasks;
using LocationApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        public AppDb Db { get; }

        public LocationController(AppDb db)
        {
            Db = db;
        }

        // GET all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Db.Connection.OpenAsync();
            var query = new Location(Db);
            var result = await query.GetListstations();
            return new OkObjectResult(result);
        }

        // Get detail
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailLocation(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new Location(Db);
            var result = await query.FindOneAsync(id);
            if (result is null) return Ok(new {  msg = "chưa đăng ký số điện thoại"});;
            return new OkObjectResult(result);
        }
        // Create 
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Location body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            body.updated_at = DateTime.Now;
            try
            {
                await body.InsertAsync();
                return new OkObjectResult(body);
            }
            catch (Exception e)
            {
                return BadRequest(new { success= false , msg = "lỗi server",detail = e.Message});
            }
        }
        
        // edit
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id ,[FromBody]Location body )
        {   
            await Db.Connection.OpenAsync();
            body.Db = Db;
            body.id = id;
            body.updated_at = DateTime.Now;
            try
            {
                await body.UpdateAsync();
                return new OkObjectResult(body);
            }
            catch (Exception e)
            {
                return BadRequest(new { success= false , msg = "lỗi server",detail = e.Message});
            }
        }
        
    }
}