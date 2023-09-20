using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.UserProfile.GetProfile
{
    public record GetProfileResponse
    (
        User User
                
        );

    public record User
    (
        Guid Uuid,
        string Email,
        string Username,
        string FirstName,
        string LastName,
        string Middle,
        string Title,
        string Address ,
        string Ward ,
        string District ,
        string City ,
        string Country ,
        string ZipCode ,
        DateTime Birthdate ,
        string Avatar ,
        string Gender ,
        string TelNum ,
        string Description ,
        int Status ,
        DateTime Created , 
        DateTime Updated
     );
}
