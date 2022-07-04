using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace demoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController:ControllerBase
    {
        public AppDb Db { get; }

        public PhoneController(AppDb db)
        {
            Db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Phone phone )
        {
            await Db.Connection.OpenAsync();
            MySqlTransaction transaction = Db.Connection.BeginTransaction();
            using var cmd = Db.Connection.CreateCommand();
            try
            {
                phone.Db = Db;
                int id_insertd ;
                id_insertd = phone.InsertAsync().Id;
                cmd.CommandText=@"INSERT INTO `device_has_phone` set `phone_id` = @phone_id , `device_id`= @device_id";
                cmd.Parameters.AddWithValue("phone_id", id_insertd);
                cmd.Parameters.AddWithValue("device_id", phone.device_id);
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return new OkObjectResult(new {msg="ok",data=phone});
            }
            catch (Exception e)
            {   
                await transaction.RollbackAsync();
                return BadRequest(new { success= false , msg = "lỗi server",detail = e.Message});
            }
        }
        
        // edit
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id , [FromBody]Phone phone  )
        {
            await Db.Connection.OpenAsync();
            phone.Db = Db;
            phone.Id = id;
            try
            {
                await phone.UpdateAsync();
                return new OkObjectResult(phone);
            }
            catch (Exception e)
            {
                return BadRequest(new { success= false , msg = "lỗi server",detail = e.Message});
            }
        }

        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetByDeviceId(int deviceId)
        {
            await Db.Connection.OpenAsync();
            var query = new Phone(Db);
            var result = await query.GetPhoneByDeviceID(deviceId);
            if (result is null) return BadRequest(new { success= false , msg = "Tài nguyên không tồn tại"});;
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Db.Connection.OpenAsync();
            MySqlTransaction transaction = Db.Connection.BeginTransaction();
            using var cmd = Db.Connection.CreateCommand();
            try
            {   
                var phone = new Phone(Db);
                phone.Id = id;
                await phone.DeleteAsync();
                cmd.CommandText=@"DELETE From `device_has_phone` Where `phone_id`=@id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return new OkObjectResult(new {msg="delete success"});
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return BadRequest(new { success= false , msg = "lỗi server",detail = e.Message});
            }
        }
    }
}