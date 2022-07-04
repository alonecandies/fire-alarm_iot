using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using demoAPI;
using MySqlConnector;

namespace demoAPI
{
    public class Phone
    {
       
        public int Id { get; set; }
        public string phone_value { get; set; }
        public string whole_name { get; set; }
        public int device_id { get; set; }
        internal AppDb Db { get; set; }

        public Phone()
        {
        }

        internal Phone(AppDb db)
        {
            Db = db;
        }

        public async Task<List<Phone>> GetPhoneByDeviceID(int deviceId)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"select phones.* , dhp.device_id as device_id from phones join device_has_phone dhp on phones.id = dhp.phone_id
                        where dhp.device_id = @Device_Id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Device_Id",
                DbType = DbType.Int32,
                Value = deviceId,
            });
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `phones` set `phone_value` = @phone_value , `whole_name`= @whole_name";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int) cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `phones` SET `phone_value` = @phone_value ,`whole_name`= @whole_name  WHERE `id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `phones` WHERE `id` = @id ";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
            
        }
        private async Task<List<Phone>> ReadAllAsync(DbDataReader reader)
        {
            var phones = new List<Phone>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var phone = new Phone(Db)
                    {
                       
                        phone_value = reader.GetString(0),
                        whole_name = reader.GetString(1),
                        Id = reader.GetInt32(2),
                        device_id = reader.GetInt32(3)
                    };
                    phones.Add(phone);
                }
            }
            return phones;
        }
        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }
        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@phone_value",
                DbType = DbType.String,
                Value = phone_value,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@whole_name",
                DbType = DbType.String,
                Value = whole_name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@device_id",
                DbType = DbType.String,
                Value = device_id,
            });
        }
    }
}