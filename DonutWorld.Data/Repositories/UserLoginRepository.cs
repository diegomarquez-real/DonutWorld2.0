using Dapper;
using DonutWorld.Api.Models;
using DonutWorld.Data.Abstractions.Repositories;
using DonutWorld.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutWorld.Data.Repositories
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly IConfiguration _configuration;

        public UserLoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> LoginUser(UserLoginModel userLoginModel)
        {
            var sql = @"SELECT u.* 
                        FROM [User] AS u
                        WHERE u.Username = @Username AND u.Password = @Password";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var result = await connection.QueryAsync<User>(sql, new { Username = userLoginModel.Username, Password = userLoginModel.Password });

                var user = result.FirstOrDefault();

                return user;
            }
        }
    }
}
