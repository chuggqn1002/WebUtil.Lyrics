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
	public class AlbumRepository : IAlbumRepository
	{
		private IConfiguration _configuration;
		private ICacheManager _cacheManager;

		public AlbumRepository(IConfiguration configuration, ICacheManager cacheManager)
		{
			_configuration = configuration;
			_cacheManager = cacheManager;
		}
		public async Task<int> AddAsync(Album entity)
		{
			var sql = "insert into albums(albumcode, albumname, released, status) values (@albumcode,@albumname,@released,@status)";

			Log.Information($"Insert album sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				int id = await connection.ExecuteScalarAsync<int>(sql, new
				{
					albumcode = entity.AlbumCode,
					albumname = entity.AlbumName,
					released = entity.Released,
					status = entity.Status,
				});
				await _cacheManager.DeleteKey("Album:GetAllAsync");
				return id;
			}
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<int> DeleteByCodeAsync(string code)
		{
			var sql = "Delete from albums WHERE albumcode = @albumcode";
			Log.Information($"Delete album sql: {sql}, code = {code}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new { albumcode = code });
				await _cacheManager.DeleteKey("Album:GetAllAsync");
				return result;
			}
		}

		public async Task<IEnumerable<Album>> GetAllAsync()
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Album>>("Album:GetAllAsync",
				async () =>
				{

					IEnumerable<Album> albumList = new List<Album>();
					string sql = "select * from albums;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						albumList = await connection.QueryAsync<Album>(sql);
						return albumList;
					}
				},
				TimeSpan.FromMinutes(10));
		}

		public async Task<Album?> GetByCodeAsync(string code)
		{
			string sql = "select * from albums where albumcode = @albumcode";
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				Album? album = await connection.QueryFirstOrDefaultAsync<Album>(sql, new { albumcode = code });
				if (album != null)
				{
					return album;
				}
			}
			return null;
		}

		public Task<Album> GetByGuidAsync(Guid guid)
		{
			throw new NotImplementedException();
		}

		public Task<Album> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<int> UpdateAsync(Album entity)
		{
			var sql = "UPDATE albums SET albumname= @albumname, status = @status WHERE albumcode = @albumcode";
			Log.Information($"Update album sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new
				{

					entity.AlbumName,
					entity.Status,
					entity.AlbumCode
				});
				await _cacheManager.DeleteKey("Album:GetAllAsync");
				return result;
			}
		}
	}
}
