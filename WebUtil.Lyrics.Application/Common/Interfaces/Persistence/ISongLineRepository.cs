using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
	public interface ISongLineRepository : IGenericRepository<Domain.Entities.Song_Line>
	{
		Task<IEnumerable<Domain.Entities.Song_Line>> GetSongLinesOfSong(Guid suid);
	}
}
