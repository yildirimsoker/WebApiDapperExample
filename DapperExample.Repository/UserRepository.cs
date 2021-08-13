using Dapper;
using DapperExample.Core.Entities;
using DapperExample.Core.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> Add(User entity)
        {
            entity.InsertDate = DateTime.Now;
            var sql = $"Insert Into [User] (Name, Surname, Email, InsertDate) Values(@Name, @Surname, @Email, @InsertDate);";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
        public async Task<int> Delete(int id)
        {
            var sql = $"Delete From [User] Where UserId = @UserId;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { UserId = id });
                return affectedRows;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = $"Select * From [User]";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result;
            }
        }

        public async Task<User> GetById(int id)
        {
            var sql = $"Select * From [User] Where UserId = @UserId;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<User>(sql, new { UserId = id });
                return result;
            }
        }

        public async Task<int> Update(User entity)
        {
            entity.InsertDate = DateTime.Now;
            var sql = $"Update [User] Set Name = @Name, Surname = @Surname, Email = @Email Where UserId = @UserId;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
    }
}
