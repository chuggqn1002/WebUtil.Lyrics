using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.UserProfile.UpdateProfile
{
    public record UpdateProfileRequest
    (
        string FirstName,
        string LastName,
        string Middle,
        string Title,
        string Address,
        string Ward,
        string District,
        string City,
        string Country,
        string ZipCode,
        string Birthdate,
        string Avatar,
        int Gender,
        string TelNum,
        string Description,
        int Status
    );
}
