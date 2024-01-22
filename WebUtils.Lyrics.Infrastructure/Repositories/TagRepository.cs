using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;
using WebUtil.Lyrics.Domain.Entities;
using static Dapper.SqlMapper;

namespace WebUtil.Lyrics.Infrastructure.Repositories
{
	public class TagRepository : ITagRepository
    {
        private IConfiguration _configuration;
        private ICacheManager _cacheManager;
  

        public TagRepository(IConfiguration configuration, ICacheManager cacheManager)
        {
            _configuration = configuration;
            _cacheManager = cacheManager;
        }

        public async Task<int> AddAsync(Tag entity)
        {
            
            var sql = "insert into tags(tagcode, tagname, status) values (@tagcode,@tagname,@tagstatus)";
            
            Log.Information($"Insert tag sql: {sql}");
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				int id = await connection.ExecuteScalarAsync<int>(sql, new
                {
                    tagcode = entity.TagCode,
                    tagname = entity.TagName,
                    tagstatus = entity.Status
                });
                await _cacheManager.DeleteKey("Tag:GetAllAsync");
				return id;
			}
		}

        public async Task<int> DeleteAsync(int id)
        {
			var sql = "Delete from tags WHERE tagid = @tagid";
			Log.Information($"Delete sql: {sql}, id = {id}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new{tagid =  id});
				await _cacheManager.DeleteKey("Tag:GetAllAsync");
				return result;
			}
		}

		public async Task<int> DeleteByCodeAsync(string code)
		{
			var sql = "Delete from tags WHERE tagcode = @tagcode";
			Log.Information($"Delete sql: {sql}, tagcode = {code}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new { tagcode = code });
				await _cacheManager.DeleteKey("Tag:GetAllAsync");
				return result;
			}
		}

		public async Task<IEnumerable<Tag>> GetAllAsync()
        {

            return await _cacheManager.GetOrSetAsync<IEnumerable<Tag>>("Tag:GetAllAsync", 
                async() =>
                {

                    IEnumerable<Tag> tagList = new List<Tag>();
                    string sql = "select * from tags;";

                    using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                            tagList = await connection.QueryAsync<Tag>(sql);
                            return tagList;
                    }
                }, 
                TimeSpan.FromMinutes(10));
    
        }

		public async Task<Tag?> GetByCodeAsync(string code)
		{
			string sql = "select * from tags where tagcode = @tagcode";
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				Tag? tag = await connection.QueryFirstOrDefaultAsync<Tag>(sql, new {tagcode = code });
				if (tag != null)
				{
					return tag;
				}
			}
			return null;
		}

		public Task<Tag> GetByGuidAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            string sql = "select * from tags where tagid = @id";
            using(var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Tag? tag = await connection.QueryFirstOrDefaultAsync<Tag>(sql, new {id});
                if (tag != null)
                {
                    return tag;
                }
            }
            return null;
		
		}

        public async Task<int> UpdateAsync(Tag entity)
        {
			var sql = "UPDATE tags SET tagname= @tagname, status = @status WHERE tagcode = @tagcode";
            Log.Information($"Update tag sql: {sql}");
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new
                {
                    
                    entity.TagName,
                    entity.Status,
					entity.TagCode
				});
				await _cacheManager.DeleteKey("Tag:GetAllAsync");
				return result;
			}
		}
    }
}
