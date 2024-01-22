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
	public class SongLineRepository : ISongLineRepository
	{
		private IConfiguration _configuration;
		private ICacheManager _cacheManager;

		public SongLineRepository(IConfiguration configuration, ICacheManager cacheManager)
		{
			_configuration = configuration;
			_cacheManager = cacheManager;
		}
		public async Task<int> AddAsync(Song_Line entity)
		{
			var sql = "insert into song_lines(suid, song_text, line_order, para) values (@suid,@song_text,@line_order,@para)";

			Log.Information($"Insert songline sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				int id = await connection.ExecuteScalarAsync<int>(sql, new
				{
					suid = entity.Suid,
					song_text = entity.Song_Text,
					line_order = entity.Line_Order,
					para = entity.Param
				});
				//await _cacheManager.DeleteKey("Tag:GetAllAsync");
				return id;
			}
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Song_Line>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Song_Line> GetByGuidAsync(Guid guid)
		{
			throw new NotImplementedException();
		}

		public Task<Song_Line> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Song_Line>> GetSongLinesOfSong(Guid suid)
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Song_Line>>("SongLine:GetSongLinesOfSong",
				async () =>
				{

					IEnumerable<Song_Line> albumList = new List<Song_Line>();
					string sql = "select * from song_lines where suid = @suid;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						var songlines = await connection.QueryAsync<Song_Line>(sql, new { suid = suid });
						return songlines;
					}
				},
				TimeSpan.FromMinutes(10));
		}

		public Task<int> UpdateAsync(Song_Line entity)
		{
			throw new NotImplementedException();
		}
	}
}
