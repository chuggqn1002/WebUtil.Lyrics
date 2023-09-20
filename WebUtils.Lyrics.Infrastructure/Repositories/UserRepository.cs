using Dapper;
using WebUtil.Lyrics.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using BC = BCrypt.Net.BCrypt;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IConfiguration configuration;
        private ILogger<UserRepository> _logger;
        private readonly ICacheManager _cacheManager;
        public UserRepository(IConfiguration configuration, ILogger<UserRepository> logger, ICacheManager cacheManager)
        {
            this.configuration = configuration;
            _logger = logger;
            _cacheManager = cacheManager;
        }

        //public async Task<IEnumerable<UserContact>> GetAllContact(int Uid)
        //{
        //    var sql = "SELECT u.Uid, u.UserId as uidString,  c.Contactid, u.Name, c.Email, c.PhoneNumber FROM contacts c " +
        //              " Inner join users u WHERE u.uid = c.uid and u.uid = @Id";
        //    using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<UserContact>(sql, new { Id = Uid });
        //        return result.ToList(); ;
        //    }
        //}

        public async Task<int> AddAsync(User entity)
        {
            var sql = "Insert into users (Uuid, Username, Email, Password, Role, Status," +
                " created, updated) VALUES (@Uuid, @Username, @Email, @Password, @Role, @Status, @Created, @Updated)";
            _logger.LogInformation(sql);
            _logger.LogInformation($"User inserted: {entity.ToString()}");
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                MySqlCommand command;
                long result = -1;
                using (command = new MySqlCommand(sql, connection) )
                {
                    command.Parameters.AddWithValue("@Uuid", entity.Uuid.ToString());
                    command.Parameters.AddWithValue("@Username", entity.Username.IsNullOrEmpty() ? "" : entity.Username.ToString());
                    command.Parameters.AddWithValue("@Email", entity.Email.IsNullOrEmpty() ? "" : entity.Email.ToString());
                    command.Parameters.AddWithValue("@Password", BC.HashPassword(entity.Password.ToString()));
                    command.Parameters.AddWithValue("@Role", entity.Role.ToString());
                    command.Parameters.AddWithValue("@Status", entity.Status.ToString());
                    command.Parameters.AddWithValue("@Created", entity.Created);
                    command.Parameters.AddWithValue("@Updated", entity.Updated);

                    await command.ExecuteNonQueryAsync();
                    result = command.LastInsertedId;
                }
                return unchecked((int)result);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM users WHERE Userid = @Id";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            string sql = "SELECT u.* FROM users u";
            using(var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();            
            }
        }
      
        public async Task<User> GetByIdAsync(int id)
        {
            return await _cacheManager.GetOrSetAsync("User_Id:" + id, 
                async () =>{ 
                    var sql = "SELECT  u.*  FROM users u WHERE userid = @Id";
                    using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                        return result;
                    }}, TimeSpan.FromMinutes(10));


        }

        public async Task<User> GetByGuidAsync(Guid guid)
        {
            return await _cacheManager.GetOrSetAsync("User_Uuid_" + guid, async () => {
                    var sql = "SELECT  u.*  FROM users u WHERE Uuid = @Uuid";
                    using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Uuid = guid.ToString() });
                        return result;
                    }
                }, TimeSpan.FromMinutes(10));        }

    public async Task<int> UpdateAsync(User entity)
        {
            
            var sql = "UPDATE users SET Username = @Username, Email= @Email, Password = @Password, Role = @Role, Status = @Status WHERE UserId = @Userid";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<User> GetUserByEmail(string Email)
        {
            return await _cacheManager.GetOrSetAsync("User_Email_" + Email, async () =>
                {
                    var sql = "SELECT u.* FROM users u WHERE u.email = @Email";
                    using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Email = Email });

                        return result;
                    }
                }
            , TimeSpan.FromMinutes(10));

        }

    }
}

