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
    public class RecordController : ControllerBase
    {
        public AppDb Db { get; }

        public RecordController(AppDb db)
        {
            Db = db;
        }
        [HttpPost]
        public async Task<IActionResult> SendData([FromBody]Record record)
        {
            await Db.Connection.OpenAsync();
            record.Db = Db;
            record.created_at = DateTime.Now;
            try
            {
                await record.InsertAsync();
                return new OkObjectResult(new {msg="OK" , data = record});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new { success= false , message = e.Message});
            }
            
        }
        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetByDeviceId(int deviceId)
        {
            await Db.Connection.OpenAsync();
            var record = new Record(Db);
            var result = await record.GetDataByDeviceId(deviceId);
            return new OkObjectResult(result);
        }
    }
}