using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using demoAPI;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;

namespace UserAPi
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        internal AppDb Db { get; set; }
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public User()
        {
            
        }
        internal User(AppDb db)
        {
            Db = db;
        }
        public async Task<User> Login()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `users` WHERE `username` = @username AND `password` = @password";
            BindParams(cmd);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }
        public string GenerateToken(string username , int userid, int expireMinutes = 60)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username ),
                    new Claim(ClaimTypes.NameIdentifier, userid.ToString() ),
                    
                }
                ),
                    
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
        
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }    
        public string ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                return jwtToken?.Claims.First(claim => claim.Type == "unique_name").Value;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        private async Task<List<User>> ReadAllAsync(DbDataReader reader)
        {
            var locations = new List<User>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var user = new User(Db)
                    {
                        id = reader.GetInt32(0),
                        username = reader.GetString(1),
                        password = reader.GetString(2),
                    };
                    locations.Add(user);
                }
            }
            return locations;
        }
        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
                    
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = username,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = DbType.String,
                Value = password,
            });
        }
    }    
}