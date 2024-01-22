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
	public class CategoryRepository : ICategoryRepository
	{
		private IConfiguration _configuration;
		private ICacheManager _cacheManager;

		public CategoryRepository(IConfiguration configuration, ICacheManager cacheManager)
		{
			_configuration = configuration;
			_cacheManager = cacheManager;
		}

		public async Task<int> AddAsync(Category entity)
		{
			var sql = "insert into categories(categorycode, categoryname, status) values (@categorycode,@categoryname,@categorystatus)";

			Log.Information($"Insert category sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				int id = await connection.ExecuteScalarAsync<int>(sql, new
				{
					categorycode = entity.CategoryCode,
					categoryname = entity.CategoryName,
					categorystatus = entity.Status
				});
				await _cacheManager.DeleteKey("Category:GetAllAsync");
				return id;
			}
		}

		public async Task<int> DeleteAsync(int id)
		{
			var sql = "Delete from categories WHERE categoryid = @categoryid";
			Log.Information($"Delete category sql: {sql}, id = {id}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new { categoryid = id });
				await _cacheManager.DeleteKey("Category:GetAllAsync");
				return result;
			}
		}

		public async Task<int> DeleteByCodeAsync(string code)
		{
			var sql = "Delete from categories WHERE categorycode = @categorycode";
			Log.Information($"Delete category sql: {sql}, code = {code}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new { categorycode = code });
				await _cacheManager.DeleteKey("Category:GetAllAsync");
				return result;
			}
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _cacheManager.GetOrSetAsync<IEnumerable<Category>>("Category:GetAllAsync",
				async () =>
				{

					IEnumerable<Category> categoryList = new List<Category>();
					string sql = "select * from categories;";

					using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
					{
						categoryList = await connection.QueryAsync<Category>(sql);
						return categoryList;
					}
				},
				TimeSpan.FromMinutes(10));
		}

		public async Task<Category?> GetByCodeAsync(string code)
		{
			string sql = "select * from categories where categorycode = @categorycode";
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				Category? category = await connection.QueryFirstOrDefaultAsync<Category>(sql, new { categorycode = code });
				if (category != null)
				{
					return category;
				}
			}
			return null;
		}

		public Task<Category> GetByGuidAsync(Guid guid)
		{
			throw new NotImplementedException();
		}

		public async Task<Category> GetByIdAsync(int id)
		{
			string sql = "select * from categories where categoryid = @id";
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				Category? category = await connection.QueryFirstOrDefaultAsync<Category>(sql, new { id });
				if (category != null)
				{
					return category;
				}
			}
			return null;
		}

		public async Task<int> UpdateAsync(Category entity)
		{
			var sql = "UPDATE categories SET categoryname= @categoryname, status = @status WHERE categorycode = @categorycode";
			Log.Information($"Update category sql: {sql}");
			using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();
				var result = await connection.ExecuteAsync(sql, new
				{

					entity.CategoryName,
					entity.Status,
					entity.CategoryCode
				});
				await _cacheManager.DeleteKey("Category:GetAllAsync");
				return result;
			}
		}
	}
}
