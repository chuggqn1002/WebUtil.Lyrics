using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Infrastructure.Repositories
{
  

    public class SongRepository : ISongRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ICacheManager _cacheManager;

        public SongRepository(IConfiguration configuration, ICacheManager cacheManager)
        {
            _configuration = configuration;
            _cacheManager = cacheManager;
        }

        public Task<int> AddAsync(Song entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Song>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Song> GetByGuidAsync(Guid guid)
        {
            return await _cacheManager.GetOrSetAsync("GetSongGuidAsync:" + guid.ToString(),

                async () =>
                {

                var sql =   " SELECT s.*,a.AuthorCode,  a.AuthorName,  al.AlbumName, al.AlbumCode, si.SingerCode, si.SingerName  FROM songs s " +
                            " JOIN  authors a ON s.author = a.authorcode  " +
                            " JOIN  albums al ON s.album = al.albumcode " +
                            " JOIN  singers si ON s.singer = si.singercode " +
                            " WHERE s.Suid = @Suid;";

                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var recordSong = await connection.QueryAsync<Song>(sql, new { Suid = guid.ToString() });
                    if (recordSong.Any())
                    {
                        var song = recordSong.First();
                        //get song_lines, song_tags
                        var sql1 = " select * from song_lines where suid = @Suid1;" +
                                    " select * from song_tags st inner join tags t on st.tagcode = t.tagcode where st.suid = @Suid2;";
                        using (var song_details = connection.QueryMultiple(sql1, new { Suid1 = guid.ToString(), Suid2 = guid.ToString() }))
                        {
                            var songLines = song_details.Read<Song_Line>().ToList();
                            var songTags = song_details.Read<Song_Tag>().ToList();
                            song.Song_Lines = songLines;
                            song.Song_Tags = songTags;
                        }
                        return song;

                    }
                }
                    return new Song();
            }, 
                
                TimeSpan.FromMinutes(10));
            
        }

        public Task<IEnumerable<Song_Line>> GetSongLinesBySuid(Guid Suid)
        {
            throw new NotImplementedException();
        }


        public Task<Song> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

      
        public Task<int> UpdateAsync(Song entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Song>> GetSongPagedList(int pageNum, int pageSize)
        {
            return await _cacheManager.GetOrSetAsync("GetSongPageList:" + pageNum.ToString() + ":" + pageSize.ToString(),
                async() =>
                {
                    IEnumerable<Song> songs = new List<Song>();
                    using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        int rowsToSkip = (pageNum - 1) * pageSize;

                        string sql =
                            " SELECT s.*,a.AuthorCode,  a.AuthorName,  al.AlbumName, al.AlbumCode, si.SingerCode, si.SingerName  FROM songs s " +
                            " JOIN  authors a ON s.author = a.authorcode  " +
                            " JOIN  albums al ON s.album = al.albumcode " +
                            " JOIN  singers si ON s.singer = si.singercode " +
                            " ORDER BY sid DESC" +
                            " LIMIT @RowsToSkip, @PageSize";

                        songs = await connection.QueryAsync<Song>(sql, new { RowsToSkip = rowsToSkip, PageSize = pageSize });
                       
                        
                        return songs;
                    }
                },
                TimeSpan.FromMinutes(10)
                );
        }
    }
}
