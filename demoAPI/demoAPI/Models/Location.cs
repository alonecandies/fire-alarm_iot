using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using demoAPI;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace LocationApi
{
    public class Location
    {
        public int id { get; set; }
        public string location_name { get; set; }
        public DateTime updated_at { get; set; }

        internal AppDb Db { get; set; }
        public Location()
        {
        }
        internal Location(AppDb db)
        {
            Db = db;
        }
        
        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `stations` set `location_name` = @location_name";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            id = (int) cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `stations` SET `location_name` = @location_name WHERE `id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `stations` WHERE `id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<Location> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `location_name`, `updated_at` FROM `stations` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Location>> GetListstations()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `location_name`, `updated_at` FROM `stations` ORDER BY `id` DESC";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        
        // public async Task<List<>>
        private async Task<List<Location>> ReadAllAsync(DbDataReader reader)
        {
            var stations = new List<Location>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Location(Db)
                    {
                        id = reader.GetInt32(0),
                        location_name = reader.GetString(1),
                        updated_at = reader.GetDateTime(2),
                    };
                    stations.Add(post);
                }
            }
            return stations;
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
                ParameterName = "@location_name",
                DbType = DbType.String,
                Value = location_name,
            });
           
        }
    }
}