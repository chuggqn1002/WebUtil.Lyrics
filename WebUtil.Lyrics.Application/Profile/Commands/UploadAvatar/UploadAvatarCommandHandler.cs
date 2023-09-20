using MediatR;

using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Application.Profile.Commands.UploadAvatar
{
    public class UploadAvatarCommandHandler : IRequestHandler<UploadAvatarCommand, UploadAvatarCommandResult>
    {

        private readonly IFileHandleService _fileUploadService;

        public UploadAvatarCommandHandler(IFileHandleService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public async Task<UploadAvatarCommandResult> Handle(UploadAvatarCommand request, CancellationToken cancellationToken)
        {
            string fileName = request.fileName;
            Stream fileContent = request.fileContent;
            
            var filePath = await _fileUploadService.UploadFileAsync(fileName, fileContent);

            return new UploadAvatarCommandResult(filePath);
        }

    }
}
