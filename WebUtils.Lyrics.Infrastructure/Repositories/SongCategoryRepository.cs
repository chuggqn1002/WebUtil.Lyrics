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
	public class SongCategoryRepository : ISongCategoryRepository
	{
		private readonly IConfiguration _configuration;
		private readonly ICacheManager _cacheManager;

		public SongCategoryRepository(IConfiguration configuration, ICacheManager cacheManager)
		{
			_configuration = configuration;
			_cacheManager = cacheManager;
		}

		public Task<int> AddAsync(Song_Category entity)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Song_Category>> GetAllAsync()
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Song_Category>>("SongCategory:GetAllAsync",
				async () =>
				{
					IEnumerable<Song_Category> songtagList = new List<Song_Category>();
					string sql = "select * from song_categories sc inner join categories c on sc.categorycode = c.categorycode;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						songtagList = await connection.QueryAsync<Song_Category>(sql);
						return songtagList;
					}
				}, TimeSpan.FromMinutes(10));
		}

		public async Task<IEnumerable<Song_Category>> GetAllBySuidAsync(string suid)
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Song_Category>>("SongCategory:GetAllBySuidAsync" + suid,
				async () =>
				{
					IEnumerable<Song_Category> songcateList = new List<Song_Category>();
					string sql = "select * from song_categories sc inner join categories c on sc.categorycode = c.categorycode where sc.suid = @suid;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						songcateList = await connection.QueryAsync<Song_Category>(sql, new { suid = suid });
						return songcateList;
					}
				}, TimeSpan.FromMinutes(10));
		}

		public Task<Song_Category> GetByGuidAsync(Guid guid)
		{
			throw new NotImplementedException();
		}

		public Task<Song_Category> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> UpdateAsync(Song_Category entity)
		{
			throw new NotImplementedException();
		}
	}
}
