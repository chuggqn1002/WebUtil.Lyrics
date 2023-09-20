
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Infrastructure.Services
{
    public class FileHandleService : IFileHandleService
    {

        private readonly string _uploadRootPath;
        private readonly string _uploadPath;
        private readonly string _uploadTempPath;
        private readonly ILogger<FileHandleService> _logger;
        private readonly IConfiguration _configuration;

        public FileHandleService( ILogger<FileHandleService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            //Base Directory + Upload Folder -- uploadRootPath
            _uploadRootPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), configuration.GetSection("AppSettings")["UploadRootPath"]);
            _uploadPath = configuration.GetSection("AppSettings")["UploadPath"];
            _uploadTempPath = configuration.GetSection("AppSettings")["UploadTempPath"];
        }

        public void MoveFile(string sourcePath, string destinationPath)
        {
            // Ensure the source file exists
            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException("Source file not found.", sourcePath);
            }

            // Ensure the destination directory exists
            var destinationDirectory = Path.GetDirectoryName(destinationPath);
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }
            _logger.LogTrace($"move file { sourcePath } to { destinationPath}");
            // Move the file to the destination
            File.Move(sourcePath, destinationPath);

        }

        public Task<string> UploadFileAsync(string file, Stream fileContent)
        {
            return  this.uploadAFileSync(_uploadRootPath, file, fileContent);
        }

        public async Task<IList<string>> UploadFileAsync(List<(string fileNames, Stream streamFile)> files)
        {
            List<string> pathFiles = new List<string>();
            foreach ( var (fileName, fileContent) in files)
            {
                pathFiles.Add (uploadAFileSync(_uploadRootPath, fileName, fileContent).ToString());
            }
            return pathFiles;
        }

        public Task<string> UploadTempFileAsync(string file, Stream fileContent)
        {
            return uploadAFileSync(_uploadTempPath, file, fileContent);
        }

        public async Task<IList<string>> UploadTempFileAsync(List<(string fileNames, Stream streamFile)> files)
        {
            List<string> pathFiles = new List<string>();
            foreach (var (fileName, fileContent) in files)
            {
                pathFiles.Add(uploadAFileSync(_uploadTempPath, fileName, fileContent).ToString());
            }
            return pathFiles;
        }

        private async Task<string> uploadAFileSync(string uploadFolder, string fileName, Stream fileStream)
        {
            
            if (fileStream == null || fileStream.Length == 0)
            {
                throw new ArgumentException("Invalid file stream");
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(stream);
            }
            return filePath;
        }
    }
}
