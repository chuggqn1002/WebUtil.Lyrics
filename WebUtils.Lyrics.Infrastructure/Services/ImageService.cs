using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        public readonly string _imageDirectory;

        public ImageService(IConfiguration configuration)
        {

            _imageDirectory =Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), configuration.GetSection("AppSettings")["UploadRootPath"]);
        }

        public Stream GetImageStream(string imageName)
        {
            string imagePath = Path.Combine(_imageDirectory, imageName);

            if (!File.Exists(imagePath))
            {
                return null; // Image not found
            }

            return new FileStream(imagePath, FileMode.Open, FileAccess.Read);
        }
    }
}
