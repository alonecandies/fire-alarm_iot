using System;
using System.Threading.Tasks;
using DeviceApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace demoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class DeviceController : ControllerBase
    {
        public AppDb Db { get; }

        public DeviceController(AppDb db)
        {
            Db = db;
        }
        // GET all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Db.Connection.OpenAsync();
            var query = new Device(Db);
            var result = await query.GetAllDevices();
            return new OkObjectResult(result);
        }
        // GET all by location id
        [HttpGet( "Location/{station_id}")]
        public async Task<IActionResult> GetAllByLocationId(int station_id)
        {
            await Db.Connection.OpenAsync();
            var device = new Device(Db);
            device.station_id = station_id;
            var result = await device.GetListDevicesByLocationId();
            return new OkObjectResult(result);
        }

        // GET Device Status by id
        [HttpGet( "Status/{device_id}")]
        public async Task<IActionResult> GetStatusById(int device_id)
        {
            await Db.Connection.OpenAsync();
            var device = new Device(Db);
            device.id = device_id;
            var result = await device.GetDeviceStatusById();
            return new OkObjectResult(result);
        }

        // Create 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Device device)
        {
            await Db.Connection.OpenAsync();
            device.Db = Db;
            device.updated_at = DateTime.Now;
            try
            {
                await device.InsertAsync();
                return new OkObjectResult(device);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new { success= false ,msg = "Lỗi server" ,detail = e.Message});
            }
        }
        //Edit
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id , [FromBody]Device device )
        {
            await Db.Connection.OpenAsync();
            device.Db = Db;
            device.id = id;
            device.updated_at = DateTime.Now;
            try
            {
                await device.UpdateAsync();
                return new OkObjectResult(device);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new { success= false , msg = "lỗi server",detail = e.Message});
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Db.Connection.OpenAsync();
            try
            {   var device = new Device(Db);
                device.id = id;
                await device.DeleteAsync();
                return Ok(new {msg= "Delete Success"});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new { success= false ,msg = "lỗi server" , detail = e.Message});
            }
        }
        
    }
}