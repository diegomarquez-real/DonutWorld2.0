using Dapper;
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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Guid> CreateAsync(User entity)
        {
            string sql = @"INSERT INTO [User] ([UserId], [Username], [Password], [EmailAddress], [PhoneNumber], [CreatedOn])
                           VALUES (@UserId, @Username, @Password, @EmailAddress, @PhoneNumber, @CreatedOn)";

            using (var connection  = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                await connection.ExecuteScalarAsync(sql, entity);

                return entity.UserId;
            }
        }

        public async Task<Guid> DeleteAsync(Guid userId)
        {
            string sql = @"DELETE FROM [User]
                           WHERE UserId = @UserId";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                await connection.ExecuteScalarAsync(sql, new { UserId = userId });

                return userId;
            }
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            var sql = @"SELECT u.*
                        FROM [User] AS u
                        WHERE u.UserId = @UserId";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var result = await connection.QuerySingleAsync<User>(sql, new { UserId = userId });

                return result;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var sql = @"SELECT u.*
                        FROM [User] AS u";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var users = await connection.QueryAsync<User>(sql);

                return users;
            }
        }

        public async Task<Guid> UpdateAsync(User entity)
        {
            string sql = @"UPDATE [User]
                           SET [Username] = @Username, [Password] = @Password, [EmailAddress] = @EmailAddress, [PhoneNumber] = @PhoneNumber
                           WHERE [UserId] = @UserId";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var userId = await connection.ExecuteScalarAsync<Guid>(sql, entity);

                return userId;
            }
        }
    }
}
