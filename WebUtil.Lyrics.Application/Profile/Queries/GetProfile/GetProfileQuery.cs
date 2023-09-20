using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.UserProfile.Queries.GetProfile
{
    public record GetProfileQuery(
        Guid Uuid,
        string Email,
        string Username
        ):IRequest<GetProfileResult>;
}
