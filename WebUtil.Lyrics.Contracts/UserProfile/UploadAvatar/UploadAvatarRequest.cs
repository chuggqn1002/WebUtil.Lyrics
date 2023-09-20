using Microsoft.AspNetCore.Http;


namespace WebUtil.Lyrics.Contracts.UserProfile.UploadAvatar
{
    public record UploadAvatarRequest(IFormFile formFile);
    
}
