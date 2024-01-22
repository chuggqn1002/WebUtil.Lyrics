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
	public class SingerRepository : ISingerRepository
	{
		private IConfiguration _configuration;
		private ICacheManager _cacheManager;

		public SingerRepository(IConfiguration configuration, ICacheManager cacheManager)
		{
			_configuration = configuration;
			_cacheManager = cacheManager;
		}

		public async Task<int> AddAsync(Singer entity)
		{
			var sql = "insert into Singers(Singercode, Singername, bio,avatar, status) values (@Singercode,@Singername,@bio, @avatar, @status)";

			Log.Information($"Insert Singer sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				int id = await connection.ExecuteScalarAsync<int>(sql, new
				{
					Singercode = entity.SingerCode,
					Singername = entity.SingerName,
					bio = entity.Bio,
					avatar = entity.Avatar,
					status = entity.Status,
				});
				await _cacheManager.DeleteKey("Singer:GetAllAsync");
				return id;
			}
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<int> DeleteByCodeAsync(string code)
		{
			var sql = "Delete from singers WHERE singercode = @singercode";
			Log.Information($"Delete singer sql: {sql}, code = {code}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new { singercode = code });
				await _cacheManager.DeleteKey("Singer:GetAllAsync");
				return result;
			}
		}

		public async Task<IEnumerable<Singer>> GetAllAsync()
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Singer>>("Singer:GetAllAsync",
				async () =>
				{

					IEnumerable<Singer> singerList = new List<Singer>();
					string sql = "select * from Singers;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						singerList = await connection.QueryAsync<Singer>(sql);
						return singerList;
					}
				},
				TimeSpan.FromMinutes(10));
		}

		public async Task<Singer?> GetByCodeAsync(string code)
		{
			string sql = "select * from singers where singercode = @singercode";
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				Singer? singer = await connection.QueryFirstOrDefaultAsync<Singer>(sql, new { singercode = code });
				if (singer != null)
				{
					return singer;
				}
			}
			return null;
		}

		public Task<Singer> GetByGuidAsync(Guid guid)
		{
			throw new NotImplementedException();
		}

		public Task<Singer> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<int> UpdateAsync(Singer entity)
		{
			var sql = "UPDATE singers SET singername= @singername, bio = @bio, avatar = @avatar, status = @status WHERE singercode = @singercode";
			Log.Information($"Update author sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new
				{

					entity.SingerName,
					entity.Bio,
					entity.Avatar,
					entity.Status,
					entity.SingerCode
				});
				await _cacheManager.DeleteKey("Singer:GetAllAsync");
				return result;
			}
		}
	}
}
