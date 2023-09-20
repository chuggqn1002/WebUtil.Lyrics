using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.UserProfile.Queries.GetProfile
{
    public record GetProfileResult(
        string Email,
        string Username,
        User_Profile profile
        );
}
