using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Songs.Queries.SearchSong
{
	public record SearchSongQuery(string query):IRequest<SearchSongResult>;
}
