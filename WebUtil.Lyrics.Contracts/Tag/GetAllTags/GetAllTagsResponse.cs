using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Tag.GetAllTags
{
    public record GetAllTagsResponse(IEnumerable<TagRecord> TagList);
    public record TagRecord(
        int TagId,
        string TagCode,
        string TagName,
        int Status);
}
