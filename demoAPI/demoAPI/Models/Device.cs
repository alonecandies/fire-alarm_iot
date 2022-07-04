using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using demoAPI;
using Microsoft.AspNetCore.Http;
using MySqlConnector;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeviceApi
{
    public class Device
    {
        public int id { get; set; }
        public string name { get; set; }
        public float max_temperature { get; set; }
        public bool is_off { get; set; }
        public bool is_alert { get; set; }
        public bool is_sendWater { get; set; }
        public int station_id { get; set; }
        public DateTime updated_at { get; set; }
        public string station_name { get; set; }

        public class shapeData
        {
            public float humidity { get; set; }
            public float temperature { get; set; }
            public DateTime created_at { get; set; }
        }

        public shapeData[] data { get; set; }
        public string? phones { get; set; }
        internal AppDb Db { get; set; }

        public Device()
        {
        }

        internal Device(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `devices` set `name` = @Device_name ,
            `max_temperature` = @Device_MaxTemperature , `station_id` = @Station_Id";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            id = (int) cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText =
                @"UPDATE `devices` SET `name` = @Device_name ,
            `max_temperature` = @Device_MaxTemperature, `is_off` = @Device_IsOff , `is_alert` = @Device_IsAlert,
             `is_sendWater` = @Device_IssendWater , `station_id` = @Station_Id , `updated_at`=@Updated_At       
                     Where `id`=@id";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `devices` WHERE `id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Device>> GetAllDevices( )
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"select D.*  , s.location_name as station_name
                                    from devices D
                                 join stations s on s.id = D.station_id ;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task<List<Device>> GetDeviceStatusById()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText =
                @"SELECT dv.*  , s.location_name as station_name ,
                                JSON_ARRAYAGG(JSON_OBJECT('temperature',r.temperature,'humidity',r.humidity, 'created_date',r.created_at )) as data,
                                IFNULL(GROUP_CONCAT(DISTINCT p.phone_value),'chưa đăng ký số điện thoại') as phones
                                from `devices` as dv
                                join `stations` as s on dv.station_id = s.id
                                left join `records` as r on dv.id = r.device_id
                                left join `device_has_phone` as dhp on dhp.device_id = dv.id
                                left join `phones` as p on dhp.phone_id = p.id
                                Where dv.id = @id";
            BindId(cmd);
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }


        public async Task<List<Device>> GetListDevicesByLocationId()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * from `devices`                      
                      Where `station_id` = @Station_Id;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Station_Id",
                DbType = DbType.Int32,
                Value = station_id,
            });
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        // public async Task<List<>>
        private async Task<List<Device>> ReadAllAsync(DbDataReader reader)
        {
            var Devices = new List<Device>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    try
                    {
                        var device = new Device(Db)
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            updated_at = reader.GetDateTime(2),
                            max_temperature = reader.GetFloat(3),
                            is_off = reader.GetBoolean(4),
                            is_alert = reader.GetBoolean(5),
                            is_sendWater = reader.GetBoolean(6),
                            station_id = reader.GetInt32(7),
                            station_name = reader.GetString(8),
                            data = JsonConvert.DeserializeAnonymousType((string) reader[9], data),
                            phones = reader.GetString(10)
                        };
                        Devices.Add(device);
                    }
                    catch (Exception)
                    {
                        var device = new Device(Db)
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            updated_at = reader.GetDateTime(2),
                            max_temperature = reader.GetFloat(3),
                            is_off = reader.GetBoolean(4),
                            is_alert = reader.GetBoolean(5),
                            is_sendWater = reader.GetBoolean(6),
                            station_id = reader.GetInt32(7),
                            station_name = reader.GetString(8),
                        };
                        Devices.Add(device);
                    }
                }
            }

            return Devices;
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Device_name",
                DbType = DbType.String,
                Value = name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Device_MaxTemperature",
                DbType = DbType.Decimal,
                Value = max_temperature,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Device_IsOff",
                DbType = DbType.Boolean,
                Value = is_off,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Device_IsAlert",
                DbType = DbType.Boolean,
                Value = is_alert,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Device_IssendWater",
                DbType = DbType.Boolean,
                Value = is_sendWater,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Station_Id",
                DbType = DbType.Boolean,
                Value = station_id,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Updated_At",
                DbType = DbType.Boolean,
                Value = updated_at,
            });
        }
    }
}