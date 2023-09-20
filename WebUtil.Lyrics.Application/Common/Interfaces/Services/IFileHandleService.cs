namespace WebUtil.Lyrics.Application.Common.Interfaces.Services
{
    public interface IFileHandleService
    {
        Task<string> UploadFileAsync(string file, Stream fileContent);
        Task<IList<string>> UploadFileAsync(List<(string fileNames, Stream streamFile)> files);
        Task<string> UploadTempFileAsync(string file, Stream fileContent);
        Task<IList<string>> UploadTempFileAsync(List<(string fileNames, Stream streamFile)> files);
        void MoveFile(string sourcePath, string destinationPath);
    }
}
