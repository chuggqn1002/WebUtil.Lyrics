using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUtil.Lyrics.Api.Controllers
{
    [Route("create-sql")]
    public class ConvertSqlController : Controller
    {
        [HttpGet("songs")]
        public async Task<IActionResult> GetSongs() {
            List<string> result = new List<string>();
            string result1 = "";
            using (StreamReader r = new StreamReader("data20230920.songs.json"))
            {
                string json = r.ReadToEnd();
                List<JsonSong>? items = JsonConvert.DeserializeObject<List<JsonSong>>(json);
                foreach (var item in items)
                {
                    string sql = "INSERT INTO `wulyrics`.`songs`(`sid`,`suid`,`songcode`,`title`,`author`,`album`,`singer`,`imgurl`,`ytbcode`,`videolink`,`description`,`released`,`status`) VALUES" +
                        "('" + item.Suid.ToString() +
                        "','" + item.SongCode +
                        "','" + item.Title +
                        "','" + item.Album +
                        "','" + item.Author +
                        "','" + item.Singer +
                        "','" + item.ImgUrl +
                        "','" + item.YtbCode +
                        "','" + item.VideoLink +
                        "','" + item.Description +
                        "','" + item.Released.ToString() +
                        "','" + item.Status + "');";
                    result1 = string.Concat(result1, sql);
                    result.Add(sql);
                }
            }

            return Ok(result1);

        }

        [HttpGet("tags")]
        public async Task<IActionResult> GetTags()
        {
            List<string> result = new List<string>();
            string result1 = "";
            using (StreamReader r = new StreamReader("data20230920.tags.json"))
            {
                string json = r.ReadToEnd();
                List<JsonTag>? items = JsonConvert.DeserializeObject<List<JsonTag>>(json);
                foreach (var item in items)
                {
                    string sql = "insert into tags(tagid, tagcode, tagname, status) values ('" + item.TagId +
                        "','" + item.TagCode + "','" + item.TagName + "','" + item.Status + "');";
                    result1 = string.Concat(result1, sql);
                    result.Add(sql);
                }
            }

            return Ok(result1);
        }

        [HttpGet("song-lines")]
        public async Task<IActionResult> GetSongLines()
        {
            string result = "";
            using (StreamReader r = new StreamReader("data20230920.songlines.json"))
            {
                string json = r.ReadToEnd();
                List<JsonSongLine>? items = JsonConvert.DeserializeObject<List<JsonSongLine>>(json);
                foreach (var item in items)
                {
                    string sql = "INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES" +
                        "('" + item.SlId +
                        "','" + item.Suid.ToString() +
                        "','" + item.Song_Text +
                        "','" + item.Line_Order +
                        "','" + item.Param + "');";
                    result = string.Concat(result, sql);
                }
            }
            return Ok(result);
        }

        [HttpGet("song-tags")]
        public async Task<IActionResult> GetSongTags()
        {
            string result = "";
            using (StreamReader r = new StreamReader("data20230920.songtags.json"))
            {
                string json = r.ReadToEnd();
                List< JsonSongTag>? items = JsonConvert.DeserializeObject<List<JsonSongTag>>(json);
                foreach (var item in items)
                {
                    string sql = "INSERT INTO `wulyrics`.`song_tags` (`stid`, `suid`, `tagcode`, `status`) VALUES" +
                        "('" + item.StId +
                        "','" + item.Suid.ToString() +
                        "','" + item.TagCode +
                        "','" + item.Status + "');";
                    result = string.Concat(result, sql);
                }
            }
            return Ok(result);
        }

        private class JsonSongTag
        {
            public int StId { get; set; }
            public Guid Suid { get; set; }            
            public string? TagCode { get; set; }
            public int Status { get; set; }
        }

        private class JsonSongLine
        {
            public int SlId { get; set; }
            public Guid Suid { get; set; }            
            public string? Song_Text { get; set; }
            public int Line_Order { get; set; }
            public int Param { get; set; }
        }

        private class JsonTag
        {
            public int TagId { get; set; }
            public string TagCode { get; set; }
            public string TagName { get; set; }
            public int Status { get; set; }
        }
        private class JsonSong
        {
            public Guid Suid { get; set; }
            public string SongCode { get; set; }
            public string? Title { get; set; }
            public string? Album { get; set; }
            public string? Author { get; set; }
            public string? Singer { get; set; }
            public string? ImgUrl { get; set; }
            public string? YtbCode { get; set; }
            public string? VideoLink { get; set; }
            public string? Description { get; set; }
            public DateTime Released { get; set; }
            public int Status { get; set; }
        }
    }



}
