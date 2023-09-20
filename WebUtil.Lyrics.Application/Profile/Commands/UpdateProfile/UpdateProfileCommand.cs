using MediatR;

namespace WebUtil.Lyrics.Application.UserProfile.Commands.UpdateProfile
{
    public record UpdateProfileCommand
    (
        Guid Uuid,
        string FirstName,
        string LastName,
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
        string Description
    ): IRequest<UpdateProfileResult>;
}
