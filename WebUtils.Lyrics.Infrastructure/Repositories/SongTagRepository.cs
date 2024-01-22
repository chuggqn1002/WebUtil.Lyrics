using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
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
	public class SongTagRepository : ISongTagRepository
	{
		private readonly IConfiguration _configuration;
		private readonly ICacheManager _cacheManager;

		public SongTagRepository(IConfiguration configuration, ICacheManager cacheManager)
		{
			_configuration = configuration;
			_cacheManager = cacheManager;
		}


		public Task<int> AddAsync(Song_Tag entity)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Song_Tag>> GetAllAsync()
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Song_Tag>>("SongTag:GetAllAsync",
				async() =>
				{
					IEnumerable<Song_Tag> songtagList = new List<Song_Tag>();
					string sql = "select * from song_tags st inner join tags t on st.tagcode = t.tagcode;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						songtagList = await connection.QueryAsync<Song_Tag>(sql);
						return songtagList;
					}
				}, TimeSpan.FromMinutes(10));
		}

		public async Task<IEnumerable<Song_Tag>> GetAllBySuidAsync(string suid)
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Song_Tag>>("SongTag:GetAllBySuidAsync"+suid,
				async () =>
				{
					IEnumerable<Song_Tag> songtagList = new List<Song_Tag>();
					string sql = "select * from song_tags st inner join tags t on st.tagcode = t.tagcode where st.suid = @suid;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						songtagList = await connection.QueryAsync<Song_Tag>(sql, new { suid = suid});
						return songtagList;
					}
				}, TimeSpan.FromMinutes(10));
		}

		public Task<Song_Tag> GetByGuidAsync(Guid guid)
		{
			throw new NotImplementedException();
		}

		public Task<Song_Tag> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> UpdateAsync(Song_Tag entity)
		{
			throw new NotImplementedException();
		}
	}
}
