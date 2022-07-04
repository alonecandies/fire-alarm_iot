using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using demoAPI;
using MySqlConnector;

namespace DeviceApi
{
    public class Record
    {
           
        public int id { get; set; }
        public float temperature { get; set; }
        public float humidity { get; set; }
        public int device_id { get; set; }
        public DateTime created_at { get; set; }
        internal AppDb Db { get; set; }
        public Record()
        {
        }
        internal Record(AppDb db)
        {
            Db = db;
        }
        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `records` set `temperature` = @temperature,
            `humidity` = @humidity , `device_id` = @device_id ";
            BindParams(cmd);
            // if temperature is hight will trigger update device status
            await cmd.ExecuteNonQueryAsync();
            id = (int) cmd.LastInsertedId;
        }
        public async Task<List<Record>> GetDataByDeviceId(int deviceId)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"select * from `records` as rc
                        Where rc.device_id = @device_id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@device_id",
                DbType = DbType.Int32,
                Value = deviceId,
            });
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        public async Task<List<Record>> ReadAllAsync(DbDataReader reader)
        {
            var records = new List<Record>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var record = new Record(Db)
                    {
                        id = reader.GetInt32(0),
                        temperature = reader.GetFloat(1),
                        humidity = reader.GetFloat(2),
                        device_id = reader.GetInt32(3),
                        created_at = reader.GetDateTime(4),
                    };
                    records.Add(record);
                }
            }

            return records;
        }
        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
                {
                ParameterName = "@temperature",
                DbType = DbType.String,
                Value = temperature,
            }); 
            cmd.Parameters.Add(new MySqlParameter
                {
                ParameterName = "@humidity",
                DbType = DbType.String,
                Value = humidity,
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