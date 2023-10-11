using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using WebUtil.Lyrics.Application.Common.Errors;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {

        private readonly IConfiguration configuration;
        private ILogger<ProfileRepository> logger;
        public ProfileRepository(IConfiguration configuration, ILogger<ProfileRepository> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<int> AddAsync(User_Profile entity)
        {

            var sql = "Insert into user_profiles (Uuid, FirstName,LastName,Middle,Title,Address,Ward,District,City,Country,ZipCode,Birthdate,Avatar,Gender,TelNum,Description,Status,Created,Updated) " +
                "VALUES (@Uuid, @FirstName,@LastName,@Middle,@Title,@Address,@Ward,@District,@City,@Country,@ZipCode,@Birthdate,@Avatar,@Gender,@TelNum,@Description,@Status,@Created,@Updated)";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try { 
                    connection.Open();
                    MySqlCommand command;
                    long result = -1;
                    using (command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Uuid" , entity.Uuid);
                        command.Parameters.AddWithValue("@FirstName" , entity.FirstName);
                        command.Parameters.AddWithValue("@LastName" , entity.LastName);
                        command.Parameters.AddWithValue("@Middle" , entity.Middle);
                        command.Parameters.AddWithValue("@Title" , entity.Title);
                        command.Parameters.AddWithValue("@Address" , entity.Address);
                        command.Parameters.AddWithValue("@Ward" , entity.Ward);
                        command.Parameters.AddWithValue("@District" , entity.District);
                        command.Parameters.AddWithValue("@City" , entity.City);
                        command.Parameters.AddWithValue("@Country" , entity.Country);
                        command.Parameters.AddWithValue("@ZipCode" , entity.ZipCode);
                        command.Parameters.AddWithValue("@Birthdate", entity.Birthdate);
                        command.Parameters.AddWithValue("@Avatar" , entity.Avatar);
                        command.Parameters.AddWithValue("@Gender" , entity.Gender);
                        command.Parameters.AddWithValue("@TelNum" , entity.TelNum);
                        command.Parameters.AddWithValue("@Description" , entity.Description);
                        command.Parameters.AddWithValue("@Status" , entity.Status);
                        command.Parameters.AddWithValue("@Created" , entity.Created);
                        command.Parameters.AddWithValue("@Updated" , entity.Updated);

                        await command.ExecuteNonQueryAsync();
                        result = command.LastInsertedId;
                    }
                    return unchecked((int)result);
                }
                catch (MySqlException ex)
                {
                    logger.LogError(ex.StackTrace, ex.ErrorCode + ex.Message);
                    throw new InvalidExeSQL();
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM user_profiles WHERE ProfileId= @Id";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, new { Id = id });
                    return result;
                }
                catch (MySqlException ex)
                {
                    logger.LogError(ex.StackTrace, ex.ErrorCode + ex.Message);
                    throw new InvalidExeSQL();
                }
            }
        }

        public Task<IEnumerable<User_Profile>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User_Profile> GetByGuidAsync(Guid guid)
        {
            var sql = "SELECT * FROM user_profiles WHERE Uuid= @Guid";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                    var result = await connection.QueryAsync<User_Profile>(sql, new { Guid = guid.ToString() });
                    if (result.Any())
                        return result.First();
                }
                catch (MySqlException ex)
                {
                    logger.LogError(ex.StackTrace, ex.ErrorCode + ex.Message);
                    throw new InvalidExeSQL();
                }
            }
            return null;
        }

        public async Task<User_Profile> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM user_profiles WHERE ProfileId= @Id";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                    var result = await connection.QueryFirstAsync<User_Profile>(sql, new { Id = id });
                    return result;
                }
                catch (MySqlException ex)
                {
                    logger.LogError(ex.StackTrace, ex.ErrorCode + ex.Message);
                    throw new InvalidExeSQL() ;
                }
            }
        }

        public Task<int> UpdateAsync(User_Profile entity)
        {
            throw new NotImplementedException();
        }
    }
}
