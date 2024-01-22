using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Songs.Commands.AddSong
{
	public record AddSongCommand(
		string SongCode,
		string Title,
		string Album,
		string Author,
		string Singer,
		string ImgUrl,
		string YtbCode,
		string VideoLink,
		string Description,
		DateTime Released,
		int Status,
		string[] Song_Lines
		):IRequest<AddSongResult>;
}
