using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Domain.Entities
{
	public class Song_Category
	{
		public Guid Suid { get; set; }
		public int ScId { get; set; }
		public string? CategoryCode { get; set; }
		public string? CategoryName { get; set; }
		public int Status { get; set; }
	}
}
