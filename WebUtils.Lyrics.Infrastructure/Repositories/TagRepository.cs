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
    public class TagRepository : ITagRepository
    {
        private IConfiguration _configuration;
        private ICacheManager _cacheManager;

        public TagRepository(IConfiguration configuration, ICacheManager cacheManager)
        {
            _configuration = configuration;
            _cacheManager = cacheManager;
        }

        public Task<int> AddAsync(Tag entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<Tag> GetByGuidAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Tag entity)
        {
            throw new NotImplementedException();
        }
    }
}
