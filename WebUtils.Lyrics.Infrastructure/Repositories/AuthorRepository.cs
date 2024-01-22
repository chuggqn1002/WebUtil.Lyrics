using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Infrastructure.Repositories
{
	public class AuthorRepository : IAuthorRepository
	{
		private IConfiguration _configuration;
		private ICacheManager _cacheManager;

		public AuthorRepository(IConfiguration configuration, ICacheManager cacheManager)
		{
			_configuration = configuration;
			_cacheManager = cacheManager;
		}
		public async Task<int> AddAsync(Author entity)
		{
			var sql = "insert into authors(authorcode, authorname, bio,avatar, status) values (@authorcode,@authorname,@bio, @avatar, @status)";

			Log.Information($"Insert author sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				int id = await connection.ExecuteScalarAsync<int>(sql, new
				{
					authorcode = entity.AuthorCode,
					authorname = entity.AuthorName,
					bio = entity.Bio,
					avatar = entity.Avatar,
					status = entity.Status,
				});
				await _cacheManager.DeleteKey("Author:GetAllAsync");
				return id;
			}
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<int> DeleteByCodeAsync(string code)
		{
			var sql = "Delete from authors WHERE authorcode = @authorcode";
			Log.Information($"Delete author sql: {sql}, code = {code}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new { authorcode = code });
				await _cacheManager.DeleteKey("Author:GetAllAsync");
				return result;
			}
		}

		public async Task<IEnumerable<Author>> GetAllAsync()
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Author>>("Author:GetAllAsync",
				async () =>
				{

					IEnumerable<Author> authorList = new List<Author>();
					string sql = "select * from Authors;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						authorList = await connection.QueryAsync<Author>(sql);
						return authorList;
					}
				},
				TimeSpan.FromMinutes(10));
		}

		public async Task<Author?> GetByCodeAsync(string code)
		{
			string sql = "select * from authors where authorcode = @authorcode";
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				Author? author = await connection.QueryFirstOrDefaultAsync<Author>(sql, new { authorcode = code });
				if (author != null)
				{
					return author;
				}
			}
			return null;
		}

		public Task<Author> GetByGuidAsync(Guid guid)
		{
			throw new NotImplementedException();
		}

		public Task<Author> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<int> UpdateAsync(Author entity)
		{
			var sql = "UPDATE authors SET authorname= @authorname, bio = @bio, avatar = @avatar, status = @status WHERE authorcode = @authorcode";
			Log.Information($"Update author sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new
				{

					entity.AuthorName,
					entity.Bio,
					entity.Avatar,
					entity.Status,
					entity.AuthorCode
				});
				await _cacheManager.DeleteKey("Author:GetAllAsync");
				return result;
			}
		}
	}
}
