using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.SongContract.GetAllSong
{
	public record GetAllSongResponse(IEnumerable<SongResponse> songs);
	public record SongResponse(
		int Sid ,
		Guid Suid,  
		 string SongCode,  
		 string Title  ,
		 string Album  ,
		 string AlbumCode ,
		 string AlbumName ,
		 string Author ,
		 string AuthorCode ,
		 string AuthorName ,
		 string Singer ,
		 string SingerCode ,
		 string SingerName ,
		 string ImgUrl ,
		 string YtbCode ,
		 string VideoLink ,
		 string Description ,
		 DateTime Released ,
		 int Status ,
		 IEnumerable<Song_Line> Song_Lines ,
		
		 IEnumerable<Song_Tag> Song_Tags ,
		IEnumerable<Song_Category> Song_Categories
		
	);
	public record Song_Line(
		Guid Suid,
		int SlId ,
		string? Song_Text,
		int Line_Order,
		int Param
		);
	public record Song_Tag(
		Guid Suid,
		int StId,
		string TagCode,
		string TagName,
		int Status
		);
	public record Song_Category(
		Guid Suid,
		int ScId,
		string CategoryCode,
		string CategoryName,
		int Status
		);

}
