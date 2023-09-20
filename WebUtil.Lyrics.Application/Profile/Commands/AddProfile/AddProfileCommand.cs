using MediatR;

namespace WebUtil.Lyrics.Application.UserProfile.Commands.AddProfile
{
    public record AddProfileCommand
    (
        //list of properties
        Guid Uuid,
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
        DateTime Birthdate,
        string Avatar,
        int Gender,
        string TelNum,
        string Description,
        int Status,
        DateTime Created,
        DateTime Updated
    ) : IRequest<AddProfileResult>;
}
