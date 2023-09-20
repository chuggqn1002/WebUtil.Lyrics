using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Profile.Commands.UploadAvatar
{
    public record UploadAvatarCommand(
        string fileName,
        Stream fileContent
        ): IRequest<UploadAvatarCommandResult>;
    
}
