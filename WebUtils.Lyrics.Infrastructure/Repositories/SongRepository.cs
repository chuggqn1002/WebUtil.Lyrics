using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Infrastructure.Repositories
{
  

    public class SongRepository : ISongRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger<SongRepository> _logger;

        public SongRepository(IConfiguration configuration, ICacheManager cacheManager, ILogger<SongRepository> logger)
        {
            _configuration = configuration;
            _cacheManager = cacheManager;
            _logger = logger;
        }

        public async Task<int> AddAsync(Song entity)
        {
            var sql = "Insert into songs (suid, songcode, title, author, album, singer, imgurl, ytbcode, videolink, description, released, status" +
                 " ) VALUES (@Suid, @Songcode, @Title, @Author, @Album, @Singer, @Imgurl, @Ytbcode, @Videolink, @Description, @Released)";
            _logger.LogInformation(sql);
            _logger.LogInformation($"Song inserted: {entity.ToString()}");
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                MySqlCommand command;
                long result = -1;
                using (command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Suid", entity.Suid.ToString());
                    command.Parameters.AddWithValue("@Songcode", entity.SongCode);
                    command.Parameters.AddWithValue("@Title", entity.Title);
                    command.Parameters.AddWithValue("@Author", entity.Author);
                    command.Parameters.AddWithValue("@Album", entity.Album);
                    command.Parameters.AddWithValue("@Singer", entity.SingerCode);
                    command.Parameters.AddWithValue("@Imgurl", entity.ImgUrl);
                    command.Parameters.AddWithValue("@Ytbcode", entity.YtbCode);
                    command.Parameters.AddWithValue("@Videolink", entity.VideoLink);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@Released", entity.Released);

                    await command.ExecuteNonQueryAsync();
                    result = command.LastInsertedId;
                }
                return unchecked((int)result);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM songs WHERE Sid= @Id";
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
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

        public async Task<IEnumerable<Song_Line>> GetSongLinesBySuid(Guid Suid)
        {

            return await _cacheManager.GetOrSetAsync("GetSongLinesBySuid:" + Suid.ToString(),

                async () =>
                {

                    var sql = " select * from wulyrics.song_lines where suid = @Suid order by para, line_order;";
                    using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var recordSong = await connection.QueryAsync<Song_Line>(sql, new { Suid = Suid.ToString() });                       
                        return recordSong;
                    }                    
                },

                TimeSpan.FromMinutes(10));
        }


        public Task<Song> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

      
        public async Task<int> UpdateAsync(Song entity)
        {
            var sql = "UPDATE songs SET Title = @Title, Author= @Author, Album = @Album, Singer= @Singer, Imgurl = @ImgUrl, Ytbcode = @YtbCode, Videolink = @VideoLink, Description = @Description, Status = @Status WHERE Suid = @Suid";
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
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
